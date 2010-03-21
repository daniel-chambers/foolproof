using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class EqualToAttributeTest
    {
        private class Model : ModelBase
        {
            public string Password { get; set; }

            [EqualTo("Password")]
            public string RetypePassword { get; set; }
        }

        [TestMethod()]
        public void IsValid()
        {
            var model = new Model() { Password = "hello", RetypePassword = "hello" };
            Assert.IsTrue(model.IsValid<EqualToAttribute>("RetypePassword"));
        }

        [TestMethod()]
        public void IsNotValid()
        {
            var model = new Model() { Password = "hello", RetypePassword = "hello2" };
            Assert.IsFalse(model.IsValid<EqualToAttribute>("RetypePassword"));
        }
    }
}
