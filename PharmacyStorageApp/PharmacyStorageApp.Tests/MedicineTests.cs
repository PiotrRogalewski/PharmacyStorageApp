namespace PharmacyStorageApp.Tests
{
    public class MedicineTests
    {
        [Test]
        public void WhenYouAccountMeds_ShouldReturnStatistics()
        {
            // arrange
            var medicineInMemory1 = new MedicinesInMemory("pills", "s", "bl", 24);

            medicineInMemory1.PutMedicineOnTheShelf("big");                 //  value of "big" is:              50
            medicineInMemory1.PutMedicineOnTheShelf('a');                   //  value of 'a' is:                100
            medicineInMemory1.PutMedicineOnTheShelf(80);
            medicineInMemory1.PutMedicineOnTheShelf("30");
            medicineInMemory1.TakeTheMedicineFromTheShelf(-10);
            medicineInMemory1.TakeTheMedicineFromTheShelf("o");             // value of 'o' is:                 -20
                                           // TOTAL SCORE (mecicineInStock) >> value of medicineInStock is:     230

            // act
            var statistics = medicineInMemory1.GetStatistics();


            // assert
            Assert.AreEqual(100, statistics.MaximumAddition, 0.01f);
            Assert.AreEqual(-20, statistics.MaximumSubtraction, 0.01f);

        }

        [Test]
        public void WhenYouAccountMeds_ShouldReturnMedicinesInStock()
        {
            // arrange
            var medicineInMemory1 = new MedicinesInMemory("pills", "s", "bl", 24);

            medicineInMemory1.PutMedicineOnTheShelf("huge");                //  value of "huge" is:             100
            medicineInMemory1.PutMedicineOnTheShelf('f');                   //  value of 'f' is:                50
            medicineInMemory1.PutMedicineOnTheShelf(70);
            medicineInMemory1.TakeTheMedicineFromTheShelf(-5);
            medicineInMemory1.TakeTheMedicineFromTheShelf('n');             // value of 'n' is:                 -10
            medicineInMemory1.TakeTheMedicineFromTheShelf("m");             // value of 'm' is:                 -5
                                           // TOTAL SCORE (mecicineInStock) >> value of medicineInStock is:     200

            // act
            var statistics = medicineInMemory1.GetStatistics();
            var medicinesInStock = statistics.AvailableMedications;
            medicinesInStock = (float)Math.Round(medicinesInStock, 0);
            var result1 = (int)medicinesInStock;


            // assert
            Assert.AreEqual(200, statistics.AvailableMedications);

        }
    }
}