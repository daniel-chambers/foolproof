using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class RequiredIfTrueAttributeTest
    {
        private class Model : ModelBase
        {
            public bool Married { get; set; }

            [RequiredIfTrue("Married")]
            public string MaidenName { get; set; }
        }

        [TestMethod()]
        public void IsValidTest()
        {
            var model = new Model() { Married = true, MaidenName = "Smith" };
            Assert.IsTrue(model.IsValid<RequiredIfTrueAttribute>("MaidenName"));
        }

        [TestMethod()]
        public void IsNotRequiredTest()
        {
            var model = new Model() { Married = false, MaidenName = "" };
            Assert.IsTrue(model.IsValid<RequiredIfTrueAttribute>("MaidenName"));
        }

        [TestMethod()]
        public void IsNotValidTest()
        {
            var model = new Model() { Married = true, MaidenName = "" };
            Assert.IsFalse(model.IsValid<RequiredIfTrueAttribute>("MaidenName"));
        }
    }
}
