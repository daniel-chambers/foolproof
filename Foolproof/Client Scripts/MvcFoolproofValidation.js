Sys.Mvc.ValidatorRegistry.validators["Is"] = function (rule) {
    var dependentProperty = rule.ValidationParameters["DependentProperty"];
    var operator = rule.ValidationParameters["Operator"];
    return function (value, context) {
        var dependentValue = document.getElementById(dependentProperty).value;

        switch (operator) {
            case "EqualTo": if (value == dependentValue) return true; break;
            case "NotEqualTo": if (value != dependentValue) return true; break;
            case "GreaterThan": if (value > dependentValue) return true; break;
            case "LessThan": if (value < dependentValue) return true; break;
            case "GreaterThanOrEqualTo": if (value >= dependentValue) return true; break;
            case "LessThanOrEqualTo": if (value <= dependentValue) return true; break;
        }

        return rule.ErrorMessage;
    };
};
