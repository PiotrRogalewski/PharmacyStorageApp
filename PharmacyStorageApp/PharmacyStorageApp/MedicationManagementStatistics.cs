namespace PharmacyStorageApp
{
    public class MedicationManagementStatistics
    {
        public float MinimalAddition { get; private set; }

        public float MaximumAddition { get; private set; }

        public float SumOfAddition { get; private set; }

        public int AddCounter { get; private set; }

        public float AverageOfAdditions
        {
            get
            {
                var average1 = this.SumOfAddition / this.AddCounter;
                average1 = (float)Math.Round(average1, 2);
                return average1;
            }
        }

        public float MinimalSubtraction { get; private set; }

        public float MaximumSubtraction { get; private set; }

        public float SumOfSubtraction { get; private set; }

        public int SubtractionCounter { get; private set; }

        public float AverageOfRemoval
        {
            get
            {
                var average2 = this.SumOfSubtraction / this.SubtractionCounter;
                average2 = (float)Math.Round(average2, 2);
                return average2;
            }
        }

        public string AverageOfAdditionsAsText
        {
            get
            {
                switch (this.AverageOfAdditions)
                {
                    case var average1 when average1 >= 80:
                        return "A class medications supplier";
                    case var average1 when average1 >= 60:
                        return "B class medications supplier";
                    case var average1 when average1 >= 40:
                        return "C class medications supplier";
                    case var average1 when average1 >= 20:
                        return "D class medications supplier";
                    case var average1 when average1 < 20 && average1 > 0:
                        return "E class medications supplier";
                    default:
                        return "undefined";
                }
            }
        }

        public char AverageOfRemovalAsLetter
        {
            get
            {
                switch (this.AverageOfRemoval)
                {
                    case var average2 when average2 >= 16:
                        return 'A';
                    case var average2 when average2 >= 12:
                        return 'B';
                    case var average2 when average2 >= 8:
                        return 'C';
                    case var average2 when average2 >= 4:
                        return 'D';
                    case var average2 when average2 > 0 && average2 < 4:
                        return 'E';
                    default:
                        return 'u';
                }
            }
        }

        public float AvailableMedications
        {
            get
            {
                var medicinesInStock = this.SumOfAddition - this.SumOfSubtraction;

                if (medicinesInStock > 0 && medicinesInStock < 600)
                {
                    return medicinesInStock;
                }
                else if (medicinesInStock == 600)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n    Warning! This storage area is full!\n");
                    Console.ResetColor();
                    return medicinesInStock;
                }
                else if (medicinesInStock > 600)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n    Error! In this storage area should be no more than 600 medicines in stock.\n");
                    Console.ResetColor();
                    medicinesInStock = 600;
                    return medicinesInStock;
                }
                else if (medicinesInStock == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n    Warning! This storage area is empty!\n");
                    Console.ResetColor();
                    return medicinesInStock;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n    Error! In the storage area must be no less than 0 medicines in stock.\n");
                    Console.ResetColor();
                    medicinesInStock = 0;
                    return medicinesInStock;
                }
            }
        }

        public MedicationManagementStatistics()
        {
            this.AddCounter = 0;
            this.SubtractionCounter = 0;
            this.SumOfAddition = 0;
            this.SumOfSubtraction = 0;
            this.MaximumAddition = float.MinValue;
            this.MinimalAddition = float.MaxValue;
            this.MaximumSubtraction = float.MaxValue;
            this.MinimalSubtraction = float.MinValue;
        }

        public void PutMedicineOnTheShelf(float medicines)
        {
            this.AddCounter++;
            this.SumOfAddition += medicines;
            this.MinimalAddition = Math.Min(medicines, this.MinimalAddition);
            this.MinimalAddition = (float)Math.Round(this.MinimalAddition, 2);
            this.MaximumAddition = Math.Max(medicines, this.MaximumAddition);
            this.MaximumAddition = (float)Math.Round(this.MaximumAddition, 2);
        }

        public void TakeTheMedicineFromTheShelf(float medicines)
        {
            this.SubtractionCounter++;
            this.SumOfSubtraction -= medicines;
            this.MinimalSubtraction = Math.Max(medicines, this.MinimalSubtraction);
            this.MinimalSubtraction = (float)Math.Round(this.MinimalSubtraction, 2);
            this.MaximumSubtraction = Math.Min(medicines, this.MaximumSubtraction);
            this.MaximumSubtraction = (float)Math.Round(this.MaximumSubtraction, 2);
        }
    }
}