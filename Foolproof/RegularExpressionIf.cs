using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class RegularExpressionIfAttribute : RequiredIfAttribute
    {
        public string Pattern { get; set; }

        public RegularExpressionIfAttribute(string pattern, string dependentProperty, Operator @operator, object dependentValue)
            : base(dependentProperty, @operator, dependentValue)
        {
            Pattern = pattern;
        }

        public RegularExpressionIfAttribute(string pattern, string dependentProperty, object dependentValue)
            : this(pattern, dependentProperty, Operator.EqualTo, dependentValue) { }

        public override bool IsValid(object value, object dependentValue, object container)
        {
            if (Metadata.IsValid(dependentValue, DependentValue))
                return OperatorMetadata.Get(Operator.RegExMatch).IsValid(value, Pattern);

            return true;
        }

        protected override IEnumerable<KeyValuePair<string, object>> GetClientValidationParameters()
        {
            return base.GetClientValidationParameters()
                .Union(new[] {
                    new KeyValuePair<string, object>("Pattern", Pattern),
                });
        }

        public override string DefaultErrorMessage
        {
            get { return "{0} must be in the format of " + Pattern + " due to {1} being " + Metadata.ErrorMessage + " {2}"; }
        }
    }
}
