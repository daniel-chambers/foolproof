using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class GreaterThanAttributeTest
    {
        private class Model : ModelBase
        {
            public DateTime Start { get; set; }

            [GreaterThan("Start")]
            public DateTime End { get; set; }
        }

        [TestMethod()]
        public void IsValid()
        {
            var model = new Model() { Start = DateTime.Now, End = DateTime.Now.AddDays(1) };
            Assert.IsTrue(model.IsValid<GreaterThanAttribute>("End"));
        }

        [TestMethod()]
        public void IsNotValid()
        {
            var model = new Model() { Start = DateTime.Now, End = DateTime.Now.AddDays(-1) };
            Assert.IsFalse(model.IsValid<GreaterThanAttribute>("End"));
        }    
    }
}
