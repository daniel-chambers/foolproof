using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel;

namespace Foolproof
{
    public class FoolproofModelBinder : DefaultModelBinder
    {
        private Dictionary<PropertyDescriptor, object> _bindOnModelUpdate = new Dictionary<PropertyDescriptor, object>();
              
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);

            foreach (var bindProperty in _bindOnModelUpdate)
                OnPropertyValidated(controllerContext, bindingContext, bindProperty.Key, bindProperty.Value);
        }

        protected override bool OnPropertyValidating(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
        {
            if (!_bindOnModelUpdate.ContainsKey(propertyDescriptor))
                foreach (var attribute in bindingContext.Model.GetType().GetProperty(propertyDescriptor.Name).GetCustomAttributes(false))
                    if (typeof(ContingentAttribute).IsAssignableFrom(attribute.GetType()))
                    {
                        SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
                        _bindOnModelUpdate.Add(propertyDescriptor, value);
                        return false;
                    }

            return true;
        }
    }
}
