var foolproof = function () { };
foolproof.is = function (value1, operator, value2) {
    var isNumeric = function (input) {
        return (input - 0) == input && input.length > 0;
    };

    if (!!Date.parse(value1)) {
        value1 = Date.parse(value1);
        value2 = Date.parse(value2);
    }
    else if (value1 === true || value1 === false || value1 === "true" || value1 === "false") {
        if (value1 == "false") value1 = false;
        if (value2 == "false") value2 = false;
        value1 = !!value1;
        value2 = !!value2;
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
        case "RegExMatch": return (new RegExp(value2)).test(value1); break;
        case "NotRegExMatch": return !(new RegExp(value2)).test(value1); break;
    }

    return false;
};

foolproof.getId = function (element, dependentPropety) {
    var pos = element.id.lastIndexOf("_") + 1;
    return element.id.substr(0, pos) + dependentPropety;
};

foolproof.getName = function (element, dependentPropety) {
    var pos = element.name.lastIndexOf(".") + 1;
    return element.name.substr(0, pos) + dependentPropety;
};

Sys.Mvc.ValidatorRegistry.validators["Is"] = function (rule) {
    var operator = rule.ValidationParameters["Operator"];
    return function (value, context) {
        var dependentProperty = foolproof.getId(context.fieldContext.elements[0], rule.ValidationParameters["DependentProperty"]);
        var dependentValue = document.getElementById(dependentProperty).value;

        if (foolproof.is(value, operator, dependentValue))
            return true;

        return rule.ErrorMessage;
    };
};

Sys.Mvc.ValidatorRegistry.validators["RequiredIf"] = function (rule) {
    var pattern = rule.ValidationParameters["Pattern"];
    var dependentTestValue = rule.ValidationParameters["DependentValue"];
    var operator = rule.ValidationParameters["Operator"];
    return function (value, context) {
        var dependentProperty = foolproof.getName(context.fieldContext.elements[0], rule.ValidationParameters["DependentProperty"]);
        var dependentPropertyElement = document.getElementsByName(dependentProperty);
        var dependentValue = null;

        if (dependentPropertyElement.length > 1) {
            for (var index = 0; index != dependentPropertyElement.length; index++)
                if (dependentPropertyElement[index]["checked"]) {
                    dependentValue = dependentPropertyElement[index].value;
                    break;
                }

            if (dependentValue == null)
                dependentValue = false
        }
        else
            dependentValue = dependentPropertyElement[0].value;

        if (foolproof.is(dependentValue, operator, dependentTestValue)) {
            if (pattern == null) {
                if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
                    return true;
            }
            else
                return (new RegExp(pattern)).test(value);
        }
        else
            return true;

        return rule.ErrorMessage;
    };
};

Sys.Mvc.ValidatorRegistry.validators["RequiredIfEmpty"] = function (rule) {
    return function (value, context) {
        var dependentProperty = foolproof.getId(context.fieldContext.elements[0], rule.ValidationParameters["DependentProperty"]);
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
    return function (value, context) {
        var dependentProperty = foolproof.getId(context.fieldContext.elements[0], rule.ValidationParameters["DependentProperty"]);
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