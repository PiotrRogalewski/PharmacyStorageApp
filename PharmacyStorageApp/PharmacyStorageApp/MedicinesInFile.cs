namespace PharmacyStorageApp
{
    public class MedicinesInFile : MedicinesBase
    {
        private readonly string fileNameWithCategoryName;
        private readonly static string fileName = "medicines_in_stock.txt";

        public override event MedicineAddedDelegate MedicinesAdded;
        public override event MedicationsRemovedDelegate MedicationsRemoved;

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

                if (MedicinesAdded != null)
                {
                    MedicinesAdded(this, new EventArgs());
                }
            }

            if (medicinesInStock <= 500)
            {
                if (medicines >= 1 && medicines <= 100)
                {
                    WritingNumbersInFile();
                }
                else
                {
                    throw new Exception("Invalid value! This value must be in the range 1-100.\n\n    Try again!");
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
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range 1-50, no more because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
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
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range 1-25, no more because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
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
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range 1-10, no more because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
                }
            }
            else if (medicinesInStock >= 591 && medicinesInStock <= 599)
            {
                if (medicines == 1)
                {
                    WritingNumbersInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be no more than 1, because the storage area is almost full.\n    Check the user manual or READMY file for more information.\n\n    Try again!");
                }
            }
            else if (medicinesInStock >= 600)
            {
                throw new Exception($"Overcrowded storage area! You can't add more medicines to this storage area when it's full!\n    There must be less than 600 medicines in stock in this storage area to have possibility to add more medicines.\n    Check the user manual or READMY file for more information.\n\n    Cause:   medicines in stock = [ {medicinesInStock} ]");
            }
            else
            {
                throw new Exception("Error! Invalid action!");
            }
        }

        public override void PutMedicineOnTheShelf(string medicines)
        {
            switch (medicines)
            {
                case "max" or "maximum" or "huge cardboard" or "huge" or "huge medicines cardboard" or "a huge box of medicines" or "a huge medicine box":
                    PutMedicineOnTheShelf((float)100);
                    break;
                case "large" or "big" or "big cardboard" or "big box" or "big medicines cardboard" or "a large box of medicines" or "a large medicine box":
                    PutMedicineOnTheShelf((float)50);
                    break;
                case "medium" or "medium cardboard" or "medium box" or "medium medicine carton" or "carton" or "cardboard" or "box" or "twenty five pieces" or "25 pieces" or "twenty-five":
                    PutMedicineOnTheShelf((float)25);
                    break;
                case "min" or "minimum" or "small" or "small cardboard" or "small box" or "ten pieces" or "10 pieces" or "ten":
                    PutMedicineOnTheShelf((float)10);
                    break;
                default:
                    if (float.TryParse(medicines, out float result))
                    {
                        this.PutMedicineOnTheShelf(result);
                    }
                    else if (char.TryParse(medicines, out char medicinesInLetters))
                    {
                        PutMedicineOnTheShelf(medicinesInLetters);
                    }
                    else
                    {
                        throw new Exception("Invalid text value!\n    Check the user manual or READMY file to find out what values are available as text.\n\n    Try again!\n");
                    }
                    break;
            }
        }

        public override void PutMedicineOnTheShelf(char medicines)
        {
            switch (medicines)
            {
                case 'A' or 'a':
                    PutMedicineOnTheShelf((float)100);
                    break;
                case 'B' or 'b':
                    PutMedicineOnTheShelf((float)90);
                    break;
                case 'C' or 'c':
                    PutMedicineOnTheShelf((float)80);
                    break;
                case 'D' or 'd':
                    PutMedicineOnTheShelf((float)70);
                    break;
                case 'E' or 'e':
                    PutMedicineOnTheShelf((float)60);
                    break;
                case 'F' or 'f':
                    PutMedicineOnTheShelf((float)50);
                    break;
                case 'G' or 'g':
                    PutMedicineOnTheShelf((float)40);
                    break;
                case 'H' or 'h':
                    PutMedicineOnTheShelf((float)30);
                    break;
                case 'I' or 'i':
                    PutMedicineOnTheShelf((float)20);
                    break;
                case 'J' or 'j':
                    PutMedicineOnTheShelf((float)10);
                    break;
                case 'K' or 'k':
                    PutMedicineOnTheShelf((float)5);
                    break;
                default:
                    throw new Exception("Invalid letter value!\n    Check the user manual or READMY file to find out what values are available as letters.\n\n    Try again!\n");
            }
        }

        public override void PutMedicineOnTheShelf(int medicines)
        {
            PutMedicineOnTheShelf((float)medicines);
        }

        public override void PutMedicineOnTheShelf(double medicines)
        {
            var medicinesInFloat = (float)medicines;
            PutMedicineOnTheShelf(medicinesInFloat);
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

                if (MedicationsRemoved != null)
                {
                    MedicationsRemoved(this, new EventArgs());
                }
            }

            if (medicinesInStock >= 20)
            {
                if (medicines <= -0.01 && medicines >= -20)
                {
                    WritingNegativeNumberInFile();
                }
                else
                {
                    throw new Exception("Invalid value!\n    This value must be in the range from -20 to -0.01. For more information check user manual or READMY file.\n\n    You have to write it with sign '-' (minus) before the number. Try again!\n");
                }
            }
            else if (medicinesInStock >= 10 && medicinesInStock <= 19)
            {
                if (medicines <= -0.01 && medicines >= -10)
                {
                    WritingNegativeNumberInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range from -10 to -0.01, because the storage area is alomost empty.\n    For more information check user manual or READMY file.\n\n    You have to write it with sign '-' (minus) before the number. Try again!\n");
                }
            }
            else if (medicinesInStock >= 5 && medicinesInStock <= 9)
            {
                if (medicines <= -0.01 && medicines >= -5)
                {
                    WritingNegativeNumberInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range from -5 to -0.01, because the storage area is alomost empty.\n    For more information check user manual or READMY file.\n\n    You have to write it with sign '-' (minus) before the number. Try again!\n");
                }
            }
            else if (medicinesInStock >= 1 && medicinesInStock <= 4)
            {
                if (medicinesInStock <= -0.01 && medicines >= -1)
                {
                    WritingNegativeNumberInFile();
                }
                else
                {
                    throw new Exception($"Invalid value!  Medicines in stock:  {medicinesInStock}\n    This value must be in the range from -1 to -0.01 medicine, because the storage area is alomost empty.\n    For more information check user manual or READMY file.\n\n    You have to write it with sign '-' (minus) before the number. Try again!\n");
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

        public override void TakeTheMedicineFromTheShelf(string medicines)
        {
            if (float.TryParse(medicines, out float result))
            {
                this.TakeTheMedicineFromTheShelf(result);
            }
            else if (char.TryParse(medicines, out char medicinesInLetters))
            {
                TakeTheMedicineFromTheShelf(medicinesInLetters);
            }
            else
            {
                throw new Exception("Invalid text value!\n    Check the user manual or READMY file to find out what values are available as text.\n\n    Try again!\n");
            }
        }

        public override void TakeTheMedicineFromTheShelf(char medicines)
        {
            switch (medicines)
            {
                case 'L' or 'l':
                    TakeTheMedicineFromTheShelf((float)-1);
                    break;
                case 'M' or 'm':
                    TakeTheMedicineFromTheShelf((float)-5);
                    break;
                case 'N' or 'n':
                    TakeTheMedicineFromTheShelf((float)-10);
                    break;
                case 'O' or 'o':
                    TakeTheMedicineFromTheShelf((float)-20);
                    break;
                default:
                    throw new Exception("Invalid letter value!\n    Check the user manual or READMY file to find out what values are available as letters.\n\n    Try again!");
            }
        }

        public override void TakeTheMedicineFromTheShelf(int medicines)
        {
            TakeTheMedicineFromTheShelf((float)medicines);
        }

        public override void TakeTheMedicineFromTheShelf(double medicines)
        {
            var medicinesInFloat = (float)medicines;
            TakeTheMedicineFromTheShelf((float)medicinesInFloat);
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
                Console.WriteLine("    Warning! File for this medicines category does not exist!\n");
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