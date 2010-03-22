var foolproof = function () { };
foolproof.is = function (value1, operator, value2) {
    var isNumeric = function (input) {
        return (input - 0) == input && input.length > 0;
    };

    if (!!Date.parse(value1)) {
        value1 = Date.parse(value1);
        value2 = Date.parse(value2);
    }
    else if (!!Boolean.parse(value1)) {
        value1 = Boolean.parse(value1);
        value2 = Boolean.parse(value2);
    }
    else if (isNumeric(value1)) {
        value1 = parseFloat(value1);
        value2 = parseFloat(value2);
    }

    switch (operator) {
        case "EqualTo": if (value1 == value2) return true; break;
        case "NotEqualTo": if (value1 != value2) return true; break;
        case "GreaterThan": if (value1 > value2) return true; break;
        case "LessThan": if (value1 < value2) return true; break;
        case "GreaterThanOrEqualTo": if (value1 >= value2) return true; break;
        case "LessThanOrEqualTo": if (value1 <= value2) return true; break;
    }

    return false;
};

Sys.Mvc.ValidatorRegistry.validators["Is"] = function (rule) {
    var dependentProperty = rule.ValidationParameters["DependentProperty"];
    var operator = rule.ValidationParameters["Operator"];
    return function (value, context) {
        var dependentValue = document.getElementById(dependentProperty).value;

        if (foolproof.is(value, operator, dependentValue))
            return true;

        return rule.ErrorMessage;
    };
};

Sys.Mvc.ValidatorRegistry.validators["RequiredIf"] = function (rule) {
    var dependentProperty = rule.ValidationParameters["DependentProperty"];
    var dependentTestValue = rule.ValidationParameters["DependentValue"];
    var operator = rule.ValidationParameters["Operator"];
    return function (value, context) {
        var dependentValue = document.getElementById(dependentProperty).value;

        if (foolproof.is(dependentTestValue, operator, dependentValue))
            if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
                return true;

        return rule.ErrorMessage;
    };
};

Sys.Mvc.ValidatorRegistry.validators["RequiredIfEmpty"] = function (rule) {
    var dependentProperty = rule.ValidationParameters["DependentProperty"];
    return function (value, context) {
        var dependentValue = document.getElementById(dependentProperty).value;

        if (dependentValue == null || dependentValue.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') == "") {
            if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
                return true;
        }
        else
            return true;

        return rule.ErrorMessage;
    };
};

Sys.Mvc.ValidatorRegistry.validators["RequiredIfNotEmpty"] = function (rule) {
    var dependentProperty = rule.ValidationParameters["DependentProperty"];
    return function (value, context) {
        var dependentValue = document.getElementById(dependentProperty).value;

        if (dependentValue != null && dependentValue.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "") {
            if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
                return true;
        }
        else
            return true;

        return rule.ErrorMessage;
    };
};