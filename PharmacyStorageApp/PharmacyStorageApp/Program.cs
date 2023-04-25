using PharmacyStorageApp;

Console.BackgroundColor = ConsoleColor.DarkRed;
TextInColor(ConsoleColor.White,
    "______________________________________________________________________________________________________________________\n" +
    "                                                                                                                      \n" +
    $"                        ~~~~ (+) ~~~~       Welcome in PharmacyStorageApp!       ~~~~ (+) ~~~~                        \n" +
    "______________________________________________________________________________________________________________________\n" +
    "                                                                                                                      \n");
Console.ResetColor();

// ALL AVAILABLE MEDICATIONS (8) AND THEIRS PARAMETERS
// (Advise! If you don't understand sth then check [ READMY file ] or go to [ MAIN MENU > Description and user manual ] for more information.)
var medicinesInMemory1 = new MedicinesInMemory("painkillers", "solid", "blister", 24);
var medicinesInMemory2 = new MedicinesInMemory("other tablets", "solid", "bl", 24);
var medicinesInMemory3 = new MedicinesInMemory("syrups", "liquid", "bottle", 1);
var medicinesInMemory4 = new MedicinesInMemory("suppositories", "solid", "plastic cover", 10);
var medicinesInMemory5 = new MedicinesInMemory("dressing", "S", "protectivePackaging", 1);
var medicinesInMemory6 = new MedicinesInMemory("ointment", "s", "jar", 1);
var medicinesInMemory7 = new MedicinesInMemory("drops", "l", "bwd", 1);
var medicinesInMemory8 = new MedicinesInMemory("supplements", "solid", "blister", 60);

string medicinesInStock = null;
string putedMedicines = null;
string takedMedicines = null;
string medicinesCategory = null;
string savingMethod = null;
bool testerMode = false;
bool doNotBreakThisLoop = true;


TextInColor(ConsoleColor.DarkGreen, "    Please write your name to start this program or write 'x' to exit, then click ENTER\n");
var user = Console.ReadLine();

while (user != "x") // MAIN LOOP ( start menu >> main menu >> [ all options ] )
{
    if (user == "3370") // Secret option ;)
    {
        TextInColor(ConsoleColor.Magenta, $"\n    Tester mode is activated!\n");
        TextInColor(ConsoleColor.DarkGray, "    Maybe in the future new options will be added for the Tester...\n");
        testerMode = true;
        user = "Tester";
        Testing($"Your name from now will be: {user}");
    }
    else
    {
        testerMode = false;
    }

    TextInColor(ConsoleColor.DarkGreen, $"\n    Hello {user}!\n\n    Press ENTER once to go to the main menu,\n    Click 'c' - if you want to change your name in the program,\n    click 'x' - to exit this program\n    ...then press ENTER\n");
    var checkUser = Console.ReadLine();

    if (checkUser == "")
    {
        while (checkUser == "") // MAIN MENU - options:   m = pharmacy storage area management, d = more information and user manual, i = bacis technical information about the program, x = exit. 
        {
            TheLine();
            TextInColor(ConsoleColor.DarkGreen, $"\n    MAIN MENU");
            TextInColor(ConsoleColor.Yellow, $"    In this program you can manage your pharmacy storage area. {user}, please select what you want to do:\n\n\n    click 'm' or press ENTER once - to manage your pharmacy stroage area,\n    click 'd' - to view description of the program and user manual,\n    click 'i' - to view basic technical information about the PharmacyStroageApp\n    click 'x' - to exit the program\n    ... then press ENTER\n");
            TheLine();
            var selectAction = Console.ReadLine();

            string BackToMenu() // It is method for return to the main menu
            {
                TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, do you want to return to the MAIN MENU? Please write:\n\n\n         'y' = for YES, then press ENTER / or just press ENTER once,\n\n         'n' or 'x' = for NO - exit the program, then press ENTER.\n");
                var toMenu = Console.ReadLine();

                while (toMenu != null)
                {
                    if (toMenu == "y" || toMenu == "")
                    {
                        doNotBreakThisLoop = false;
                        checkUser = "";
                        break;
                    }
                    else if (toMenu == "n" || toMenu == "x")
                    {
                        doNotBreakThisLoop = false;
                        checkUser = "x";
                        user = "x";
                        break;
                    }
                    else
                    {
                        InvalidSelection("");
                        TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, do you want to return to the MAIN MENU? Please write:\n\n\n         'y' = for YES, then press ENTER / or just press ENTER once,\n\n         'n' or 'x' = for NO - exit the program, then press ENTER.\n");
                        toMenu = Console.ReadLine();
                        Testing("Is your selection correct? (Then you should return to menu or exit this application)\n    YES - then you should check it in program.cs!  /  NO - then you should continue  /  Otherwise it's a bug!");

                        continue;
                    }
                }
                return checkUser;
            }

            string SavingMethodSelection() // It is method to choose type of saving
            {
                doNotBreakThisLoop = true;

                while (doNotBreakThisLoop == true)
                {
                    TextInColor(ConsoleColor.DarkGreen, "    Please select the saving method:\n\n    click 'f' - saving to file\n    click 'm' - saving to program memory\n");
                    savingMethod = Console.ReadLine();

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
                    else if (savingMethod != "m" && savingMethod != "f")
                    {
                        InvalidSelection($"{user}, try again!");
                        Testing("You are in SavingMethodSelection() loop.\n    The Program should continue this loop after confirmation of selecting the saving method (after ENTER).\n    Is saving method working properly?\n    YES - continue...  /  NO - check Program.cs!");
                        continue;
                    }
                }
                return savingMethod;
            }

            switch (selectAction)
            {
                case "m" or "":     // PHARMACY STORAGE AREA MANAGING ( medications selection >> medications add /remove /check options >> statistics )

                    MedicinesInMemory medicinesInMemory = null;

                    TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, now you can manage the pharmacy storage area.\n\n");
                    TextInColor(ConsoleColor.DarkGray, "    If you want to know more about limits for adding or removing medicines from shelfs of pharmacy storage area or if\n    you don't know how text value and letter value works, then you should read user manual or READMY file.\n    Otherwise continue.\n\n");
                    doNotBreakThisLoop = true;

                    while (doNotBreakThisLoop == true) // medications category selection
                    {
                        TextInColor(ConsoleColor.DarkGreen, "    Please select which medications you want to add / remove / check:\n");
                        TextInColor(ConsoleColor.DarkGray, $"\n    click '1' to select: {medicinesInMemory1.CategoryName}\n    click '2' to select: {medicinesInMemory2.CategoryName}\n    click '3' to select: {medicinesInMemory3.CategoryName}\n    click '4' to select: {medicinesInMemory4.CategoryName}\n    click '5' to select: {medicinesInMemory5.CategoryName}\n    click '6' to select: {medicinesInMemory6.CategoryName}\n    click '7' to select: {medicinesInMemory7.CategoryName}\n    click '8' to select: {medicinesInMemory8.CategoryName}\n    click 'x' to exit\n    then press ENTER to continue");
                        medicinesCategory = Console.ReadLine();

                        switch (medicinesCategory)
                        {
                            case "1":
                                TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: {medicinesInMemory1.CategoryName}\n");
                                medicinesInMemory = medicinesInMemory1;
                                NextStep();
                                doNotBreakThisLoop = false;
                                break;
                            case "2":
                                TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: {medicinesInMemory2.CategoryName}\n");
                                medicinesInMemory = medicinesInMemory2;
                                NextStep();
                                doNotBreakThisLoop = false;
                                break;
                            case "3":
                                TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: {medicinesInMemory3.CategoryName}\n");
                                medicinesInMemory = medicinesInMemory3;
                                NextStep();
                                doNotBreakThisLoop = false;
                                break;
                            case "4":
                                TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: {medicinesInMemory4.CategoryName}\n");
                                medicinesInMemory = medicinesInMemory4;
                                NextStep();
                                doNotBreakThisLoop = false;
                                break;
                            case "5":
                                TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: {medicinesInMemory5.CategoryName}\n");
                                medicinesInMemory = medicinesInMemory5;
                                NextStep();
                                doNotBreakThisLoop = false;
                                break;
                            case "6":
                                TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: {medicinesInMemory6.CategoryName}\n");
                                medicinesInMemory = medicinesInMemory6;
                                NextStep();
                                doNotBreakThisLoop = false;
                                break;
                            case "7":
                                TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: {medicinesInMemory7.CategoryName}\n");
                                medicinesInMemory = medicinesInMemory7;
                                NextStep();
                                doNotBreakThisLoop = false;
                                break;
                            case "8":
                                TextInColor(ConsoleColor.Green, $"\n    {user}, you selected: {medicinesInMemory8.CategoryName}\n");
                                medicinesInMemory = medicinesInMemory8;
                                NextStep();
                                doNotBreakThisLoop = false;
                                break;
                            case "x":
                                BackToMenu();
                                Testing("Have you just returned to the MAIN MENU?\n    YES - continue  /  NO - check it!");
                                break;
                            default:
                                Testing("You are in [ medicinesCategory ] switch loop in 'default' case. It should continue this loop \n    from the beginning after you press ENTER. If you click ENTER: Are you continue this loop?\n    YES - everything is OK,    NO - this is a malfunction! Check program.cs");
                                InvalidSelection("Try again!");
                                continue;
                        }
                    }

                    if (medicinesInMemory != null) // Events and methods for those events, next: switch with option selection (add / remove / check)
                    {
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
                                        Testing("Error! This message come from <default:> in [ putedMedicines ] switch, inside the TextAsNumberForAdditionMethod() \n    in Program.cs\n");
                                        putedMedicines = "No";
                                        return putedMedicines;
                                }
                            }
                            else
                            {
                                Testing("Error! This message come from 'else' inside the TextAsNumberForAdditionMethod() in Program.cs\n");
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
                                        Testing("Error! This message come from <default:> in [ takedMedicines ] switch, inside the TextAsNumberForRemovalMethod()\n    in Program.cs!\n");
                                        takedMedicines = "No";
                                        return takedMedicines;
                                }
                            }
                            else
                            {
                                Testing("Error! This message come from <else> inside the TextAsNumberForRemovalMethod() in Program.cs.\n");
                                takedMedicines = "No";
                                return takedMedicines;
                            }
                        }

                        void GetMedicinesInStock() // Defining medicines is stock
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

                        // Events activation
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
                            BackToMenu();
                        }

                        TextInColor(ConsoleColor.DarkGreen, $"\n    Select option:\n\n    --> write '1' or 'add' or 'put' - to add new medicines on the shelf in storage area (action of adding)\n    --> write '2' or 'remove' or 'take' - to remove existing medicines from shelf in storage area (action of removing)\n    --> write '3' or 'check' - to check statistics of given medications in your storage area\n    --> write 'x' - to exit\n        then press ENTER to confirm.");
                        var optionSelection = Console.ReadLine();

                        if (optionSelection != null)
                        {
                            switch (optionSelection) // Options: Add / remove / check
                            {
                                case "1" or "add" or "put": // Add option
                                    TheLine();
                                    TextInColor(ConsoleColor.Yellow, "\n    Option of adding");
                                    TextInColor(ConsoleColor.DarkGreen, $"    {user}, you will be able to add medicines to this storage area after selecting the saving method.\n\n");
                                    SavingMethodSelection();
                                    doNotBreakThisLoop = true;

                                    while (doNotBreakThisLoop == true)
                                    {
                                        TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, please enter the number of medicines (or write: text value or letter value) you want to add\n    on the shelf in the storage area, then click ENTER to continue.");
                                        TextInColor(ConsoleColor.DarkGray, "    If you want quit in any moment write 'q' then press ENTER - you will return to the main menu\n");
                                        putedMedicines = Console.ReadLine();

                                        if (putedMedicines == "q")
                                        {
                                            ShowMedicationDispositionStatistics();
                                            doNotBreakThisLoop = false;
                                            optionSelection = "x";
                                            break;
                                        }
                                        try
                                        {
                                            if (savingMethod == "m")
                                            {
                                                medicinesInMemory.PutMedicineOnTheShelf(putedMedicines);
                                                Testing("Medicines sholud be added to specificMedicationsAvailable list (to the program memory), see the stats to find out \n    (you will see it when you finish - press q and ENTER).\n    Are you see value as number in event message? It should always show value as number, not letter or text.\n    If you see 0 as medicines in stock in event message then this is a bug, this value should be above 0.\n    Unless you haven't add yet any medicines to the storage area - then it's ok.\n");
                                                continue;
                                            }
                                            else if (savingMethod == "f")
                                            {
                                                medicinesInFile.PutMedicineOnTheShelf(putedMedicines);
                                                Testing("Medicines sholud be added to specificMedicationsAvailable list (to a specific file), see the stats to find out \n    (you will see it when you finish - press q and ENTER).\n    Are you see value as number in event message? It should always show value as number, not letter or text.\n    If you see 0 as medicines in stock in event message then this is a bug, this value should be above 0.\n    Unless you haven't add yet any medicines to the storage area - then it's ok.\n");
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

                                case "2" or "take" or "remove": // Remove option
                                    TheLine();
                                    TextInColor(ConsoleColor.Yellow, "\n    Option of removing");
                                    TextInColor(ConsoleColor.DarkGreen, $"    {user}, you will be able to remove medicines from this storage area after selecting the saving method.\n\n");
                                    SavingMethodSelection();
                                    doNotBreakThisLoop = true;

                                    while (doNotBreakThisLoop == true)
                                    {
                                        TextInColor(ConsoleColor.DarkGreen, $"\n    {user}, please enter the number of medicines (or write: text value or letter value) you want to remove\n    from the shelf in the storage area, then click ENTER to continue.");
                                        TextInColor(ConsoleColor.DarkGray, "    If you want quit in any moment write 'q' then press ENTER - you will return to the main menu\n");
                                        takedMedicines = Console.ReadLine();

                                        if (takedMedicines == "q")
                                        {
                                            ShowMedicationDispositionStatistics();
                                            doNotBreakThisLoop = false;
                                            optionSelection = "x";
                                            break;
                                        }
                                        try
                                        {
                                            if (savingMethod == "m")
                                            {
                                                medicinesInMemory.TakeTheMedicineFromTheShelf(takedMedicines);
                                                Testing("Medicines sholud be added as minus value to specificMedicationsAvailable list (to the program memory),\n    see the stats to find out (you will see it when you finish - press q and ENTER).\n    Are you see value as number in event message? It should always show value as number, not letter or text.\n    If you see 0 as medicines in stock in event message then:\n    - in case you have removed the medicines to 0 medicines in stock then it is correct,\n    - in case you haven't removed any meds from medicines in stock and you haven't add any meds from this\n      category of medicines, then there should also be 0 medicines in stock,\n    - Otherwise it's a bug!");
                                            }
                                            else if (savingMethod == "f")
                                            {
                                                medicinesInFile.TakeTheMedicineFromTheShelf(takedMedicines);
                                                Testing("Medicines sholud be added as minus value to specificMedicationsAvailable list (to a specific file),\n    see the stats to find out (you will see it when you finish - press q and ENTER).\n    Are you see value as number in event message? It should always show value as number, not letter or text.\n    If you see 0 as medicines in stock in event message then:\n    - in case you have removed the medicines to 0 medicines in stock then it is correct,\n    - in case you haven't removed any meds from medicines in stock and you haven't add any meds from this\n      category of medicines, then there should also be 0 medicines in stock,\n    - Otherwise it's a bug!");
                                            }
                                        }
                                        catch (Exception exc)
                                        {
                                            TextInColor(ConsoleColor.Red, $"\n    Exception detected!\n\n    {exc.Message}\n");
                                            continue;
                                        }
                                    }
                                    break;

                                case "3" or "check": // Check option - it show statistics for selected medicines category
                                    try
                                    {
                                        TheLine();
                                        TextInColor(ConsoleColor.Yellow, "\n    Checking medicines in stock.");
                                        TextInColor(ConsoleColor.DarkGreen, $"    {user}, you will be able to check available medications and statistics after selecting the saving method.\n\n");
                                        SavingMethodSelection();

                                        if (savingMethod == "m")
                                        {
                                            savingMethod = "m";
                                            Testing($"You should see medicines in stock from program memory. This value should be above 0, unless you:\n    - haven't added any medicines from category of {medicinesInMemory.CategoryName},\n    - or you have removed enough medicines to leave the storage area empty,\n    - otherwise it's a bug!");
                                            ShowMedicationDispositionStatistics();
                                            break;
                                        }
                                        else if (savingMethod == "f")
                                        {
                                            savingMethod = "f";
                                            Testing($"You should see medicines in stock from file. This value should be above 0, unless you:\n    - haven't added any medicines from category of {medicinesInMemory.CategoryName},\n    - or you have removed enough medicines to leave the storage area empty,\n    - otherwise it's a bug!");
                                            ShowMedicationDispositionStatistics();
                                            break;
                                        }
                                    }
                                    catch (Exception exception)
                                    {
                                        Testing("This Exception come from check option >> catch.");
                                        TextInColor(ConsoleColor.Red, $"\n    Exception detected!\n\n    {exception.Message}\n");
                                        break;
                                    }
                                    break;

                                case "x":
                                    BackToMenu();
                                    Testing("Have you just returned to the MAIN MENU?\\n    YES - continue  /  NO - check it in Program.cs!");
                                    break;

                                default:
                                    InvalidSelection($"{user}, you will return to the MAIN MENU.");
                                    Testing("Are you returned to the main menu?\n    YES - continue  /  NO - check it in Program.cs!");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        TextInColor(ConsoleColor.Red, "\n    None medicament category has been selected.\n");
                        Testing($"{user} medicinesInMemory shouldn't be null! Except if you have chosen to exit the program or return\n    to the main menu, then this working properly. Otherwsie check it!");
                        continue;
                    }
                    break;

                case "d":       // USER MANUAL

                    TextInColor(ConsoleColor.DarkGreen, "\n    Description of the program and user manual:\n");
                    TextInColor(ConsoleColor.DarkGray, "    If you already read the READMY file you will not find new information here, you can skip it (just press ENTER).\n    Otherwise check below to find more information and user manual.\n\n");
                    TextInColor(ConsoleColor.White, "    DESCRIPTION OF THE PROGRAM:\n\n");
                    TextInColor(ConsoleColor.Gray, $"      In the PharmacyStorageApp you may manage a small pharmacy storage area. This application allows you to add\n    medicines to the pharmacy storage area or remove it from this area. You can also check how many medicines\n    from specific category is there. {user}, you are able to save a data in the file or save\n    it to the program memory. Everytime you will end adding or removing process, you will see\n    statistics from all actions on a given medicine category.\n\n    For more information read User manual or READMY file.\n\n");
                    TextInColor(ConsoleColor.White, "\n    USER MANUAL:\n\n");
                    TextInColor(ConsoleColor.Gray, "    Not completed...\n    Remember! You can't remove more then 20 pieces, it's limited. If you remove some medicine it must be minimum 0,01 piece.\n");
                    NextStep();
                    Testing("This section in not complete...");
                    BackToMenu();
                    break;

                case "i":       // BASIC INFO ABOUT APP

                    TextInColor(ConsoleColor.DarkGreen, "\n    Basic information about PharmacyStorageApp:\n");
                    TextInColor(ConsoleColor.DarkGray, "        This console app is written by  Piotr Rogalewski  in Visual studio 2022 (Microsoft) on the .NET 7.0 platform. \n    Programming language is C#. The application was completed on April 24, 2023.\n\n");
                    NextStep();
                    BackToMenu();
                    break;

                case "x":       // EXIT
                    checkUser = "x";
                    user = "x";
                    break;

                default:
                    InvalidSelection("You will return to the MAIN MENU");
                    break;
            }
        }
    }
    else if (checkUser == "c")  // changing name
    {
        TextInColor(ConsoleColor.DarkGreen, "\n    Please re-write your name correctly or click 'x' to exit this program, then click ENTER\n");
        user = Console.ReadLine();
        continue;
    }
    else if (checkUser == "x")  // exit
    {
        break;
    }
    else if (checkUser != "" && checkUser != "c" && checkUser != "x")
    {
        TextInColor(ConsoleColor.Red, $"\n    Try again...\n");
        continue;
    }
}

static void InvalidSelection(string text)
{
    TextInColor(ConsoleColor.Red, $"    Invalid selection! For more information check user's manual or read READMY file.\n    {text}\n");
    NextStep();
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

void Testing(string text)       // Tester mode
{
    if (testerMode == true)
    {
        TextInColor(ConsoleColor.Magenta, $"\n Tester mode:\n    {text}\n");
    }
}

TextInColor(ConsoleColor.Green, $"\n    See you next time! :)\n");
TextInColor(ConsoleColor.DarkRed, "______________________________________________________________________________________________________________________\n" +
    "\n                                        Press any button to EXIT the program\n______________________________________________________________________________________________________________________\n                                                                                                                      \n");
//    I'm sorry for my english, and I hope you will like this console app! :)  P.R.