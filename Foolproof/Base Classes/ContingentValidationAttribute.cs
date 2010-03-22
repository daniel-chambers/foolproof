using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Foolproof
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ContingentAttribute : ValidationAttribute
    {
        public string DependentProperty { get; private set; }

        static ContingentAttribute()
        {
            Register.All();
        }

        public ContingentAttribute(string dependentProperty)
        {
            DependentProperty = dependentProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null)
                ErrorMessage = DefaultErrorMessage;

            return string.Format(ErrorMessage, name, DependentProperty);
        }
           
        protected object GetDependentPropertyValue(object container)
        {
            return container.GetType()
                .GetProperty(DependentProperty)
                .GetValue(container, null);
        }

        public override bool IsValid(object value)
        {
            throw new NotImplementedException();
        }

        public abstract string DefaultErrorMessage { get; }
        public abstract bool IsValid(object value, object container);

        public virtual string ClientTypeName
        {
            get { return this.GetType().Name.Replace("Attribute", ""); }
        }

        public virtual Dictionary<string, object> ClientValidationParameters
        {
            get
            {
                return new Dictionary<string, object>() {
                    { "DependentProperty", DependentProperty }
                };
            }
        }
    }
}