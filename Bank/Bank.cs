namespace Bank
{
    internal class Program1
    {
        class BankAccount
 {
           // Account properties;
     public string AccountHolder;
     public double Balance;

              // Constructor to create an account
             public BankAccount(string accountHolder, double initialDeposit)
             {
                 AccountHolder = accountHolder;
                 Balance = initialDeposit;
                 Console.WriteLine($"\nAccount created for {AccountHolder} with an initial balance of {Balance:C}.");
             }

               //Deposit method
             public void Deposit(double amount)
             {
                 Balance += amount;
                 Console.WriteLine($"Deposited {amount:C}. New Balance: {Balance:C}");
             }

               //Withdraw method
             public void Withdraw(double amount)
             {
                 if (amount <= Balance)
                 {
                     Balance -= amount;
                     Console.WriteLine($"Withdrew {amount:C}. New Balance: {Balance:C}");
                 }
                 else
                 {
                     Console.WriteLine("Insufficient balance for this withdrawal.");
                 }
             }

              // Check balance method
             public void CheckBalance()
             {
                 Console.WriteLine($"Current Balance: {Balance:C}");
             }
         }
         class Program
         {
             static void Main(string[] args)
             {
                 Console.WriteLine("Welcome to the Bank Simulator!");

                   //Create a bank account
                 Console.Write("\nEnter your name: ");
                 string name = Console.ReadLine();
                 Console.Write("Enter an initial deposit amount: ");
                 double initialDeposit = Convert.ToDouble(Console.ReadLine());

                 BankAccount account = new BankAccount(name, initialDeposit);

                   //Simple menu
                 while (true)
                 {
                     Console.WriteLine("\nChoose an option:");
                     Console.WriteLine("1. Deposit Money");
                     Console.WriteLine("2. Withdraw Money");
                     Console.WriteLine("3. Check Balance");
                     Console.WriteLine("4. Exit");
                     Console.Write("Your choice: ");
                     int choice = Convert.ToInt32(Console.ReadLine());

                     switch (choice)
                     {
                         case 1:  
                             Console.Write("Enter the amount to deposit: ");
                             double depositAmount = Convert.ToDouble(Console.ReadLine());
                             account.Deposit(depositAmount);
                             break;

                         case 2:  
                             Console.Write("Enter the amount to withdraw: ");
                             double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                             account.Withdraw(withdrawAmount);
                             break;

                         case 3:  
                             account.CheckBalance();
                             break;

                         case 4:  
                             Console.WriteLine("Thank you for using the Bank Simulator. Goodbye!");
                             return;

                         default:
                             Console.WriteLine("Invalid choice. Please try again.");
                             break;
                     }
                 }
             }
         }
    }
}
