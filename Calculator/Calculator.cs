namespace Calculator
{
    internal class Calculator
    {

             static void Main(string[] args)

             { 
                 Console.WriteLine("Simple Calculator");
                 Console.WriteLine("------------------");


                 Console.Write("Enter the first number: ");

                 double.TryParse(Console.ReadLine(), out var num1);

                 Console.Write("Enter the second number: ");
                 double.TryParse(Console.ReadLine(), out var num2);


                 Console.Write("Enter an operator (+, -, *, /): ");
                 char op = Console.ReadKey().KeyChar;
                 Console.WriteLine();


                 double result;

                 switch (op)
                 {
                     case '+':
                         result = num1 + num2;
                         Console.WriteLine($"Result: {num1} + {num2} = {result}");
                         break;

                     case '-':
                         result = num1 - num2;
                         Console.WriteLine($"Result: {num1} - {num2} = {result}");
                         break;

                     case '*':
                         result = num1 * num2;
                         Console.WriteLine($"Result: {num1} * {num2} = {result}");
                         break;

                     case '/':
                         if (num2 != 0)
                         {
                             result = num1 / num2;
                             Console.WriteLine($"Result: {num1} / {num2} = {result}");
                         }
                         else
                         {
                             Console.WriteLine("Error: Division by zero is not allowed.");
                         }
                         break;

                     default:
                         Console.WriteLine("Invalid operator. Please use +, -, *, or /.");
                         break;
                 }

                 Console.WriteLine("Press any key to exit...");
                 Console.ReadKey();
             }
         }
    }


