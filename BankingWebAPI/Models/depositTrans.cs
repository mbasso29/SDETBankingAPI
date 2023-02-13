namespace BankingWebAPI.Models
{
    public static class depositTrans
    {
        public static double deposit(depositDTO depositTrans, bankingModel acctBal)
        {
            double deposit = depositTrans.depositAmt;
            double bal = acctBal.Balance;
            double depositBal = bal + deposit;

            return depositBal;
        }
    }
}
