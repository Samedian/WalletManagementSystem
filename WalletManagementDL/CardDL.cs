using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletManagementEntity;
using WalletManagementException;

namespace WalletManagementDL
{
    public class CardDL
    {
        private readonly WalletContext _dbcontext;
        public CardDL(WalletContext walletContext)
        {
            _dbcontext = walletContext;
        }

        public async Task<bool> AddCard(Card card)
        {
            try
            {
                Card data = _dbcontext.CardModels.AsNoTracking().FirstOrDefault(x => x.CardNumber==card.CardNumber);

                if (data != null)
                    throw new CustomException("card Already Exist");

                await _dbcontext.CardModels.AddAsync(card);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch (CustomException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Card>> GetCard(int id)
        {
            try
            {
                List<Card> data = await _dbcontext.CardModels.AsNoTracking().Where(x=>x.UserId==id).ToListAsync();
                return data;

            }catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCard(int id)
        {
            try
            {
                Card data = await _dbcontext.CardModels.AsNoTracking().FirstOrDefaultAsync(x => x.CardId == id);
                if (data == null)
                    throw new CustomException("card Not Found");

                _dbcontext.Remove(data);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch (CustomException)
            {
                return false;
            }
            catch (Exception)
            {
                return false; ;
            }
        }
    }
}
