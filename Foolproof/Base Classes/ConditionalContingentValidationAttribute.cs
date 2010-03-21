using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public abstract class ConditionContingentAttribute : ContingentAttribute
    {
        public object DependentValue { get; private set; }

        public ConditionContingentAttribute(string dependentProperty, object dependentValue)
            : base(dependentProperty)
        {
            DependentValue = dependentValue;
        }

        public override bool IsValid(object value, object container)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> ClientValidationParameters
        {
            get
            {
                var result = base.ClientValidationParameters;
                result.Add("DependentValue", DependentValue);

                return result;
            }
        }
    }
}
