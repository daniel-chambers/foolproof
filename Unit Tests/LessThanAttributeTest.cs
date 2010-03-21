using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class LessThanAttributeTest
    {
        private class Model : ModelBase
        {
            [LessThan("End")]
            public DateTime Start { get; set; }                        
            public DateTime End { get; set; }
        }

        [TestMethod()]
        public void IsValid()
        {
            var model = new Model() { Start = DateTime.Now, End = DateTime.Now.AddDays(1) };
            Assert.IsTrue(model.IsValid<LessThanAttribute>("Start"));
        }

        [TestMethod()]
        public void IsNotValid()
        {
            var model = new Model() { Start = DateTime.Now, End = DateTime.Now.AddDays(-1) };
            Assert.IsFalse(model.IsValid<LessThanAttribute>("Start"));
        }  
    }
}
