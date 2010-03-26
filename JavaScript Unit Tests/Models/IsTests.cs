using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foolproof.UnitTests.JavaScript.Models
{
    public class IsTests
    {
        public IsTests()
        {
            EqualString2 = "hello";
        }

        public string EqualString1 { get; set; }
        [EqualTo("EqualString1")]
        public string EqualString2 { get; set; }
    }

    public partial class Model
    {
        public Model()
        {
            IsTests = new IsTests();
        }

        public IsTests IsTests { get; set; }
    }
}