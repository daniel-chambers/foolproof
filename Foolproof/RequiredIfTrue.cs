using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class RequiredIfTrueAttribute : RequiredIfAttribute
    {
        public RequiredIfTrueAttribute(string dependentProperty) : base(dependentProperty, Operator.EqualTo, true) { }
    }
}
