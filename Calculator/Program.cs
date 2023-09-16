Console.WriteLine("Hello!");
Console.WriteLine("Input the first number:");

int firstNumber = InputNumbers();

Console.WriteLine("Input the second number:");
int secondNumber = InputNumbers();

Console.WriteLine("What do you want to do with those numbers?\n" +
    "[A]dd\n" +
    "[S]ubtract\n" +
    "[M]ultiply\n");

string userChoice = Console.ReadLine();

OperationAndResult(firstNumber, secondNumber, userChoice);

int InputNumbers()
{
    string input = Console.ReadLine();
    int number = int.Parse(input);
    return number;
}

void OperationAndResult (int firstOperand , int secondOperand, string operation)
{
    int result = 0 ;
    if (operation == "A" || operation == "a")
    {
        result = firstOperand + secondOperand;
        Console.WriteLine(firstOperand + " + " + secondOperand + " = " + result);
    }
    else if (operation == "S" || operation == "s")
    {
        result = firstOperand - secondOperand;
        Console.WriteLine(firstOperand + " - " + secondOperand + " = " + result);
    }

    else if (operation == "M" || operation == "m")
    {
        result = firstOperand * secondOperand;
        Console.WriteLine(firstOperand + " * " + secondOperand + " = " + result);
    }

    else
    {
        Console.WriteLine("Invalid option");
    }

    Console.WriteLine("Press any key to close");

}

Console.ReadKey(); 