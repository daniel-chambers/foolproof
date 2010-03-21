using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class IsAttribute : ContingentAttribute
    {
        public Operator Operator { get; private set; }
        private OperatorMetadata _metadata;

        public IsAttribute(Operator @operator, string dependentProperty)
            : base(dependentProperty)
        {
            Operator = @operator;
            _metadata = OperatorMetadata.Get(Operator);
        }

        public override string DefaultErrorMessage
        {
            get { return _metadata.ErrorMessage; }
        }

        public override bool IsValid(object value, object container)
        {
            return _metadata.IsValid(value, GetDependentPropertyValue(container));
        }

        public override string ClientTypeName
        {
            get { return "Is"; }
        }

        public override Dictionary<string, object> ClientValidationParameters
        {
            get
            {
                var result = base.ClientValidationParameters;
                result.Add("Operator", Operator.ToString());

                return result;
            }
        }
    }
}
