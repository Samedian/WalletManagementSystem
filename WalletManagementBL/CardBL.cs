using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalletManagementDL;
using WalletManagementEntity;

namespace WalletManagementBL
{
    public class CardBL
    {
        private readonly CardDL _cardDL;
        public CardBL(CardDL cardDL)
        {
            _cardDL = cardDL;
        }

        public async Task<bool> AddCard(Card card)
        {
            return await _cardDL.AddCard(card);
        }

        public async Task<List<Card>> GetCard(int id)
        {
            return await _cardDL.GetCard(id);
        }

        public async Task<bool> DeleteCard(int id)
        {
            return await _cardDL.DeleteCard(id);
        }
    }
}
