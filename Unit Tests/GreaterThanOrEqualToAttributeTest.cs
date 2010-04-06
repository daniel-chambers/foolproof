using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class GreaterThanOrEqualToAttributeTest
    {
        private class DateModel : ModelBase<GreaterThanOrEqualToAttribute>
        {
            public DateTime? Value1 { get; set; }

            [GreaterThanOrEqualTo("Value1")]
            public DateTime? Value2 { get; set; }
        }

        [TestMethod()]
        public void DateIsValid()
        {
            var model = new DateModel() { Value1 = DateTime.Now, Value2 = DateTime.Now.AddDays(1) };
            Assert.IsTrue(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void DateEqualIsValid()
        {
            var date = DateTime.Now;
            var model = new DateModel() { Value1 = date, Value2 = date };
            Assert.IsTrue(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void DateNullValuesIsValid()
        {
            var date = DateTime.Now;
            var model = new DateModel() { };
            Assert.IsTrue(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void DateIsNotValid()
        {
            var model = new DateModel() { Value1 = DateTime.Now, Value2 = DateTime.Now.AddDays(-1) };
            Assert.IsFalse(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void DateWithNullsIsValid()
        {
            var model = new DateModel() { };
            Assert.IsTrue(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void DateWithValue1NullIsNotValid()
        {
            var model = new DateModel() { Value2 = DateTime.Now };
            Assert.IsFalse(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void DateWithValue2NullIsNotValid()
        {
            var model = new DateModel() { Value1 = DateTime.Now };
            Assert.IsFalse(model.IsValid("Value2"));
        }            
    }
}
