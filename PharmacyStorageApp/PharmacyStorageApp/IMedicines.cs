using static PharmacyStorageApp.MedicinesBase;

namespace PharmacyStorageApp
{
    public interface IMedicines
    {
        string CategoryName { get; }
        string StateOfMatter { get; }
        string TypeOfPackaging { get; }
        int TotalPackageCapacity { get; }

        void PutMedicineOnTheShelf(float medicines);
        void PutMedicineOnTheShelf(string medicines);
        void PutMedicineOnTheShelf(char medicines);
        void PutMedicineOnTheShelf(int medicines);
        void PutMedicineOnTheShelf(double medicines);

        void TakeTheMedicineFromTheShelf(float medicines);
        void TakeTheMedicineFromTheShelf(string medicines);
        void TakeTheMedicineFromTheShelf(char medicines);
        void TakeTheMedicineFromTheShelf(int medicines);
        void TakeTheMedicineFromTheShelf(double medicines);

        MedicationManagementStatistics GetStatistics();

        public event MedicineAddedDelegate MedicinesAdded;

        public event MedicationsRemovedDelegate MedicationsRemoved;
    }
}