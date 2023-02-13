using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;
using Gherkin.Ast;
using bankingWebAPI_Gherkin.Model.Interfaces;
using RestSharp;
using NUnit.Framework;
using BankingWebAPI.Models;
using BankingWebAPI.Services;
using bankingWebAPI_Gherkin.Model;

namespace bankingWebAPI_Gherkin.StepDefinitions
{
    [Binding()]
    public class BankingStepDefinitions
    {
        #region Private variables
        private bankingModel? _account;
        private Exception? _error;
        #endregion

        [Given(@"account number is (.*)")]
        public void GivenAccountNumberIs(int accountNo)
        {
            if (accountNo < 1)
            {
                throw new OverflowException("The account number must be at least 1.");
            }
            if (_account == null)
            {
                _account = new bankingModel();
            }
            _account.Id = accountNo;
        }
        
        [Given(@"account is active")]
        public void GivenAccountIsActive()
        {
            if (_account == null)
            {
                _account = new bankingModel();
            }
            _account.isActive = true;
        }

        [Given(@"name on account is '([^']*)'")]
        public void GivenNameOnAccountIs(string accountName)
        {
            if (_account == null)
            {
                _account = new bankingModel();
            }
            _account.Name = accountName;
        }

        [Given(@"account balance is (.*)")]
        public void GivenAccountBalanceIs(double accountBal)
        {
            if (_account == null)
            {
                _account = new bankingModel();
            }
            _account.Balance = accountBal;
        }

        [Then(@"I expect to see the following output")]
        public void GivenIExpectToSeeTheFollowingOutput(Table table)
        {
            string nameCol = table.GetColumnName("Name");
            string accountNoCol = table.GetColumnName("AccountNo");
            string activeCol = table.GetColumnName("IsActive");
            string balCol = table.GetColumnName("Balance");

            foreach (var row in table.Rows)
            {
                string name = String.Empty;
                int accountNo = 0;
                bool isActive = false;
                double balance = 0.0;

                if (table.ContainsColumn(nameCol))
                {
                    name = row[nameCol].ToString();
                }
                if(table.ContainsColumn(accountNoCol))
                {
                    accountNo = Convert.ToInt32(row[accountNoCol].ToString());
                }
                if(table.ContainsColumn(activeCol))
                {
                    if (row[activeCol].ToString() == "true")
                    {
                        isActive = true;
                    }
                    else
                    {
                        isActive = false;
                    }
                }
                if (table.ContainsColumn(balCol))
                {
                    balance = Convert.ToDouble(row[balCol].ToString());
                }

                NUnit.Framework.Assert.AreEqual(name, _account.Name);
                NUnit.Framework.Assert.AreEqual(accountNo, _account.Id);
                NUnit.Framework.Assert.AreEqual(isActive, _account.isActive);
                NUnit.Framework.Assert.AreEqual(balance, _account.Balance);
            }
        }

        [Given(@"user attempts to withdraw an amount of (.*)")]
        public void GivenUserAttemptsToWithdrawAnAmountOf(double withdrawAmt)
        {
            try
            {
                var DTO = new withdrawDTO()
                {
                    accountNo = _account.Id,
                    withdrawAmt = withdrawAmt,
                };
                var validation = new validationService();
                validation.validateNoBalanceLessThan100(DTO, _account);
                validation.validateNoMoreThan90PercentOfTotalBalance(DTO, _account);
                double balance = withdrawTrans.withdrawal(DTO, _account);
                _account.Balance = balance;
            }
            catch (Exception ex)
            {
                _error = ex;
            }
        }

        [Given(@"user attempts to deposit (.*) into account")]
        public void GivenUserAttemptsToDepositIntoAccount(double depositAmt)
        {
            try { 
                var DTO = new depositDTO()
                {
                    accountNo = _account.Id,
                    depositAmt = depositAmt,
                };
                var validation = new validationService();
                validation.validateNoTransactionsOver10000(DTO, _account);
                double balance = depositTrans.deposit(DTO, _account);
                _account.Balance = balance;
            }
            catch (Exception ex)
            {
                _error = ex;
            }
        }

        [Then(@"I expect an exception to be thrown")]
        public void ThenIExpectAnExceptionToBeThrown()
        {
            NUnit.Framework.Assert.IsNotNull(_error);
        }
    }
}