using BankingWebAPI.Models;

namespace BankingWebAPI.Services
{
    public class validationService
    {
        public bool validateNoBalanceLessThan100(withdrawDTO withdraw, bankingModel record)
        {
            if (record.Balance - withdraw.withdrawAmt < 100)
            {
                throw new Exception("Account total balance cannot be less than $100.");
            }
            return true;
        }


        public bool validateNoMoreThan90PercentOfTotalBalance(withdrawDTO withdraw, bankingModel record)
        {
            var threshold = record.Balance * 0.9;
            if (withdraw.withdrawAmt > threshold)
            {
                throw new Exception("Withdrawal amount cannot be more than 90% of total account balance.");
            }
            return true;
        }

        public bool validateNoTransactionsOver10000(depositDTO deposit, bankingModel record)
        {
            if (deposit.depositAmt > 10000)
            {
                throw new Exception("Deposit amount cannot exceed $10,000.");
            }
            return true;
        }
    }
}
