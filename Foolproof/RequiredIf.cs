using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class RequiredIfAttribute : ConditionContingentAttribute
    {
        public RequiredIfAttribute(string dependentProperty, object dependentValue)
            : base(dependentProperty, dependentValue) { }

        public override bool IsValid(object value, object container)
        {
            var dependentPropertyValue = GetDependentPropertyValue(container);

            if (dependentPropertyValue.Equals(DependentValue))
                return value != null && !string.IsNullOrEmpty(value.ToString().Trim());

            return true;
        }
    }
}
