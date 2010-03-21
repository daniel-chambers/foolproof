using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class RequiredIfEmptyAttributeTest
    {
        private class Model : ModelBase
        {
            public string Value1 { get; set; }

            [RequiredIfEmpty("Value1")]
            public string Value2 { get; set; }
        }

        [TestMethod()]
        public void IsValid()
        {
            var model = new Model() { Value1 = "", Value2 = "hello" };
            Assert.IsTrue(model.IsValid<RequiredIfEmptyAttribute>("Value2"));
        }

        [TestMethod()]
        public void IsValidWithNull()
        {
            var model = new Model() { Value1 = null, Value2 = "hello" };
            Assert.IsTrue(model.IsValid<RequiredIfEmptyAttribute>("Value2"));
        }

        [TestMethod()]
        public void IsNotRequired()
        {
            var model = new Model() { Value1 = "hello", Value2 = "" };
            Assert.IsTrue(model.IsValid<RequiredIfEmptyAttribute>("Value2"));
        }

        [TestMethod()]
        public void IsNotValid()
        {
            var model = new Model() { Value1 = "", Value2 = "" };
            Assert.IsFalse(model.IsValid<RequiredIfEmptyAttribute>("Value2"));
        }
    }
}
