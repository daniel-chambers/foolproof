using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class RequiredIfAttribute : ConditionContingentAttribute
    {
        public Operator Operator { get; private set; }

        public RequiredIfAttribute(string dependentProperty, Operator @operator, object dependentValue)
            : base(dependentProperty, dependentValue)
        {
            Operator = @operator;
        }

        public RequiredIfAttribute(string dependentProperty, object dependentValue)
            : this(dependentProperty, Operator.EqualTo, dependentValue) { }

        public override string DefaultErrorMessage
        {
            get { return "{1} is required."; }
        }

        public override bool IsValid(object value, object container)
        {
            var dependentPropertyValue = GetDependentPropertyValue(container);

            if (OperatorMetadata.Get(Operator).IsValid(dependentPropertyValue, DependentValue))
                return value != null && !string.IsNullOrEmpty(value.ToString().Trim());

            return true;
        }
    }
}
