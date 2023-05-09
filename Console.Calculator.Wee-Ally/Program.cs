class Program
{
    static void Main(string[] args)
    {
        var endApp = false;

        Console.WriteLine("Console Calculator");
        Console.WriteLine("--------------\n");

        while (!endApp)
        {
            Console.Write("Type a number, then press Enter: ");
            var numInput1 = Console.ReadLine();

            double cleanNum1 = 0;

            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not a valid input. Please enter");
                numInput1 = Console.ReadLine();
            }

            Console.Write("Type another number, then press Enter: ");
            var numInput2 = Console.ReadLine();

            double cleanNum2 = 0;

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

            var op = Console.ReadLine();

            try
            {
                var result = Calculator.DoCalculation(cleanNum1, cleanNum1, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This calculation will result in a mathematical error. \n");
                }
                Console.WriteLine($"Your result: {result}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math. \n - Details " + e.Message);
            }

            Console.WriteLine("-------------------------\n");
            Console.WriteLine();

            Console.WriteLine("Press 'x' to exit, otherwise press any key to keep playing");
            if (Console.ReadLine() == "x") endApp = true;
        }
        return;
    }
}

internal class Calculator
{
    public static double DoCalculation(double num1, double num2, string op)
    {
        double result = double.NaN;

        switch (op)
        {
            case "a":
                result = num1 + num2; break;
            case "s":
                result = num1 - num2; break;
            case "m":
                Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 * num2)); break;
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