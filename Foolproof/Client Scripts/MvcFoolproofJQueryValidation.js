//version: 0.1.3747.36017

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

function __MVC_ApplyValidator_RequiredIf() {
}

__MVC_ApplyValidator_Unknown = function (rules, type, params) {
    rules[type] = params;
};

jQuery.validator.addMethod("Is", function (value, element, params) {
    var dependentProperty = foolproof.getId(element, params["DependentProperty"]);
    var operator = params["Operator"];
    var dependentValue = document.getElementById(dependentProperty).value;

    if (foolproof.is(value, operator, dependentValue))
        return true;

    return false;
});

jQuery.validator.addMethod("RequiredIf", function (value, element, params) {
    var dependentProperty = foolproof.getName(element, params["DependentProperty"]);
    var dependentTestValue = params["DependentValue"];
    var operator = params["Operator"];
    var pattern = params["Pattern"];
    var dependentPropertyElement = document.getElementsByName(dependentProperty);
    var dependentValue = null;

    if (dependentPropertyElement.length > 1) {
        for (var index = 0; index != dependentPropertyElement.length; index++)
            if (dependentPropertyElement[index]["checked"]) {
                dependentValue = dependentPropertyElement[index].value;
                break;
            }

        if (dependentValue == null)
            return true;
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

    return false;
});

jQuery.validator.addMethod("RequiredIfEmpty", function (value, element, params) {
    var dependentProperty = foolproof.getId(element, params["DependentProperty"]);
    var dependentValue = document.getElementById(dependentProperty).value;

    if (dependentValue == null || dependentValue.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') == "") {
        if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
            return true;
    }
    else
        return true;

    return false;
});

jQuery.validator.addMethod("RequiredIfNotEmpty", function (value, element, params) {
    var dependentProperty = foolproof.getId(element, params["DependentProperty"]);
    var dependentValue = document.getElementById(dependentProperty).value;

    if (dependentValue != null && dependentValue.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "") {
        if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
            return true;
    }
    else
        return true;

    return false;
});