using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class RequiredIfEmptyAttribute : ContingentAttribute
    {
        public RequiredIfEmptyAttribute(string dependentProperty)
            : base(dependentProperty) { }

        public override bool IsValid(object value, object container)
        {
            var dependentPropertyValue = GetDependentPropertyValue(container);

            if (string.IsNullOrEmpty((dependentPropertyValue ?? string.Empty).ToString().Trim()))
                return value != null && !string.IsNullOrEmpty(value.ToString().Trim());

            return true;
        }

        public override string DefaultErrorMessage
        {
            get { return "{1} is required."; }
        }
    }
}
