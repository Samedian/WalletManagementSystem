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
    public class AccountDL
    {
        private readonly WalletContext _dbcontext;
        public AccountDL(WalletContext walletContext)
        {
            _dbcontext = walletContext;
        }

        public async Task<int> Register(User user)
        {
            try
            {
                User data = _dbcontext.UserModels.AsNoTracking().FirstOrDefault(x => x.Email == user.Email);

                if (data != null)
                    throw new CustomException("User Already Exist");
                
                await _dbcontext.UserModels.AddAsync(user);
                await _dbcontext.SaveChangesAsync();
                return user.UserId;

            }
            catch (CustomException)
            {
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> Login(User user)
        {
            try
            {
                User data =await _dbcontext.UserModels.AsNoTracking().FirstOrDefaultAsync(x => x.Email == user.Email && x.SecretPassword==user.SecretPassword);

                if (data == null)
                    throw new CustomException("User Not Found");

                return data.UserId;

            }
            catch (CustomException)
            {
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
