using System.ComponentModel.DataAnnotations;

namespace BankingWebAPI.Models
{
    public class bankingModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Balance { get; set; }
        public bool isActive { get; set; }

        
    }
}
