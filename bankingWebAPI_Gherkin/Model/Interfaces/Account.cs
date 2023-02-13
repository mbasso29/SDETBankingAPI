using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankingWebAPI_Gherkin.Model.Interfaces;

namespace bankingWebAPI_Gherkin.Model.Interfaces
{
    public interface Account
    {
        AccountManager Account { get; }
    }
}
