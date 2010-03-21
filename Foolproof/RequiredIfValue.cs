using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    public class RequiredIfValueAttribute : RequiredIfAttribute
    {
        public RequiredIfValueAttribute(string dependentProperty, object dependentValue) : base(dependentProperty, Operator.EqualTo, dependentValue) { }
    }
}
