using System.Security.Principal;

namespace BankingWebAPI.Models
{
    public class withdrawDTO
    {
        public int accountNo { get; set; }
        public double withdrawAmt { get; set; }
    }
}
