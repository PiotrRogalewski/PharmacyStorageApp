namespace PharmacyStorageApp
{
    public abstract class MedicinesBase : IMedicines
    {
        public delegate void MedicineAddedDelegate(object sender, EventArgs args);

        public abstract event MedicineAddedDelegate MedicinesAdded;

        public delegate void MedicationsRemovedDelegate(object sender, EventArgs args);

        public abstract event MedicationsRemovedDelegate MedicationsRemoved;

        public MedicinesBase(string categoryName, string stateOfMatter, string typeOfPackaging, int totalPackageCapacity)
        {
            this.CategoryName = categoryName;
            this.StateOfMatter = stateOfMatter;
            this.TypeOfPackaging = typeOfPackaging;
            this.TotalPackageCapacity = totalPackageCapacity;

            switch (stateOfMatter)
            {
                case "liquid" or "Liquid" or "l" or "L":
                    this.StateOfMatter = "liquid";
                    break;
                case "solid" or "Solid" or "s" or "S":
                    this.StateOfMatter = "solid";
                    break;
                default:
                    throw new Exception(" Incorrect parameter! In this collection of medicines there are only solids or liquids.");
            }

            this.TypeOfPackaging = typeOfPackaging switch
            {
                "blister" or "Blister" or "bl" or "Bl" or "b-r" => "blister",
                "bottle" or "Bottle" or "bo" or "Bo" or "b-e" => "bottle",
                "plasticCover" or "PlasticCover" or "Plastic cover" or "plastic cover" or "Plastic Cover" or "pc" or "PC" or "p c" or "P C" or "p.c." or "P.C." => "plastic cover",
                "protective packaging" or "protectivePackaging" or "Protective packaging" or "Protective Packaging" or "pp" or "PP" or "p p" or "P P" or "p.p." or "P.P." => "protective packaging",
                "jar" or "j" or "Jar" or "J" => "jar",
                "bottle with dropper" or "bottleWithDropper" or "Bottle with Dropper" or "Bottle With Dropper" or "Bottle with dropper" or "bwd" or "BWD" or " b w d" or "B W D" or "b.w.d." or "B.W.D." => "bottle with dropper",
                _ => throw new Exception(" Incorrect parameter! Choose from specific: blister, bottle, plastic cover, protective packaging, jar, bottle with dropper."),
            };
        }

        public string CategoryName { get; private set; }
        public string StateOfMatter { get; private set; }
        public string TypeOfPackaging { get; private set; }
        public int TotalPackageCapacity { get; private set; }

        public abstract void PutMedicineOnTheShelf(float medicines);
        public abstract void PutMedicineOnTheShelf(string medicines);
        public abstract void PutMedicineOnTheShelf(char medicines);
        public abstract void PutMedicineOnTheShelf(int medicines);
        public abstract void PutMedicineOnTheShelf(double medicines);

        public abstract void TakeTheMedicineFromTheShelf(float medicines);
        public abstract void TakeTheMedicineFromTheShelf(string medicines);
        public abstract void TakeTheMedicineFromTheShelf(char medicines);
        public abstract void TakeTheMedicineFromTheShelf(int medicines);
        public abstract void TakeTheMedicineFromTheShelf(double medicines);

        public abstract MedicationManagementStatistics GetStatistics();
    }
}