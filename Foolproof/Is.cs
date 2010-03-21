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
            ErrorMessage = _metadata.ErrorMessage;
        }

        public override bool IsValid(object value, object container)
        {
            return _metadata.IsValid(value, GetDependentPropertyValue(container));
        }    
    }
}
