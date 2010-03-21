using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class RequiredIfNotEmptyAttribute : ContingentAttribute
    {
        public RequiredIfNotEmptyAttribute(string dependentProperty)
            : base(dependentProperty) { ErrorMessage = "{0} is required since {1} is being supplied."; }

        public override bool IsValid(object value, object container)
        {
            var dependentPropertyValue = GetDependentPropertyValue(container);

            if (!string.IsNullOrEmpty((dependentPropertyValue ?? string.Empty).ToString().Trim()))
                return value != null && !string.IsNullOrEmpty(value.ToString().Trim());

            return true;
        }
    }
}
