using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class GreaterThanOrEqaulToAttribute : IsAttribute
    {
        public GreaterThanOrEqaulToAttribute(string dependentProperty) : base(Operator.GreaterThanOrEqualTo, dependentProperty) { }
    }
}
