namespace CategorizeBankStatements;

internal class Program
{
    static void Main(string[] args)
    {
        string csvPath = "1827309_BS.csv";
        string[] lines = File.ReadAllLines(@"../../../CSV_Files/" + csvPath).Skip(1).ToArray();

        List<ThisBank> transactions = new List<ThisBank>();

        foreach (string line in lines)
        {
            string[] columns = line.Split(',');
            ThisBank transaction = new ThisBank
            {
                AccountType = columns[0],
                AccountNumber = columns[1],
                TransactionDate = columns[2],
                ChequeNumber = columns[3],
                Description1 = columns[4],
                Description2 = columns[5],
                WithdrawalCAD = columns[6],
                WithdrawalUSD = columns[7]
            };
            transactions.Add(transaction);
        }

        //Console.WriteLine(string.Join("\n", transactions.Select(transaction => $"{transaction.TransactionDate}: {transaction.Description1} {transaction.Description2}:  {transaction.WithdrawalCAD:C2}")) );

        var categories = transactions.Select(transaction => Categorizer.CategorizeTransaction(transaction));

        foreach (var category in categories)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(category.Item1);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(category.Item2);

            Console.ResetColor();
        }
    }
}
