using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Foolproof
{
    public class FoolproofValidator : DataAnnotationsModelValidator<ModelAwareValidationAttribute>
    {
        public FoolproofValidator(ModelMetadata metadata, ControllerContext context, ModelAwareValidationAttribute attribute)
            : base(metadata, context, attribute) { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            if (!Attribute.IsValid(Metadata.Model, container))
                yield return new ModelValidationResult { Message = ErrorMessage };                    
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var result = new ModelClientValidationRule()
            {
                ValidationType = Attribute.ClientTypeName,
                ErrorMessage = ErrorMessage       
            };
            
            foreach (var validationParam in Attribute.ClientValidationParameters)
                result.ValidationParameters.Add(validationParam);
            
            yield return result;
        }
    }
}
