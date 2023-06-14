namespace PharmacyStorageApp
{
    public class MedicinesInFile : MedicinesBase
    {
        private readonly string fileNameWithCategoryName;
        private readonly static string fileName = "medicines_in_stock.txt";

        public MedicinesInFile(string categoryName, string stateOfMatter, string typeOfPackaging, int totalPackageCapacity)
            : base(categoryName, stateOfMatter, typeOfPackaging, totalPackageCapacity)
        {
            fileNameWithCategoryName = $"{categoryName}_{fileName}";
        }

        public override void PutMedicineOnTheShelf(float medicines)
        {
            var oneMedicationStats = GetStatistics();
            var medicinesInStock = oneMedicationStats.AvailableMedications;

            void WritingNumbersInFile()
            {
                var writer = File.AppendText(fileNameWithCategoryName);

                using (writer)
                {
                    writer.WriteLine(medicines);
                }

                EventForAddingMedicines();
            }

            if (medicinesInStock <= 500)
            {
                if (medicines >= 1 && medicines <= 100)
                {
                    WritingNumbersInFile();
                }
                else
                {
                    throw new Exception("Invalid value! This value must be in the range 1 - 100.\n\n    Try again!");
                }
            }
            else if (medicinesInStock >= 501 && medicinesInStock <= 550)
            {
                if (medicines >= 1 && medicines <= 50)
                {
                    WritingNumbersInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range 1 - 50, no more because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
                }
            }
            else if (medicinesInStock >= 551 && medicinesInStock <= 575)
            {
                if (medicines >= 1 && medicines <= 25)
                {
                    WritingNumbersInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range 1 - 25, no more because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
                }
            }
            else if (medicinesInStock >= 576 && medicinesInStock <= 590)
            {
                if (medicines >= 1 && medicines <= 10)
                {
                    WritingNumbersInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range 1 - 10, no more because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
                }
            }
            else if (medicinesInStock >= 591 && medicinesInStock <= 599)
            {
                if (medicines >= 0.001 && medicines <= 1)
                {
                    WritingNumbersInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be no more than 1, because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
                }
            }
            else if (medicinesInStock > 599 && medicinesInStock <= 599.9)
            {
                if (medicines >= 0.001 && medicines <= 0.1)
                {
                    WritingNumbersInFile();
                }
                else 
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range 0,001 - 0,1  because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
                }
            }
            else if (medicinesInStock >= 599.900001 && medicinesInStock <= 600)
            {
                throw new Exception($"Overcrowded storage area! You can't add more medicines to this storage area when it's full!\n    There must be less than 600 medicines in stock in this storage area to have possibility to add more medicines.\n    Check the user manual or READMY file for more information.\n\n    Cause:   medicines in stock = [ {medicinesInStock} ]");
            }
            else
            {
                throw new Exception($"Error! Invalid action!\n    Cause:   medicines in stock = [ {medicinesInStock} ]");
            }
        }

        public override void TakeTheMedicineFromTheShelf(float medicines)
        {
            var oneMedicationStats = GetStatistics();
            var medicinesInStock = oneMedicationStats.AvailableMedications;

            void WritingNegativeNumberInFile()
            {
                var writer = File.AppendText(fileNameWithCategoryName);

                using (writer)
                {
                    writer.WriteLine(medicines);
                }

                EventForRemovingMedicines();
            }

            if (medicinesInStock >= 20)
            {
                if (medicines <= -0.1 && medicines >= -20)
                {
                    WritingNegativeNumberInFile();
                }
                else
                {
                    throw new Exception("Invalid value!\n    This value must be in the range from -20 to -0.1. For more information check user manual or READMY file.\n\n    You have to write it with sign '-' (minus) before the number. Try again!\n");
                }
            }
            else if (medicinesInStock >= 10 && medicinesInStock <= 19)
            {
                if (medicines <= -0.1 && medicines >= -10)
                {
                    WritingNegativeNumberInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range from -10 to -0.1, because the storage area is alomost empty.\n    For more information check user manual or READMY file.\n\n    You have to write it with sign '-' (minus) before the number. Try again!\n");
                }
            }
            else if (medicinesInStock >= 5 && medicinesInStock <= 9)
            {
                if (medicines <= -0.1 && medicines >= -5)
                {
                    WritingNegativeNumberInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range from -5 to -0.1, because the storage area is alomost empty.\n    For more information check user manual or READMY file.\n\n    You have to write it with sign '-' (minus) before the number. Try again!\n");
                }
            }
            else if (medicinesInStock >= 0.1 && medicinesInStock <= 4)
            {
                if (medicines <= -0.1 && medicines >= -1)
                {
                    WritingNegativeNumberInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range from -1 to -0.1 medicine, because the storage area is alomost empty.\n    For more information check user manual or READMY file.\n\n    You have to write it with sign '-' (minus) before the number. Try again!\n");
                }
            }
            else if (medicinesInStock <= 0)
            {
                throw new Exception($"The storage area is empty! You can't remove medicines from the storage area when it's empty!\n    There must be more then 0 medicines in stock in this storage area.\n    You must first add new meds to be able to remove medicines.\n\n    Cause:   medicines in stock = [ {medicinesInStock} ]");
            }
            else
            {
                throw new Exception($"Error! Invalid action!");
            }
        }

        public override MedicationManagementStatistics GetStatistics()
        {
            var medicinesFromFile = this.ReadMedicinesFromFile();
            var result = this.CountStatistics(medicinesFromFile);
            return result;
        }

        private List<float> ReadMedicinesFromFile()
        {
            var specificMedicationsAvailable = new List<float>();

            if (File.Exists($"{fileNameWithCategoryName}"))
            {
                using (var reader = File.OpenText(fileNameWithCategoryName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        specificMedicationsAvailable.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n    Warning! File for this medicines category does not exist!\n\n    Hint: This file will be created when you add medicines for the first time.\n    ( If you are just adding meds, then this file has now been created. )\n");
                Console.ResetColor();
            }
            return specificMedicationsAvailable;
        }

        private MedicationManagementStatistics CountStatistics(List<float> specificMedicationsAvailable)
        {
            var statistics = new MedicationManagementStatistics();

            foreach (var medicines in specificMedicationsAvailable)
            {
                if (medicines > 0)
                {
                    statistics.PutMedicineOnTheShelf(medicines);
                }
                else if (medicines < 0)
                {
                    statistics.TakeTheMedicineFromTheShelf(medicines);
                }
            }

            return statistics;
        }
    }
}