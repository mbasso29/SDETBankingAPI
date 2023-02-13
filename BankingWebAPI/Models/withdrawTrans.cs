namespace BankingWebAPI.Models
{
    public static class withdrawTrans
    {
        public static double withdrawal(withdrawDTO withdrawTrans, bankingModel acctBal)
        {
            double withdraw = withdrawTrans.withdrawAmt;
            double bal = acctBal.Balance;
            double withdrawalBal = bal - withdraw;

            return withdrawalBal;
        }
    }
}
