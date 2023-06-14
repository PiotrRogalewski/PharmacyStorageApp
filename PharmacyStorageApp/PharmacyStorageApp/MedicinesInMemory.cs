namespace PharmacyStorageApp
{
    public class MedicinesInMemory : MedicinesBase
    {
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

                    if (medicinesInStock <= 600)
                    {
                        EventForAddingMedicines();
                    }
                    else if (medicinesInStock > 600)
                    {
                        specificMedicationsAvailable.RemoveAt(specificMedicationsAvailable.Count - 1);
                        medicinesInStock = specificMedicationsAvailable.Sum();

                        throw new Exception($"You can't add more medcines!\n    You have space for only 600 pieces of this medicine in the storage area.\n    The last attempt to add meds was cancelled! In this storage area is still [ {medicinesInStock} ] medicines in stock.");
                    }
                    else
                    {
                        throw new Exception("Error! Invalid action! (Inside)");
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
                throw new Exception("Error! Invalid action! (Outside)");
            }
        }

        public override void TakeTheMedicineFromTheShelf(float medicines)
        {
            var medicinesInStock = specificMedicationsAvailable.Sum();

            if (medicinesInStock > 0)
            {
                if (medicines <= -0.1 && medicines >= -20)
                {
                    this.specificMedicationsAvailable.Add(medicines);
                    medicinesInStock = specificMedicationsAvailable.Sum();

                    if (medicinesInStock >= 0)
                    {
                        EventForRemovingMedicines();
                    }
                    else if (medicinesInStock < 0)
                    {
                        specificMedicationsAvailable.RemoveAt(specificMedicationsAvailable.Count - 1);
                        medicinesInStock = specificMedicationsAvailable.Sum();

                        throw new Exception($"The storage area is almost empty (or empty)! You can't remove more than you have in the storage area!\n    The last attempt to remove meds was cancelled! In this storage area is still [ {medicinesInStock} ] medicines in stock.\n");
                    }
                }
                else
                {
                    throw new Exception("Invalid value!\n    This value must be in the range from -20 to -0,1. You have to write it with sign '-' (minus) before the number.\n\n    Try again!");
                }
            }
            else if (medicinesInStock == 0)
            {
                throw new Exception($"The storage area is empty! You can't remove medicines from the storage area when it's empty!\n    There must be more than 0 medicines in stock in this storage area.\n    You must first add new meds to be able to remove medicines.\n\n    Cause:   medicines in stock = [ {medicinesInStock} ]");
            }
            else
            {
                throw new Exception($"Error! Invalid action!");
            }
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