using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foolproof
{
    internal class OperatorMetadata
    {
        public string ErrorMessage { get; set; }
        public Func<object, object, bool> IsValid { get; set; }

        static OperatorMetadata()
        {
            CreateOperatorMetadata();
        }

        private static Dictionary<Operator, OperatorMetadata> _operatorMetadata;

        public static OperatorMetadata Get(Operator @operator)
        {
            return _operatorMetadata[@operator];
        }

        private static void CreateOperatorMetadata()
        {
            _operatorMetadata = new Dictionary<Operator, OperatorMetadata>()
            {
                {
                    Operator.EqualTo, new OperatorMetadata()
                    {
                        ErrorMessage = "{0} must be equal to {1}.",
                        IsValid = (value, dependentValue) => {
                            if (value == null && dependentValue == null)
                                return true;

                            return value.Equals(dependentValue);
                        }
                    }
                },
                {
                    Operator.NotEqualTo, new OperatorMetadata()
                    {
                        ErrorMessage = "{0} must be not equal to {1}.",
                        IsValid = (value, dependentValue) => {
                            if (value == null && dependentValue != null)
                                return true;

                            return !value.Equals(dependentValue);
                        }
                    }
                },
                {
                    Operator.GreaterThan, new OperatorMetadata()
                    {
                        ErrorMessage = "{0} must be greater than {1}.",
                        IsValid = (value, dependentValue) => { return Comparer<object>.Default.Compare(value, dependentValue) == 1; }
                    }
                },
                {
                    Operator.LessThan, new OperatorMetadata()
                    {
                        ErrorMessage = "{0} must be less than {1}.",
                        IsValid = (value, dependentValue) => { return Comparer<object>.Default.Compare(value, dependentValue) == -1; }
                    }
                },
                {
                    Operator.GreaterThanOrEqualTo, new OperatorMetadata()
                    {
                        ErrorMessage = "{0} must be greater than or equal to {1}.",
                        IsValid = (value, dependentValue) => { return Get(Operator.EqualTo).IsValid(value, dependentValue) || Comparer<object>.Default.Compare(value, dependentValue) == 1; }
                    }
                },
                {
                    Operator.LessThanOrEqualTo, new OperatorMetadata()
                    {
                        ErrorMessage = "{0} must be less than or equal to {1}.",
                        IsValid = (value, dependentValue) => { return Get(Operator.EqualTo).IsValid(value, dependentValue) || Comparer<object>.Default.Compare(value, dependentValue) == -1; }
                    }
                }
            };
        }
    }
}
