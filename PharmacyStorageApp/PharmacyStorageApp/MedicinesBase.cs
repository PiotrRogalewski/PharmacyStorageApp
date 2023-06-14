namespace PharmacyStorageApp
{
    public abstract class MedicinesBase : IMedicines
    {
        public delegate void MedicineAddedDelegate(object sender, EventArgs args);

        public event MedicineAddedDelegate MedicinesAdded;

        public delegate void MedicationsRemovedDelegate(object sender, EventArgs args);

        public event MedicationsRemovedDelegate MedicationsRemoved;

        public MedicinesBase(string categoryName, string stateOfMatter, string typeOfPackaging, int totalPackageCapacity)
        {
            this.CategoryName = categoryName;
            this.StateOfMatter = stateOfMatter;

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

            this.TotalPackageCapacity = totalPackageCapacity;
        }

        public string CategoryName { get; private set; }
        public string StateOfMatter { get; private set; }
        public string TypeOfPackaging { get; private set; }
        public int TotalPackageCapacity { get; private set; }

        public abstract void PutMedicineOnTheShelf(float medicines);

        public void PutMedicineOnTheShelf(string medicines)
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

        public void PutMedicineOnTheShelf(char medicines)
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

        public void PutMedicineOnTheShelf(int medicines)
        {
            PutMedicineOnTheShelf((float)medicines);
        }

        public void PutMedicineOnTheShelf(double medicines)
        {
            var medicinesInFloat = (float)medicines;
            PutMedicineOnTheShelf(medicinesInFloat);
        }

        public abstract void TakeTheMedicineFromTheShelf(float medicines);

        public void TakeTheMedicineFromTheShelf(string medicines)
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

        public void TakeTheMedicineFromTheShelf(char medicines)
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

        public void TakeTheMedicineFromTheShelf(int medicines)
        {
            TakeTheMedicineFromTheShelf((float)medicines);
        }

        public void TakeTheMedicineFromTheShelf(double medicines)
        {
            var medicinesInFloat = (float)medicines;
            TakeTheMedicineFromTheShelf((float)medicinesInFloat);
        }

        public abstract MedicationManagementStatistics GetStatistics();

        protected void EventForAddingMedicines()
        {
            if (MedicinesAdded != null)
            {
                MedicinesAdded(this, new EventArgs());
            }
        }

        protected void EventForRemovingMedicines()
        {
            if (MedicationsRemoved != null)
            {
                MedicationsRemoved(this, new EventArgs());
            }
        }
    }
}