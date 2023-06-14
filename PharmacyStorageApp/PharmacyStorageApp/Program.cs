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
    TextInColor(ConsoleColor.DarkGreen, $"\n    Hello {user}!\n\n    Tip: Expand to the bottom this console window to have better view.\n\n    Press ENTER once to go to the saving method selection,\n    or click 'c' , then press ENTER - if you want change your name in the program,\n    or click 'm' , then press ENTER - if you want read the User manual.\n");
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
        break;
    }
    else if (checkUserName == "m") // user manual
    {
        UserManual();
        continue;
    }
    else
    {
        TextInColor(ConsoleColor.Red, $"\n    Try again...\n");
        continue;
    }
}

while (true)
{
    TextInColor(ConsoleColor.DarkGreen, $"    Please select the saving method:\n\n    click 'm' - saving to the program memory\n    click 'f' - saving to the file\n    then press ENTER to confirm");
    savingMethod = Console.ReadLine(); // saving method selection

    if (savingMethod == "m")
    {
        TextInColor(ConsoleColor.Yellow, $"\n    {user}, you are now operating in the program memory.\n    Remember! This data will be lost when you close this console window.\n\n");
        NextStep();
        break;
    }
    else if (savingMethod == "f")
    {
        TextInColor(ConsoleColor.Yellow, $"\n    {user}, you are now operating on the file.\n    When you end adding or removing medicines your data will be saved to a file with chosen medicines category.\n\n");
        NextStep();
        break;
    }
    else
    {
        InvalidSelection($"Try again!");
        continue;
    }
}

while (medicinesInMemory == null) // medications category selection
{
    TextInColor(ConsoleColor.DarkGreen, "    Please select which medications you want to: add / remove / check:\n");
    TextInColor(ConsoleColor.DarkGray, $"\n    click '1' to select:    painkillers\n    click '2' to select:    other tablets\n    click '3' to select:    syrups\n    click '4' to select:    suppositories\n    click '5' to select:    dressing\n    click '6' to select:    ointment\n    click '7' to select:    drops\n    click '8' to select:    supplements\n\n    then press ENTER to continue");
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
    else if (putedMedicines != null)
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
    else if (takedMedicines != null)
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

void GetMedicinesInStock() // Determination of medicines in stock
{
    var statistics = medicinesInMemory.GetStatistics();

    if (savingMethod == "f")
    {
        statistics = medicinesInFile.GetStatistics();
    }

    var medicinesInStockAsFloat = statistics.AvailableMedications;
    medicinesInStock = medicinesInStockAsFloat.ToString("F2");
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
    var statistics1 = medicinesInMemory.GetStatistics();
    var statistics2 = medicinesInFile.GetStatistics();
    var statistics = statistics1;

    if (savingMethod == "f")
    {
        statistics = statistics2;
    }

    var medicinesInStockAsFloat = statistics.AvailableMedications;
    medicinesInStock = medicinesInStockAsFloat.ToString("F2");

    TheLine();
    TextInColor(ConsoleColor.Yellow, "    Medication disposition statistics\n\n");
    TextInColor(ConsoleColor.DarkGreen, "                               Medicine Information:\n");
    TextInColor(ConsoleColor.Gray, $"    Category name:                {medicinesInMemory.CategoryName}\n\n    State of matter:              {medicinesInMemory.StateOfMatter}\n\n    Type of packaging:            {medicinesInMemory.TypeOfPackaging}\n\n    Total package capacity:       {medicinesInMemory.TotalPackageCapacity}\n\n");
    TextInColor(ConsoleColor.DarkGreen, "                               Statistics:\n");
    TextInColor(ConsoleColor.Green, $"    Medications in stock:         {medicinesInStock}\n");

    if (statistics.MinimalAddition != float.MaxValue)
    {
        TextInColor(ConsoleColor.DarkGreen, $"    Minimal addition:             {statistics.MinimalAddition}\n    Maximum addition:             {statistics.MaximumAddition}");
    }
    else if (statistics.MinimalAddition == float.MaxValue)
    {
        TextInColor(ConsoleColor.DarkGreen, $"    Minimal addition:             does not exist - no medications has been added so far\n    Maximum Addition:             does not exist - no medications has been added so far");

    }

    TextInColor(ConsoleColor.DarkGreen, $"    How many times added:         {statistics.AddCounter}");

    if (statistics.AverageOfAdditions >= 0 && statistics.AverageOfAdditions <= 100)
    {
        TextInColor(ConsoleColor.DarkGreen, $"    Average of additions:         {statistics.AverageOfAdditions}\n");
    }
    else
    {
        TextInColor(ConsoleColor.DarkGreen, $"    Average of additions:         does not exist - no medications has been added so far\n");
    }
    TextInColor(ConsoleColor.DarkGray, $"    Average of addition as text:  {statistics.AverageOfAdditionsAsText}\n");

    if (statistics.MinimalSubtraction == float.MinValue)
    {
        TextInColor(ConsoleColor.DarkGreen, $"    Minimal removal:              does not exist - no medications has been removed so far\n    Maximum removal:              does not exist - no medications has been removed so far");
    }
    else if (statistics.MinimalSubtraction != float.MinValue)
    {
        TextInColor(ConsoleColor.DarkGreen, $"    Minimal removal:              {statistics.MinimalSubtraction}\n    Maximum removal:              {statistics.MaximumSubtraction}");
    }

    TextInColor(ConsoleColor.DarkGreen, $"    How many times removed:       {statistics.SubtractionCounter}");

    if (statistics.AverageOfRemoval >= 1 && statistics.AverageOfRemoval <= 20)
    {
        TextInColor(ConsoleColor.DarkGreen, $"    Average of removals:          {statistics.AverageOfRemoval}\n");
    }
    else
    {
        TextInColor(ConsoleColor.DarkGreen, $"    Average of removals:          does not exist - no medications has been removed so far\n");
    }

    if (statistics.AverageOfRemovalAsLetter != 'u')
    {
        TextInColor(ConsoleColor.DarkGray, $"    Average of removal as letter: {statistics.AverageOfRemovalAsLetter}\n");
    }
    else
    {
        TextInColor(ConsoleColor.DarkGray, $"    Average of removal as letter: undefined\n");
    }

    TheLine();
    NextStep();
}

while (menu != "x") // MAIN LOOP ( main menu >> [ all options ] )
{

    TheLine();
    string smallMenu = "main menu";
    string largeMenu = smallMenu.ToUpper();
    TextInColor(ConsoleColor.White, $"\n    {largeMenu}");
    TextInColor(ConsoleColor.Yellow, $"    In this program you can manage your pharmacy storage area.\n");
    TextInColor(ConsoleColor.DarkGreen, "    If you want know more about limits for adding or removing medicines from shelfs of pharmacy storage area or\n    if you don't know how text value and letter value works, then you should read user manual or READMY file.\n\n");
    TextInColor(ConsoleColor.Yellow, $"    {user}, please select one of the options:\n\n      write '1' or 'add'      - to add new medicines to the pharmacy stroage area,\n      write '2' or 'remove'   - to remove medicines from the pharmacy storage area,\n      write '3' or 'check'    - to check statistics for selected category of medicines,\n      write '4' or 'd'        - to view short description of the program,\n      write '5' or 'm'        - to view user manual (information about text value, letter value and limitations),\n      write '6' or 'i'        - to view basic technical information about the PharmacyStroageApp\n      click 'x'               - to exit the program\n\n      ... then press ENTER\n");
    TheLine();
    var selectOption = Console.ReadLine();

    string BackToMenu() // It is method for return to the main menu or to exit the program
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
                TextInColor(ConsoleColor.DarkGray, "    If you want quit: write 'q' and press ENTER - you will see statistics, next you return to the main menu.");
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

            TextInColor(ConsoleColor.Yellow, "\n    The action of removing medicines from this storage area");
            TheLine();
            doNotBreakThisLoop = true;

            while (doNotBreakThisLoop == true)
            {
                TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, please enter the number of medicines (or write: text value or letter value) that you want remove\n    from the shelf in the storage area, then click ENTER to continue.");
                TextInColor(ConsoleColor.DarkGray, "    If you want quit: write 'q' and press ENTER - you will see statistics, next you return to the main menu.\n");
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

            TextInColor(ConsoleColor.Yellow, "\n    The action of checking statistics and informations about selected medicines category");
            ShowMedicationDispositionStatistics();
            break;

        case "4" or "d":       // DESCRIPTION OF THE PROGRAM

            TextInColor(ConsoleColor.White, "    DESCRIPTION OF THE PROGRAM:\n\n");
            TextInColor(ConsoleColor.Gray, $"      In the PharmacyStorageApp you may manage a small pharmacy storage area. This application allows you to add\n    medicines to the pharmacy storage area or remove it from this area. You can also check how many medicines\n    from specific category is there. {user}, at the beginning you have to choose one of the saving methods:\n    save a data in the file or save it to the program memory. If you want to save your data for the future you\n    should always select saving to the file (write 'f' in selecting menu). Everytime you will end adding or\n    removing process, or if you choose check option - you will see statistics from all actions on a choosen\n    medicines category. The program calculates statistics on a regular basis.\n\n    For more information read User manual or READMY file.\n\n");
            NextStep();
            BackToMenu();
            break;

        case "5" or "m":       // USER MANUAL

            UserManual();
            BackToMenu();
            break;

        case "6" or "i":       // BASIC INFO ABOUT APP

            TextInColor(ConsoleColor.DarkGreen, "\n    Basic technical information about the PharmacyStorageApp:\n");
            TextInColor(ConsoleColor.DarkGray, "        This console app was written by  Piotr Rogalewski  in Visual studio 2022 (Microsoft) on the .NET 7.0 platform\n    in 2023. Programming language is C#. \n\n");
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
    TextInColor(ConsoleColor.Red, $"    Invalid selection! {text}\n");
}

static void NextStep()
{
    TextInColor(ConsoleColor.DarkGreen, $"    Press ENTER to continue...");
    var nextStep = Console.ReadLine();

    while (nextStep != "")
    {
        TextInColor(ConsoleColor.Red, "\n    Press only ENTER to continue.\n");
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

static void UserManual()
{
    TextInColor(ConsoleColor.White, "\n    USER MANUAL:\n\n");
    TextInColor(ConsoleColor.Gray,
        "\n    1. Limits\r\n\r\n\tAll categories of medicines have upper limit of quantity. This upper limit is 600 packages/pieces for\r\n\teach category separately. Lower limit is 0. So for example: if storage has 0 syrups then you are not\r\n\tallowed to dispense more, if stroage has 600 syrups then no more can be added. If you try to do this\r\n\tprogram show you message about prohibited action and adding/removing action will be failed. As a result\r\n\tmedicines in stock will has still this same quantity value then before action. This means that\r\n\tthe range of available quantity is from 0 to 600 pieces. \r\n       \r\n\tMore about what happens if you are close to the lower or upper limit can be found below." +
        "\r\n\r\n    2. Storage - Action of adding new medicines to the storage area:\r\n     \r\n\tYou can add new medicines to the storage area in the main menu when you choose Add option by writing \r\n\t'add' or '1' and then pressing Enter. Usually you may add from the range of 1-100 pieces (pcs) at once. \r\n\tThere are some exceptions. This exceptions appears when you choosed saving to the file and you are close\r\n\tto upper limit while adding. When you have 500 medicines in stock you are still able to add 1-100 pcs, \r\n\tbut if you have 501-550 meds in your storage area then you can only add 1-50 pcs at once. When there is\r\n\t551-575 medicines then you may add 1-25 pcs. In case in this stroage area is 576-590 meds then you can add\r\n\t1-10 pcs. Last exception for adding medications is when you have 591-599 medicines in stock, then you may\r\n\tadd only 1 pcs at once. The closer you are to the upper limit, the less you can add. " +
        "\r\n\r\n    3. Dispensing - Action of removing from the storage area:\r\n\r\n\tIn case you want to remove medicines from the storage area you should choose Remove option in the main menu\r\n\tby writing 'remove' or '2' and then pressing ENTER. If your selection at the beginning was saving to \r\n\tthe program memory then you may remove 0,1 - 20 medicines at once. When your selection was saving to \r\n\tthe file then you may also remove 0,1 - 20 medcines at once but if you are close to 0 medicines in stock \r\n\tthis range is changing. In case in the storage area is 10-19 medicines you can remove 0,1 - 10 meds at once. \r\n\tIf there is 5 - 9 medicines then you can remove 0,1 - 5. In case there is 0,1 - 4 medicines you can remove \r\n\t0,1 - 1 meds. Similarly to the action of adding, the closer to the limit, the less you can remove." +
        "\r\n\r\n    4. Value for texts and letters.\r\n\r\n\tBelow you can find text and letter value.\r\n    \t\r\n\t\r\n\tText value for adding action:\r\n \r\n\t- for these texts this value is 100 pcs:\r\n\t  \"max\" or \"maximum\" or \"huge cardboard\" or \"huge\" or \"huge medicines cardboard\" or\r\n\t  \"a huge box of medicines\" or \"a huge medicine box\",\r\n\r\n        - for these texts this value is 50 pcs:\r\n\t  \"large\" or \"big\" or \"big cardboard\" or \"big box\" or \"big medicines cardboard\" or\r\n\t  \"a large box of medicines\" or \"a large medicine box\",\r\n\r\n        - for these texts this value is 25 pcs:\r\n\t  \"medium\" or \"medium cardboard\" or \"medium box\" or \"medium medicine carton\" or \"carton\" or \"cardboard\"\r\n\t  or \"box\" or \"twenty five pieces\" or \"25 pieces\" or \"twenty-five\",\r\n\r\n        - for these texts this value is 10 pcs: \r\n\t  \"min\" or \"minimum\" or \"small\" or \"small cardboard\" or \"small box\" or \"ten pieces\" or\r\n\t  \"10 pieces\" or \"ten\"." +
        "\r\n\r\n\r\n\tLetter value for adding action:\r\n\r\n\t- for letter: 'a' or 'A' - this value is 100 pcs,\r\n\t- for letter: 'b' or 'B' - this value is 90 pcs,\r\n\t- for letter: 'c' or 'C' - this value is 80 pcs,\r\n\t- for letter: 'd' or 'D' - this value is 70 pcs,\r\n\t- for letter: 'e' or 'E' - this value is 60 pcs,\r\n\t- for letter: 'f' or 'F' - this value is 50 pcs,\r\n\t- for letter: 'g' or 'G' - this value is 40 pcs,\r\n\t- for letter: 'h' or 'H' - this value is 30 pcs,\r\n\t- for letter: 'i' or 'I' - this value is 20 pcs,\r\n\t- for letter: 'j' or 'J' - this value is 10 pcs,\r\n\t- for letter: 'k' or 'K' - this value is 5 pcs.\r\n\r\n\r\n\tLetter value for removing action:\r\n\r\n\t- for letter: 'l' or 'L' - this value is -1 pcs,\r\n\t- for letter: 'm' or 'M' - this value is -5 pcs,\r\n\t- for letter: 'n' or 'N' - this value is -10 pcs,\r\n\t- for letter: 'o' or 'O' - this value is -20 pcs.\n");
    NextStep();
}

TextInColor(ConsoleColor.Green, $"\n    See you next time! :)\n");
TextInColor(ConsoleColor.DarkRed, "______________________________________________________________________________________________________________________\n" +
    "\n                                        Press any button to EXIT the program\n______________________________________________________________________________________________________________________\n                                                                                                                      \n");
//    I'm sorry for my english, and I hope you will like this console app! :)  P.R.