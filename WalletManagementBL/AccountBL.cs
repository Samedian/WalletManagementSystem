using System;
using System.Threading.Tasks;
using WalletManagementDL;
using WalletManagementEntity;

namespace WalletManagementBL
{
    public class AccountBL
    {
        private readonly AccountDL _accountDL;
        public AccountBL(AccountDL accountDL)
        {
            _accountDL = accountDL;
        }

        public async Task<int> Register(User user)
        {
            return await _accountDL.Register(user);
        }

        public async Task<int> Login(User user)
        {
            return await _accountDL.Login(user);
        }
    }
}
