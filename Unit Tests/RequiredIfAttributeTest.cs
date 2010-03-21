using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class RequiredIfAttributeTest
    {
        private class Model : ModelBase
        {
            public string Value1 { get; set; }

            [RequiredIf("Value1", Operator.EqualTo, "hello")]
            public string Value2 { get; set; }
        }

        private class TrueModel : ModelBase
        {
            public bool Married { get; set; }

            [RequiredIf("Married", Operator.EqualTo, true)]
            public string MaidenName { get; set; }
        }

        [TestMethod()]
        public void IsValid()
        {
            var model = new Model() { Value1 = "hello", Value2 = "hello" };
            Assert.IsTrue(model.IsValid<RequiredIfAttribute>("Value2"));
        }

        [TestMethod()]
        public void IsNotRequired()
        {
            var model = new Model() { Value1 = "goodbye" };
            Assert.IsTrue(model.IsValid<RequiredIfAttribute>("Value2"));
        }

        [TestMethod()]
        public void IsNotValid()
        {
            var model = new Model() { Value1 = "hello" };
            Assert.IsFalse(model.IsValid<RequiredIfAttribute>("Value2"));
        }

        [TestMethod()]
        public void IsTrueValid()
        {
            var model = new TrueModel() { Married = true, MaidenName = "hello" };
            Assert.IsTrue(model.IsValid<RequiredIfAttribute>("MaidenName"));
        }    
    }
}
