using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class RequiredIfTrueAttribute : ContingentAttribute
    {
        public RequiredIfTrueAttribute(string dependentProperty) : base(dependentProperty) { }

        public override bool IsValid(object value, object container)
        {
            var dependentPropertyValue = GetDependentPropertyValue(container) as bool?;

            if (dependentPropertyValue ?? false)
                return value != null && !string.IsNullOrEmpty(value.ToString().Trim());

            return true;
        }
    }
}
