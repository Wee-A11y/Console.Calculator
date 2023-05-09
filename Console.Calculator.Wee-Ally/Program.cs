class Program
{
    private static void Main()
    {
        var history = new List<string>();

        var count = 0;
        var endApp = false;

        Console.WriteLine("Console Calculator");
        Console.WriteLine("--------------\n");

        while (!endApp)
        {
            Console.Write("Type a number, then press Enter: ");
            var numInput1 = Console.ReadLine();

            double cleanNum1;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not a valid input. Please enter");
                numInput1 = Console.ReadLine();
            }

            Console.Write("Type another number, then press Enter: ");
            var numInput2 = Console.ReadLine();

            double cleanNum2;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not a valid input. Please enter");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine(@"Choose an option from the following:
                a - Add
                s - Subtract
                m - Multiply
                d - Divide");
            Console.Write("Your option? ");
            count++;

            var op = Console.ReadLine();

            try
            {
                var result = Calculator.DoCalculation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This calculation will result in a mathematical error. \n");
                }
                AddHistory.History(cleanNum1, cleanNum2, op, result, history);
                Console.WriteLine($"Your result: {result}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math. \n - Details " + e.Message);
            }

            
            Console.WriteLine("-------------------------\n");
            Console.WriteLine();
            Console.WriteLine($"You have used the calculator {count} times \n");
            
            GetHistory.ReturnHistory(history);

            Console.WriteLine("Press 'x' to exit, otherwise press any key to keep playing");
            if (Console.ReadLine() == "x") endApp = true;
        }
    }
}

internal class AddHistory
{
    public static void History(double num1, double num2, string op, double result, List<string> history)
    {
        var type = op switch
        {
            "a" => "+",
            "s" => "-",
            "d" => "/",
            "m" => "*",
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };
        
        history.Add($"{DateTime.Now} : {num1} {type} {num2} = {result}");
    }
}

internal class GetHistory
{
    internal static void ReturnHistory(List<string> history)
    {
        Console.WriteLine();
        Console.WriteLine("Calculator History");
        Console.WriteLine("----------------------\n");
        foreach (var h in history)
        {
            Console.WriteLine(h);
        }
        Console.WriteLine();
        Console.WriteLine("----------------------\n");
    }
}

internal class Calculator
{
    public static double DoCalculation(double num1, double num2, string op)
    {
        var result = double.NaN;

        switch (op)
        {
            case "a":
                result = num1 + num2; break;
            case "s":
                result = num1 - num2; break;
            case "m":
                result = num1 * num2; break;
            case "d":
                if (num2 != 0)
                {
                    result = num2 / num1;
                    break;
                }
                Console.WriteLine("Enter a non-zero divisor");
                num2 = Convert.ToInt32(Console.ReadLine());
                break;
        }
        return result;
    }
}