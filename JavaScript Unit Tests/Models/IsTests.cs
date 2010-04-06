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

        public class GreaterThanDates
        {
            public DateTime Value1 { get; set; }

            [GreaterThan("Value1")]
            public DateTime Value2 { get; set; }
        }

        public EqualToStrings EqualToStringsValid { get; set; }
        public EqualToStrings EqualToStringsInvalid { get; set; }
        public NotEqualToStrings NotEqualToStringsValid { get; set; }
        public NotEqualToStrings NotEqualToStringsInvalid { get; set; }
        public GreaterThanDates GreaterThanDatesValid { get; set; }
        public GreaterThanDates GreaterThanDatesInvalid { get; set; }

        public IsTests()
        {
            EqualToStringsValid = new EqualToStrings() { Value1 = "hello", Value2 = "hello" };
            EqualToStringsInvalid = new EqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
            NotEqualToStringsValid = new NotEqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
            NotEqualToStringsInvalid = new NotEqualToStrings() { Value1 = "hello", Value2 = "hello" };
            GreaterThanDatesValid = new GreaterThanDates() { Value1 = DateTime.Now.AddDays(-1), Value2 = DateTime.Now };
            GreaterThanDatesInvalid = new GreaterThanDates() { Value1 = DateTime.Now.AddDays(1), Value2 = DateTime.Now };
        }
    }

    public partial class Model
    {
        public IsTests IsTests = new IsTests();
    }
}