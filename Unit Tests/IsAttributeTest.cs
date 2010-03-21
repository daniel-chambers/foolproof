using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class IsAttributeTest
    {
        class EqualToModel : ModelBase
        {
            public string Value1 { get; set; }

            [Is(Operator.EqualTo, "Value1")]
            public string Value2 { get; set; }
        }

        class NotEqualToModel : ModelBase
        {
            public string Value1 { get; set; }

            [Is(Operator.NotEqualTo, "Value1")]
            public string Value2 { get; set; }
        }

        class GreaterThanModel : ModelBase
        {
            public DateTime Start { get; set; }

            [Is(Operator.GreaterThan, "Start")]
            public DateTime End { get; set; }
        }

        class LessThanModel : ModelBase
        {
            [Is(Operator.LessThan, "End")]
            public DateTime Start { get; set; }

            public DateTime End { get; set; }
        }

        class GreaterThanOrEqualToModel : ModelBase
        {            
            public DateTime Start { get; set; }

            [Is(Operator.GreaterThanOrEqualTo, "End")]
            public DateTime End { get; set; }
        }

        class LessThanOrEqualToModel : ModelBase
        {
            [Is(Operator.LessThanOrEqualTo, "Start")]
            public DateTime Start { get; set; }
            
            public DateTime End { get; set; }
        }

        [TestMethod()]
        public void IsGreaterThanValidTest()
        {
            var model = new GreaterThanModel() { Start = DateTime.Now, End = DateTime.Now.AddDays(1) };
            Assert.IsTrue(model.IsValid<IsAttribute>("End"));
        }

        [TestMethod()]
        public void IsLessThanValidTest()
        {
            var model = new LessThanModel() { Start = DateTime.Now, End = DateTime.Now.AddDays(1) };
            Assert.IsTrue(model.IsValid<IsAttribute>("Start"));
        }

        [TestMethod()]
        public void IsEqualToValidTest()
        {
            var model = new EqualToModel() { Value1 = "hello", Value2 = "hello" };
            Assert.IsTrue(model.IsValid<IsAttribute>("Value2"));
        }

        [TestMethod()]
        public void IsNotEqualToValidTest()
        {
            var model = new NotEqualToModel() { Value1 = "hello", Value2 = "goodbye" };
            Assert.IsTrue(model.IsValid<IsAttribute>("Value2"));
        }

        [TestMethod()]
        public void IsGreaterThanOrEqualToValidTest()
        {
            var model = new GreaterThanOrEqualToModel() { Start = DateTime.Now, End = DateTime.Now.AddDays(1) };
            Assert.IsTrue(model.IsValid<IsAttribute>("End"));

            var date = DateTime.Now;

            model = new GreaterThanOrEqualToModel() { Start = date, End = date };
            Assert.IsTrue(model.IsValid<IsAttribute>("End"));
        }

        [TestMethod()]
        public void IsLessThanOrEqualToValidTest()
        {
            var model = new LessThanOrEqualToModel() { Start = DateTime.Now, End = DateTime.Now.AddDays(1) };
            Assert.IsTrue(model.IsValid<IsAttribute>("Start"));

            var date = DateTime.Now;

            model = new LessThanOrEqualToModel() { Start = date, End = date };
            Assert.IsTrue(model.IsValid<IsAttribute>("Start"));
        }
    }
}
