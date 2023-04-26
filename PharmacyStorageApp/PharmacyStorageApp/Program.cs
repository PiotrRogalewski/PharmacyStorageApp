using PharmacyStorageApp;

Console.BackgroundColor = ConsoleColor.DarkRed;
TextInColor(ConsoleColor.White,
    "______________________________________________________________________________________________________________________\n" +
    "                                                                                                                      \n" +
    $"                        ~~~~ (+) ~~~~       Welcome in PharmacyStorageApp!       ~~~~ (+) ~~~~                        \n" +
    "______________________________________________________________________________________________________________________\n" +
    "                                                                                                                      \n");
Console.ResetColor();

MedicinesInMemory medicinesInMemory = null;
string medicinesInStock = "0";
string putedMedicines = "Error! None";
string takedMedicines = "Error! None";
string savingMethod = "none";
var menu = "menu";
bool doNotBreakThisLoop = true;

TextInColor(ConsoleColor.DarkGreen, "    Please write your name to start this program, then click ENTER\n");
var user = Console.ReadLine();

while (doNotBreakThisLoop == true)
{
    TextInColor(ConsoleColor.DarkGreen, $"\n    Hello {user}!\n\n    Press ENTER once to go to saving method selection\n    or click 'c' , then press ENTER - if you want change your name in the program\n");
    var checkUserName = Console.ReadLine();

    if (checkUserName == "")
    {
        break;
    }
    else if (checkUserName == "c")  // changing user name
    {
        while (checkUserName == "c")
        {
            TextInColor(ConsoleColor.DarkGreen, "\n    Please write your name correctly, then click ENTER\n");
            user = Console.ReadLine();

            TextInColor(ConsoleColor.DarkGreen, $"\n    {user} - Is your name spelled correctly?\n\n    click 'y' or press ENTER once - if YES, then you will continue\n    click 'n' - if NO, then write your name again\n    then press ENTER");
            var checking = Console.ReadLine();

            if (checking == "y" || checking == "")
            {
                break;
                doNotBreakThisLoop = false;
            }
            else if (checking == "n")
            {
                continue;
            }
            else
            {
                TextInColor(ConsoleColor.Red, $"\n    Try again...\n");
                continue;
            }
        }
    }
    else
    {
        TextInColor(ConsoleColor.Red, $"\n    Try again...\n");
        continue;
    }
}

while (true)
{
    TextInColor(ConsoleColor.DarkGreen, $"    Please select the saving method:\n\n    click 'f' - saving to file\n    click 'm' - saving to program memory\n    then press ENTER to confirm");
    savingMethod = Console.ReadLine(); // saving method selection

    if (savingMethod == "m")
    {
        TextInColor(ConsoleColor.Yellow, $"\n    {user}, you are now operating in program memory.\n    Remember! This data will be lost when you close this console window.\n\n");
        NextStep();
        break;
    }
    else if (savingMethod == "f")
    {
        TextInColor(ConsoleColor.Yellow, $"\n    {user}, you are now operating on a file.\n    When you end adding or removing medicines your data will be saved to a file with chosen medicines category.\n\n");
        NextStep();
        break;
    }
    else
    {
        InvalidSelection($"{user}, try again!\n");
        continue;
    }
}

while (medicinesInMemory == null) // medications category selection
{
    TextInColor(ConsoleColor.DarkGreen, "    Please select which medications you want to: add / remove / check:\n");
    TextInColor(ConsoleColor.DarkGray, $"\n    click '1' to select:    painkillers\n    click '2' to select:    other tablets\n    click '3' to select:    syrups\n    click '4' to select:    suppositories\n    click '5' to select:    dressing\n    click '6' to select:    ointment\n    click '7' to select:    drops\n    click '8' to select:    supplements\n    then press ENTER to continue");
    var medicinesCategory = Console.ReadLine();

    switch (medicinesCategory)
    {
        case "1":
            TextInColor(ConsoleColor.Green, $"\n    {user}, you selected:  painkillers\n");
            medicinesInMemory = new MedicinesInMemory("painkillers", "solid", "blister", 24);
            NextStep();
            break;
        case "2":
            TextInColor(ConsoleColor.Green, $"\n    {user}, you selected:  other tablets\n");
            medicinesInMemory = new MedicinesInMemory("other tablets", "solid", "bl", 24);
            NextStep();
            break;
        case "3":
            TextInColor(ConsoleColor.Green, $"\n    {user}, you selected:  syrups\n");
            medicinesInMemory = new MedicinesInMemory("syrups", "liquid", "bottle", 1);
            NextStep();
            break;
        case "4":
            TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: suppositories\n");
            medicinesInMemory = new MedicinesInMemory("suppositories", "solid", "plastic cover", 10);
            NextStep();
            break;
        case "5":
            TextInColor(ConsoleColor.Green, $"\n    {user}, you selected:  dressing\n");
            medicinesInMemory = new MedicinesInMemory("dressing", "S", "protectivePackaging", 1);
            NextStep();
            break;
        case "6":
            TextInColor(ConsoleColor.Green, $"\n    {user}, you selected:  ointment\n");
            medicinesInMemory = new MedicinesInMemory("ointment", "s", "jar", 1);
            NextStep();
            break;
        case "7":
            TextInColor(ConsoleColor.Green, $"\n    {user}, you selected:  drops\n");
            medicinesInMemory = new MedicinesInMemory("drops", "l", "bwd", 1);
            NextStep();
            break;
        case "8":
            TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: supplements\n");
            medicinesInMemory = new MedicinesInMemory("supplements", "solid", "blister", 60);
            NextStep();
            break;
        default:
            InvalidSelection("Try again!");
            continue;
    }
}

var medicinesInFile = new MedicinesInFile($"{medicinesInMemory.CategoryName}", $"{medicinesInMemory.StateOfMatter}", $"{medicinesInMemory.TypeOfPackaging}", medicinesInMemory.TotalPackageCapacity);

string TextAsNumberForAdditionMethod()
{
    if (float.TryParse(putedMedicines, out float additionResult))
    {
        string additionResultForString = additionResult.ToString();
        putedMedicines = additionResultForString;
        return putedMedicines;
    }
    else if (putedMedicines is string)
    {
        switch (putedMedicines)
        {
            case "B" or "b":
                putedMedicines = "90";
                return putedMedicines;
            case "C" or "c":
                putedMedicines = "80";
                return putedMedicines;
            case "D" or "d":
                putedMedicines = "70";
                return putedMedicines;
            case "E" or "e":
                putedMedicines = "60";
                return putedMedicines;
            case "G" or "g":
                putedMedicines = "40";
                return putedMedicines;
            case "H" or "h":
                putedMedicines = "30";
                return putedMedicines;
            case "I" or "i":
                putedMedicines = "20";
                return putedMedicines;
            case "K" or "k":
                putedMedicines = "5";
                return putedMedicines;
            case "A" or "a" or "max" or "maximum" or "huge cardboard" or "huge" or "huge medicines cardboard" or "a huge box of medicines" or "a huge medicine box":
                putedMedicines = "100";
                return putedMedicines;
            case "F" or "f" or "large" or "big" or "big cardboard" or "big box" or "big medicines cardboard" or "a large box of medicines" or "a large medicine box":
                putedMedicines = "50";
                return putedMedicines;
            case "medium" or "medium cardboard" or "medium box" or "medium medicine carton" or "carton" or "cardboard" or "box" or "twenty five pieces" or "25 pieces" or "twenty-five":
                putedMedicines = "25";
                return putedMedicines;
            case "min" or "minimum" or "J" or "j" or "small" or "small cardboard" or "small box" or "ten pieces" or "10 pieces" or "ten":
                putedMedicines = "10";
                return putedMedicines;
            default:
                putedMedicines = "No";
                return putedMedicines;
        }
    }
    else
    {
        putedMedicines = "No";
        return putedMedicines;
    }
}

string TextAsNumberForRemovalMethod()
{
    if (float.TryParse(takedMedicines, out float removalResult))
    {
        var removedMeds = Math.Abs(removalResult);
        string removalResultForString = removedMeds.ToString();
        takedMedicines = removalResultForString;
        return takedMedicines;
    }
    else if (takedMedicines is string)
    {
        switch (takedMedicines)
        {
            case "L" or "l":
                takedMedicines = "1";
                return takedMedicines;
            case "M" or "m":
                takedMedicines = "5";
                return takedMedicines;
            case "N" or "n":
                takedMedicines = "10";
                return takedMedicines;
            case "O" or "o":
                takedMedicines = "20";
                return takedMedicines;
            default:
                takedMedicines = "No";
                return takedMedicines;
        }
    }
    else
    {
        takedMedicines = "No";
        return takedMedicines;
    }
}

void GetMedicinesInStock() // Determination of medicines is stock
{
    if (savingMethod == "m")
    {
        var statistics = medicinesInMemory.GetStatistics();
        var medicinesInStockAsFloat = statistics.AvailableMedications;
        medicinesInStock = medicinesInStockAsFloat.ToString();

    }
    else if (savingMethod == "f")
    {
        var statistics = medicinesInFile.GetStatistics();
        var medicinesInStockAsFloat = statistics.AvailableMedications;
        medicinesInStock = medicinesInStockAsFloat.ToString();
    }
}

// Events activation:
medicinesInMemory.MedicinesAdded += MedicinesAddedMessage;
medicinesInMemory.MedicationsRemoved += MedicationsRemovedMessage;

medicinesInFile.MedicinesAdded += MedicinesAddedMessage;
medicinesInFile.MedicationsRemoved += MedicationsRemovedMessage;

void MedicinesAddedMessage(object sender, EventArgs args)
{
    TextAsNumberForAdditionMethod();
    GetMedicinesInStock();
    TextInColor(ConsoleColor.Green, $"    {putedMedicines} new medicines added to the shelf!\n    In the storage area is {medicinesInStock} medicines in stock from the category of {medicinesInMemory.CategoryName}.");
}

void MedicationsRemovedMessage(object sender2, EventArgs args2)
{
    TextAsNumberForRemovalMethod();
    GetMedicinesInStock();
    TextInColor(ConsoleColor.Green, $"    {takedMedicines} medicines removed from the shelf!\n    In the storage area is {medicinesInStock} medicines in stock from the category of {medicinesInMemory.CategoryName}.");
}

void ShowMedicationDispositionStatistics() // All statistics
{
    GetMedicinesInStock();
    var statistics1 = medicinesInMemory.GetStatistics();
    var statistics2 = medicinesInFile.GetStatistics();

    TheLine();
    TextInColor(ConsoleColor.Yellow, "    Medication disposition statistics\n\n");
    TextInColor(ConsoleColor.DarkGreen, "                               Medicine Information:\n");
    TextInColor(ConsoleColor.Gray, $"    Category name:                {medicinesInMemory.CategoryName}\n\n    State of matter:              {medicinesInMemory.StateOfMatter}\n\n    Type of packaging:            {medicinesInMemory.TypeOfPackaging}\n\n    Total package capacity:       {medicinesInMemory.TotalPackageCapacity}\n\n");
    TextInColor(ConsoleColor.DarkGreen, "                               Statistics:\n");
    TextInColor(ConsoleColor.Green, $"    Medications in stock:         {medicinesInStock}\n");

    if (savingMethod == "m") // statistics - saving to memory
    {
        if (statistics1.MinimalAddition != float.MaxValue)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Minimal addition:             {statistics1.MinimalAddition}\n    Maximum addition:             {statistics1.MaximumAddition}");
        }
        else if (statistics1.MinimalAddition == float.MaxValue)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Minimal addition:             does not exist - no medications have been added\n    Maximum Addition:             does not exist - no medications have been added");

        }

        TextInColor(ConsoleColor.DarkGreen, $"    How many times added:         {statistics1.AddCounter}");

        if (statistics1.AverageOfAdditions >= 0 && statistics1.AverageOfAdditions <= 100)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Average of additions:         {statistics1.AverageOfAdditions}\n");
        }
        else
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Average of additions:         does not exist - no medications have been added\n");
        }

        if (statistics1.MinimalSubtraction == float.MinValue)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Minimal removal:              does not exist - no medications have been removed\n    Maximum removal:              does not exist - no medications have been removed");
        }
        else if (statistics1.MinimalSubtraction != float.MinValue)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Minimal removal:              {statistics1.MinimalSubtraction}\n    Maximum removal:              {statistics1.MaximumSubtraction}");
        }

        TextInColor(ConsoleColor.DarkGreen, $"    How many times removed:       {statistics1.SubtractionCounter}");

        if (statistics1.AverageOfSubtractions >= 1 && statistics1.AverageOfSubtractions <= 20)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Average of removals:          {statistics1.AverageOfSubtractions}\n");
        }
        else
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Average of removals:          does not exist - no medications have been removed\n");
        }
    }

    else if (savingMethod == "f") // statistics - saving to file
    {
        if (statistics2.MinimalAddition != float.MaxValue)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Minimal addition:             {statistics2.MinimalAddition}\n    Maximum addition:             {statistics2.MaximumAddition}\n");
        }
        else if (statistics2.MinimalAddition == float.MaxValue)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Minimal addition:             does not exist - no medications have been added\n    Maximum Addition:             does not exist - no medications have been added\n");

        }

        TextInColor(ConsoleColor.DarkGreen, $"    How many times added:         {statistics2.AddCounter}\n");

        if (statistics2.AverageOfAdditions >= 0 && statistics2.AverageOfAdditions <= 100)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Average of additions:         {statistics2.AverageOfAdditions}\n\n");
        }
        else
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Average of additions:         does not exist - no medications have been added\n\n");
        }

        if (statistics2.MinimalSubtraction == float.MinValue)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Minimal removal:              does not exist - no medications have been removed\n    Maximum removal:              does not exist - no medications have been removed\n");
        }
        else if (statistics2.MinimalSubtraction != float.MinValue)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Minimal removal:              {statistics2.MinimalSubtraction}\n    Maximum removal:              {statistics2.MaximumSubtraction}\n");
        }

        TextInColor(ConsoleColor.DarkGreen, $"    How many times removed:       {statistics2.SubtractionCounter}");

        if (statistics2.AverageOfSubtractions >= 1 && statistics2.AverageOfSubtractions <= 20)
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Average of removals:          {statistics2.AverageOfSubtractions}\n\n");
        }
        else
        {
            TextInColor(ConsoleColor.DarkGreen, $"    Average of removals:          does not exist - no medications have been removed\n\n");
        }
    }
    TheLine();
    NextStep();
}

while (menu != "x") // MAIN LOOP ( main menu >> [ all options ] )
{

    TheLine();
    TextInColor(ConsoleColor.White, $"\n    MAIN MENU");
    TextInColor(ConsoleColor.Yellow, $"    In this program you can manage your pharmacy storage area.\n");
    TextInColor(ConsoleColor.DarkGreen, "    If you want know more about limits for adding or removing medicines from shelfs of pharmacy storage area or\n    if you don't know how text value and letter value works, then you should read user manual or READMY file.\n\n");
    TextInColor(ConsoleColor.Yellow, $"    {user}, please select one of the options:\n\n      write '1' or 'add'      - to add new medicines to the pharmacy stroage area,\n      write '2' or 'remove'   - to remove medicines from the pharmacy storage area,\n      write '3' or 'check'    - to check statistics for selected category of medicines,\n      write '4' or 'd'        - to view short description of the program,\n      write '5' or 'm'        - to view user manual (information about text value, letter value and limitations),\n      write '6' or 'i'        - to view basic technical information about the PharmacyStroageApp\n\n      click 'x' - to exit the program\n\n      ... then press ENTER\n");
    TheLine();
    var selectOption = Console.ReadLine();

    string BackToMenu() // It is method for return to the main menu
    {
        while (true)
        {
            TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, do you want to return to the MAIN MENU? Please write:\n\n\n         'y' = for YES, then press ENTER / or just press ENTER once,\n\n         'n' or 'x' = for NO - exit the program, then press ENTER.\n");
            var toMenu = Console.ReadLine();

            if (toMenu == "y" || toMenu == "")
            {
                doNotBreakThisLoop = false;
                break;
            }
            else if (toMenu == "n" || toMenu == "x")
            {
                doNotBreakThisLoop = false;
                menu = "x";
                break;
            }
            else
            {
                InvalidSelection("");
                continue;
            }
        }
        return menu;
    }

    switch (selectOption)
    {
        case "1" or "add": // Add option
            
            TextInColor(ConsoleColor.Yellow, "\n    The action of adding new medicines to this storage area");
            TheLine();
            doNotBreakThisLoop = true;

            while (doNotBreakThisLoop == true)
            {
                TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, please enter the number of medicines (or write: text value or letter value) that you want add\n    on the shelf in the storage area, then click ENTER to continue.");
                TextInColor(ConsoleColor.DarkGray, "    If you want quit in any moment write 'q' then press ENTER - you will return to the main menu\n");
                putedMedicines = Console.ReadLine();

                if (putedMedicines == "q")
                {
                    ShowMedicationDispositionStatistics();
                    doNotBreakThisLoop = false;
                    break;
                }
                try
                {
                    if (savingMethod == "m")
                    {
                        medicinesInMemory.PutMedicineOnTheShelf(putedMedicines);
                        continue;
                    }
                    else if (savingMethod == "f")
                    {
                        medicinesInFile.PutMedicineOnTheShelf(putedMedicines);
                        continue;
                    }
                }
                catch (Exception exc)
                {
                    TextInColor(ConsoleColor.Red, $"\n    Exception detected!\n\n    {exc.Message}\n");
                    continue;
                }
            }
            break;

        case "2" or "remove": // Remove option
            
            TextInColor(ConsoleColor.Yellow, "\n    The action of remoing medicines from this storage area");
            TheLine();
            doNotBreakThisLoop = true;

            while (doNotBreakThisLoop == true)
            {
                TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, please enter the number of medicines (or write: text value or letter value) that you want remove\n    from the shelf in the storage area, then click ENTER to continue.");
                TextInColor(ConsoleColor.DarkGray, "    If you want quit in any moment write 'q' then press ENTER - you will return to the main menu\n");
                takedMedicines = Console.ReadLine();

                if (takedMedicines == "q")
                {
                    ShowMedicationDispositionStatistics();
                    doNotBreakThisLoop = false;
                    break;
                }
                try
                {
                    if (savingMethod == "m")
                    {
                        medicinesInMemory.TakeTheMedicineFromTheShelf(takedMedicines);
                    }
                    else if (savingMethod == "f")
                    {
                        medicinesInFile.TakeTheMedicineFromTheShelf(takedMedicines);
                    }
                }
                catch (Exception exc)
                {
                    TextInColor(ConsoleColor.Red, $"\n    Exception detected!\n\n    {exc.Message}\n");
                    continue;
                }
            }
            break;

        case "3" or "check":    // Check option - it show statistics and informations about selected medicines category

            TextInColor(ConsoleColor.Yellow, "\n    Action of checking statistics and informations about selected medicines category.");
            ShowMedicationDispositionStatistics();
            break;

        case "4" or "d":       // DESCRIPTION OF THE PROGRAM

            TextInColor(ConsoleColor.White, "    DESCRIPTION OF THE PROGRAM:\n\n");
            TextInColor(ConsoleColor.Gray, $"      In the PharmacyStorageApp you may manage a small pharmacy storage area. This application allows you to add\n    medicines to the pharmacy storage area or remove it from this area. You can also check how many medicines\n    from specific category is there. {user}, you are able to save a data in the file or save\n    it to the program memory. Everytime you will end adding or removing process, you will see\n    statistics from all actions on a given medicine category.\n\n    For more information read User manual or READMY file.\n\n");
            NextStep();
            BackToMenu();
            break;

        case "5" or "m":       // USER MANUAL
            TextInColor(ConsoleColor.White, "\n    USER MANUAL:\n\n");
            TextInColor(ConsoleColor.Gray, "    Not completed...\n    Remember! You can't remove more then 20 pieces, it's limited. If you remove some medicine it must be minimum 0,01 piece.\n");
            NextStep();
            BackToMenu();
            break;

        case "6" or "i":       // BASIC INFO ABOUT APP

            TextInColor(ConsoleColor.DarkGreen, "\n    Basic technical information about the PharmacyStorageApp:\n");
            TextInColor(ConsoleColor.DarkGray, "        This console app is written by  Piotr Rogalewski  in Visual studio 2022 (Microsoft) on the .NET 7.0 platform. \n    Programming language is C#. \n\n"); // The application was completed on April ..., 2023.
            NextStep();
            BackToMenu();
            break;

        case "x":       // EXIT
            menu = "x";
            break;

        default:
            InvalidSelection("You will return to the MAIN MENU");
            break;
    }
}

static void InvalidSelection(string text)
{
    TextInColor(ConsoleColor.Red, $"    Invalid selection! For more information check READMY file.\n    {text}");
}

static void NextStep()
{
    TextInColor(ConsoleColor.DarkGray, $"    Press ENTER to continue...");
    var nextStep = Console.ReadLine();

    while (nextStep != "")
    {
        TextInColor(ConsoleColor.Red, "\n    Error! Press only ENTER to continue.\n");
        nextStep = Console.ReadLine();
    }
}

static void TextInColor(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

static void TheLine()
{
    TextInColor(ConsoleColor.Yellow, "\n______________________________________________________________________________________________________________________\n");
}

TextInColor(ConsoleColor.Green, $"\n    See you next time! :)\n");
TextInColor(ConsoleColor.DarkRed, "______________________________________________________________________________________________________________________\n" +
    "\n                                        Press any button to EXIT the program\n______________________________________________________________________________________________________________________\n                                                                                                                      \n");
//    I'm sorry for my english, and I hope you will like this console app! :)  P.R.