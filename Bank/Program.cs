using System;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFinanceOperations bank = new Bank();
            IFinanceOperations microFinance = new MicroFinance();

            Console.WriteLine("Input months");
            int months = int.Parse(Console.ReadLine());

            Console.WriteLine("Input amount per month");
            double AmountPerMonth = double.Parse(Console.ReadLine());

            bank.CalculateLoanPercent(months, AmountPerMonth);
            microFinance.CalculateLoanPercent(months, AmountPerMonth);
        }

        interface IFinanceOperations
        {
            void CalculateLoanPercent(int month, double AmountPerMonth);
            bool CheckUserHistory();
        }
        public class Bank : IFinanceOperations
        {
            public Random random = new Random();

            public bool CheckUserHistory()
            {
                return random.Next(0, 2) == 1; // 1 = true, 0 = false, 
            }
            public void CalculateLoanPercent(int month, double AmountPerMonth)
            {
                if (CheckUserHistory())
                {
                    double totalLoan = AmountPerMonth * month;
                    double fee = totalLoan * 0.05; // 5% საკომისიო
                    double amountToPay = totalLoan + fee;

                    Console.WriteLine($"Amount to pay after {month} months is {amountToPay}");
                }
                else
                    Console.WriteLine("Bank user history check failed. Loan is not approved.");
            }
        }
        public class MicroFinance : IFinanceOperations
        {
            public bool CheckUserHistory()
            {
                return true;
            }
            public void CalculateLoanPercent(int month, double AmountPerMonth)
            {
                double totalLoan = AmountPerMonth * month;
                double fee = totalLoan * 0.10; // 10% საკომისიო
                double serviceFee = 4 * month; // 4 დოლარიანი საკომისიო ყოველთვიურად
                double amountToPay = totalLoan + fee + serviceFee;

                Console.WriteLine($"Amount to pay after {month} months is {amountToPay}");
            }
        }
    }
}
