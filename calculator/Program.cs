using System;
using System.IO;

class Calculator
{
    // Main
    static void Main(string[] args)
    {
        
        CalculatorOperations calc = new CalculatorOperations();
        calc.DisplayMenu();
    }
}

class CalculatorOperations
{
    // გამოტანა
    public void DisplayMenu()
    {
        string[] operations = { "+", "-", "*", "/" };
        double[] numbers = new double[2];
        string operation;

        // შეტანა
        Console.Write("Enter the first number: ");
        numbers[0] = GetValidNumber();

        Console.Write("Enter the second number: ");
        numbers[1] = GetValidNumber();

        
        do
        {
            Console.Write("Choose an operation (+, -, *, /): ");
            operation = Console.ReadLine();
        } while (Array.IndexOf(operations, operation) == -1);

        // კალკულაცია
        double result = PerformCalculation(numbers, operation);

        // შედეგი
        Console.WriteLine($"Result: {result}");

        // ფაილში შენახვა
        SaveResultToFile(result);
    }

    // ვალიდური პასუხის მიღება მომხმარებლისგან 
    private double GetValidNumber()
    {
        double number;
        while (!double.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Error: Please enter a valid number.");
        }
        return number;
    }

    //კალკულაცია
    public double PerformCalculation(double[] numbers, string operation)
    {
        double result = 0;

        switch (operation)
        {
            case "+":
                result = numbers[0] + numbers[1];
                break;
            case "-":
                result = numbers[0] - numbers[1];
                break;
            case "*":
                result = numbers[0] * numbers[1];
                break;
            case "/":
                if (numbers[1] != 0)
                {
                    result = numbers[0] / numbers[1];
                }
                else
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                }
                break;
        }
        return result;
    }

    // ფაილში შენახვა
    private void SaveResultToFile(double result)
    {
        string fileName = "calculation_result.txt";

        // ფაილში ჩაწერა
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Calculation Result: {result}");
            writer.WriteLine($"Date: {DateTime.Now}");
        }

        Console.WriteLine("Result has been saved to 'calculation_result.txt'.");
    }
}

