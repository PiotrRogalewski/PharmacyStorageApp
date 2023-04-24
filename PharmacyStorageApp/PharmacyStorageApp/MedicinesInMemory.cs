namespace PharmacyStorageApp
{
    public class MedicinesInMemory : MedicinesBase
    {
        public override event MedicineAddedDelegate MedicinesAdded;

        public override event MedicationsRemovedDelegate MedicationsRemoved;

        private List<float> specificMedicationsAvailable = new List<float>();

        public MedicinesInMemory(string categoryName, string stateOfMatter, string typeOfPackaging, int totalPackageCapacity)
            : base(categoryName, stateOfMatter, typeOfPackaging, totalPackageCapacity)
        {
        }

        public override void PutMedicineOnTheShelf(float medicines)
        {
            var medicinesInStock = specificMedicationsAvailable.Sum();

            if (medicinesInStock < 600)
            {
                if (medicines >= 1 && medicines <= 100)
                {
                    this.specificMedicationsAvailable.Add(medicines);
                    medicinesInStock = specificMedicationsAvailable.Sum();

                    if (MedicinesAdded != null && medicinesInStock <= 600)
                    {
                        MedicinesAdded(this, new EventArgs());
                    }
                    else if (medicinesInStock > 600)
                    {
                        specificMedicationsAvailable.RemoveAt(specificMedicationsAvailable.Count - 1);
                        medicinesInStock = specificMedicationsAvailable.Sum();

                        throw new Exception($"You can't add more medcines!\n    You have space for only 600 pieces of this medicine in the storage area.\n    The last attempt to add meds was cancelled! In this storage area is still [ {medicinesInStock} ] medicines in stock.");
                    }
                    else
                    {
                        throw new Exception("Error! Invalid action!");
                    }
                }
                else
                {
                    throw new Exception("Invalid value! This value must be in the range 1-100.\n\n    Try again!");
                }
            }
            else if (medicinesInStock >= 600)
            {
                throw new Exception($"Overcrowded storage area! You can't add more medicines to this storage area when it's full!\n    There must be less than 600 medicines in stock in this storage area to have possibility to add more medicines.\n\n    Cause:   medicines in stock = [ {medicinesInStock} ]");
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
                        throw new Exception("Invalid text value!\n    Check the user manual or READMY file to find out what values are available as text.\n\n    Try again!");
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
                    throw new Exception("Invalid letter value!\n    Check the user manual or READMY file to find out what values are available as letters.\n\n    Try again!");
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
            var medicinesInStock = specificMedicationsAvailable.Sum();

            if (medicinesInStock > 0)
            {
                if (medicines < -0 && medicines >= -20)
                {
                    this.specificMedicationsAvailable.Add(medicines);
                    medicinesInStock = specificMedicationsAvailable.Sum();

                    if (MedicationsRemoved != null && medicinesInStock >= 0)
                    {
                        MedicationsRemoved(this, new EventArgs());
                    }
                    else if (medicinesInStock < 0)
                    {
                        specificMedicationsAvailable.RemoveAt(specificMedicationsAvailable.Count - 1);
                        medicinesInStock = specificMedicationsAvailable.Sum();

                        throw new Exception($"The storage area is almost empty! You can't remove more than you have in the storage area!\n    The last attempt to remove meds was cancelled! In this storage area is still [ {medicinesInStock} ] medicines in stock.\n");
                    }
                }
                else
                {
                    throw new Exception("Invalid value!\n    This value must be in the range from -20 to -1. You have to write it with sign '-' (minus) before the number.\n\n    Try again!");
                }
            }
            else if (medicinesInStock <= 0)
            {
                throw new Exception($"The storage area is empty! You can't remove medicines from the storage area when it's empty!\n    There must be more than 0 medicines in stock in this storage area.\n    You must first add new meds to be able to remove medicines.\n\n    Cause:   medicines in stock = [ {medicinesInStock} ]");
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
                throw new Exception("Invalid text value!\n    Check the user manual or READMY file to find out what values are available as text.\n\n    Try again!");
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