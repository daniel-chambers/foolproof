using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Foolproof;

namespace Foolproof.UnitTests
{
    abstract class ModelBase
    {
        public T GetAttribute<T>(string property) where T : ContingentAttribute
        {
            return (T)this.GetType().GetProperty(property).GetCustomAttributes(typeof(T), false)[0];
        }

        public bool IsValid<T>(string property) where T : ContingentAttribute
        {
            var attribute = this.GetAttribute<T>(property);
            return attribute.IsValid(this.GetType().GetProperty(property).GetValue(this, null), this);
        }
    }

    //static public class Utilities
    //{
    //    public static T GetAttribute<T>(this object model, string property) where T : Attribute
    //    {
    //        return (T)model.GetType().GetProperty(property).GetCustomAttributes(typeof(T), false)[0];
    //    }

    //    public static bool IsValidTest<T>(this object model, string property) where T : FoolproofAttribute
    //    {
    //        var attribute = model.GetAttribute<T>(property);

    //        return attribute.IsValid(model.GetType().GetProperty(property).GetValue(model, null), model);
    //    }
    //}
}
