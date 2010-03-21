using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Foolproof
{
    public static class Register
    {
        public static void Attribute(Type contingentAttributeType)
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(contingentAttributeType, typeof(ContingentValidator));
        }

        internal static void All()
        {
            Attribute(typeof(RequiredIfAttribute));
            Attribute(typeof(RequiredIfNotAttribute));
            Attribute(typeof(RequiredIfTrueAttribute));
            Attribute(typeof(RequiredIfFalseAttribute));
            Attribute(typeof(RequiredIfEmptyAttribute));
            Attribute(typeof(RequiredIfNotEmptyAttribute));
            Attribute(typeof(EqualToAttribute));
        }
    }
}
