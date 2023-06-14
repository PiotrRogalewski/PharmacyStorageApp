using NUnit.Framework;
using NUnit.Framework.Internal;

namespace PharmacyStorageApp.Tests
{
    public class TypeTest
    {
        [Test]
        public void WhenComparingTwoTypes_ShouldCheckIfTheyAreDifferent()
        {
            var medicine1 = GetMedicine("lozenges", "s", "bl", 12);
            var medicine2 = GetMedicine("cough syrup", "l", "bo", 1);

            Assert.AreNotEqual(medicine1, medicine2);

        }

        [Test]
        public void WhenComparingTwoTypes_ShouldCheckIfTheyAreTheSame()
        {
            var medicine3 = GetMedicine("dressing plaster", "s", "pp", 10);
            var medicine4 = medicine3;

            Assert.AreEqual(medicine3, medicine4);
        }

        private MedicinesInMemory GetMedicine(string categoryName, string stateOfMatter, string typeOfPackaging, int totalPackageCapacity)
        {
            return new MedicinesInMemory(categoryName, stateOfMatter, typeOfPackaging, totalPackageCapacity);
        }
    }
}
