using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeBankStatements;

public class ThisBank
{
    public string AccountType { get; set; }
    public string AccountNumber { get; set; }
    public string TransactionDate { get; set; }
    public string ChequeNumber { get; set; } = null;
    public string Description1 { get; set; }
    public string Description2 { get; set; }
    public string WithdrawalCAD { get; set; }
    public string WithdrawalUSD { get; set; } = null;

}
