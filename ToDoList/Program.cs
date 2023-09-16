using System.Xml;

string userChoice;
List<string> listOfTODOS = new List<string>();

Console.WriteLine("Hello!");

do
{
    
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    userChoice = Console.ReadLine();
    userChoice = userChoice.ToUpper();

    if (userChoice == "S")
    {
        SeeAllTODOs(listOfTODOS);
    }

    else if (userChoice == "A")
    {
        Console.WriteLine();
        Console.WriteLine("Enter the TODO description: ");
        var descriptionOfTODO = Console.ReadLine();
        descriptionOfTODO = IfDescriptionOfTodoIsEmpty(descriptionOfTODO);
        descriptionOfTODO = IfDescriptionOfTodoNotUnique(descriptionOfTODO, listOfTODOS);
        listOfTODOS = AddTODO(listOfTODOS, descriptionOfTODO);
    
    }
    else if (userChoice == "R")
    { 
        listOfTODOS = RemoveTODO(listOfTODOS);
    }
    else if (userChoice != "E")
    {
        Console.WriteLine();
        Console.WriteLine("Incorrect input");
        Console.WriteLine();
    }
} while (userChoice != "E");

Console.ReadKey();



void SeeAllTODOs(List<string> listOfTODOS)
{
    if (listOfTODOS.Count == 0)
    {
        Console.WriteLine();
        Console.WriteLine("No TODOs have been added yet.");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
        for (int i = 0; i < listOfTODOS.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {listOfTODOS[i]}");
        }
        Console.WriteLine();
    }
}

List<string> AddTODO(List<string> listOfTODOS, string descriptionOfTODO)
{
    listOfTODOS.Add(descriptionOfTODO);
    Console.WriteLine();
    Console.WriteLine("TODO successfully added: " + descriptionOfTODO);
    Console.WriteLine();
    return listOfTODOS;
}
bool IsDescriptionOfTodoEmpty(string descriptionOfTODO)
{
    //no need for method, convert to bool variable in If method
    if (descriptionOfTODO.Length == 0)
    {
        return true;
    }
    return false;
}

bool IsDescriptionOfTodoNotUnique(List<string> listOfTODOS, string descriptionOfTODO)
{
    //no need for method, convert to bool variable in If method
    if (listOfTODOS.Contains(descriptionOfTODO))
    {
        return true;
    }
    return false;
}

string IfDescriptionOfTodoIsEmpty(string descriptionOfTODO)
{
    do
    {

        if (IsDescriptionOfTodoEmpty(descriptionOfTODO))
        {
            Console.WriteLine();
            Console.WriteLine("The description cannot be empty.");
            Console.WriteLine("Enter the TODO description: ");
            descriptionOfTODO = Console.ReadLine();
        }
        else
        {
            break;
        }
    } while (true);
    return descriptionOfTODO;
}

string IfDescriptionOfTodoNotUnique(string descriptionOfTODO, List<string> listOfTODOS)
{
    do
    {
        if (IsDescriptionOfTodoNotUnique(listOfTODOS, descriptionOfTODO))
        {
            Console.WriteLine();
            Console.WriteLine("The description must be unique.");
            Console.WriteLine("Enter the TODO description: ");
            descriptionOfTODO = Console.ReadLine();
            descriptionOfTODO = IfDescriptionOfTodoIsEmpty(descriptionOfTODO);
        }
        else
        {
            break;
        }
    } while (true);
    return descriptionOfTODO;
}

List<string> RemoveTODO(List<string> listOfTODOS)
{
    if (listOfTODOS.Count == 0)
    {
        Console.WriteLine();
        Console.WriteLine("No TODOs have been added yet.");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Select the index of the TODO you want to remove: ");
        for (int i = 0; i < listOfTODOS.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {listOfTODOS[i]}");
        }
        Console.WriteLine();
        var indexByUser = Console.ReadLine();
        indexByUser = IfIndexEmpty(indexByUser);
        int actualIndex = IfIndexInvalid(indexByUser, listOfTODOS);
        var removedTODO = listOfTODOS[actualIndex]; 
        listOfTODOS.RemoveAt(actualIndex);
        Console.WriteLine("TODO removed: " + removedTODO);
    }
    return listOfTODOS;
}
string IfIndexEmpty (string indexByUser)
{
    do
    {
        if (indexByUser.Length == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Selected index cannot be empty.");
            Console.WriteLine("Select the index of the TODO you want to remove: ");
            indexByUser = Console.ReadLine();
        }
        else
        {
            break;
        }
    } while (true);
    return indexByUser;
}

int IfIndexInvalid(string indexByUser, List<string> listOfTODOS)
{
    int indexParsedToInt;
   
   
   do
    {
        bool isParsed = int.TryParse(indexByUser, out indexParsedToInt);
        if (!(isParsed && indexParsedToInt > 0 && indexParsedToInt <= listOfTODOS.Count))
        {
            Console.WriteLine();
            Console.WriteLine("The given index is not valid.");
            Console.WriteLine("Select the index of the TODO you want to remove: ");
            indexByUser = Console.ReadLine();
            indexByUser = IfIndexEmpty(indexByUser);
        }
        else
        {
            break;
        }
      
    } while (true);
    return indexParsedToInt - 1;
}