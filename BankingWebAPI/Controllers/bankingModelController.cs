using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankingWebAPI.Models;
using BankingWebAPI.Services;
using System.Web.Http;

namespace BankingWebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class bankingModelController : ControllerBase
    {
        private readonly bankingContext _context;

        public bankingModelController(bankingContext context)
        {
            _context = context;
        }

        // PUT: api/bankingModel
        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/withdraw")]
        public async Task<ActionResult> withdraw([Microsoft.AspNetCore.Mvc.FromBody] withdrawDTO Model)
        {
            var record = _context.bankingModels.FirstOrDefault(r => r.Id == Model.accountNo);
            if (record == null)
            {
                throw new Exception("Can't find account");
            }
            var validation = new validationService();
            validation.validateNoBalanceLessThan100(Model, record);
            validation.validateNoMoreThan90PercentOfTotalBalance(Model, record);
            double balance = withdrawTrans.withdrawal(Model,record);
            record.Balance = balance;
            _context.bankingModels.Update(record);
            await _context.SaveChangesAsync();
            return Ok(validation);
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/deposit")]
        public async Task<ActionResult> depositAmt([Microsoft.AspNetCore.Mvc.FromBody] depositDTO Model)
        {
            var record = _context.bankingModels.FirstOrDefault(r => r.Id == Model.accountNo);
            if (record == null)
            {
                throw new Exception("Can't find account");
            }
            var validation = new validationService();
            validation.validateNoTransactionsOver10000(Model, record);
            double balance = depositTrans.deposit(Model,record);
            record.Balance = balance;
            _context.bankingModels.Update(record);
            await _context.SaveChangesAsync();
            return Ok(validation);
        }

        private bool bankingModelExists(int id)
        {
            return _context.bankingModels.Any(e => e.Id == id);
        }
    }
}
