using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankingWebAPI_Gherkin.Model.Interfaces;
using Microsoft.Identity.Client;

namespace bankingWebAPI_Gherkin.Model.Interfaces
{
    public interface AccountManager
    {
        AccountManager WithActiveAccount(string name, int accountNo, bool isActive, double balance);
    }
}
