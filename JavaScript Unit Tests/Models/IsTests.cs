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
            EqualStringFail2 = "hello";

            EqualStringPass1 = "hello";
            EqualStringPass2 = "hello";

            NotEqualStringFail1 = "hello";
            NotEqualStringFail2 = "hello";

            NotEqualStringPass1 = "";
            NotEqualStringPass2 = "hello";
        }

        public string EqualStringFail1 { get; set; }
        [EqualTo("EqualStringFail1")]
        public string EqualStringFail2 { get; set; }

        public string EqualStringPass1 { get; set; }
        [EqualTo("EqualStringPass1")]
        public string EqualStringPass2 { get; set; }

        public string NotEqualStringFail1 { get; set; }
        [NotEqualTo("NotEqualStringFail1")]
        public string NotEqualStringFail2 { get; set; }

        public string NotEqualStringPass1 { get; set; }
        [NotEqualTo("NotEqualStringPass1")]
        public string NotEqualStringPass2 { get; set; }
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