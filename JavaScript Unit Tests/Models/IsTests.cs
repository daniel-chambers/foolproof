using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foolproof.UnitTests.JavaScript.Models
{
    public class IsTests
    {
        public class EqualToStrings
        {
            public string Value1 { get; set; }

            [EqualTo("Value1")]
            public string Value2 { get; set; }
        }

        public class NotEqualToStrings
        {
            public string Value1 { get; set; }

            [NotEqualTo("Value1")]
            public string Value2 { get; set; }
        }

        public EqualToStrings EqualToStringsValid { get; set; }
        public EqualToStrings EqualToStringsInvalid { get; set; }
        public NotEqualToStrings NotEqualToStringsValid { get; set; }
        public NotEqualToStrings NotEqualToStringsInvalid { get; set; }

        public IsTests()
        {
            EqualToStringsValid = new EqualToStrings() { Value1 = "hello", Value2 = "hello" };
            EqualToStringsInvalid = new EqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
            NotEqualToStringsValid = new NotEqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
            NotEqualToStringsInvalid = new NotEqualToStrings() { Value1 = "hello", Value2 = "hello" };
        }
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