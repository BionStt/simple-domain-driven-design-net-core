using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MinimalDDD.Domain
{
    public abstract class BaseValidation
    {
        public abstract List<Error> Validate();
        public List<Error> erros { get; set; }
        public bool ExistErros() => erros.Any();
        public BaseValidation(){}

        public List<Error> Push()
        {
            return erros;
        }

        public BaseValidation ValidationConcern()
        {
            erros = new List<Error>();
            return this;
        }

        public BaseValidation AssertArgumentEquals(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentFalse(bool boolValue, string message)
        {
            if (boolValue)
                erros.Add(new Error(message));

            return this;

        }

        public BaseValidation AssertArgumentLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            if (string.IsNullOrEmpty(stringValue))
                stringValue = string.Empty;

            int length = stringValue.Trim().Length;

            if (length < minimum || length > maximum)
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue.Equals(null) || stringValue.Trim().Length.Equals(decimal.Zero))
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentNotEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentNotNull(object object1, string message)
        {
            if (object1.Equals(null))
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
                erros.Add(new Error(message));

            return this;

        }

        public BaseValidation AssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
                erros.Add(new Error(message));

            return this;

        }

        public BaseValidation AssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertArgumentTrue(bool boolValue, string message)
        {
            if (!boolValue)
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertStateFalse(bool boolValue, string message)
        {
            if (boolValue)
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation AssertStateTrue(bool boolValue, string message)
        {
            if (!boolValue)
                erros.Add(new Error(message));

            return this;
        }

        public BaseValidation SelfAssertArgumentEquals(object object1, object object2, string message)
        {
            return AssertArgumentEquals(object1, object2, message);
        }

        public BaseValidation SelfAssertArgumentFalse(bool boolValue, string message)
        {
            return AssertArgumentFalse(boolValue, message);
        }

        public BaseValidation SelfAssertArgumentLength(string stringValue, int maximum, string message)
        {
            return AssertArgumentLength(stringValue, maximum, message);
        }

        public BaseValidation SelfAssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            return AssertArgumentLength(stringValue, minimum, maximum, message);
        }

        public BaseValidation SelfAssertArgumentMatches(string pattern, string stringValue, string message)
        {
            return AssertArgumentMatches(pattern, stringValue, message);
        }

        public BaseValidation SelfAssertArgumentNotEmpty(string stringValue, string message)
        {
            return AssertArgumentNotEmpty(stringValue, message);
        }

        public BaseValidation SelfAssertArgumentNotEquals(object object1, object object2, string message)
        {
            return AssertArgumentNotEquals(object1, object2, message);
        }

        public BaseValidation SelfAssertArgumentNotNull(object object1, string message)
        {
            return AssertArgumentNotNull(object1, message);
        }

        public BaseValidation SelfAssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            return AssertArgumentRange(value, minimum, maximum, message);
        }

        public BaseValidation SelfAssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            return AssertArgumentRange(value, minimum, maximum, message);
        }

        public BaseValidation SelfAssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            return AssertArgumentRange(value, minimum, maximum, message);
        }

        public BaseValidation SelfAssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            return AssertArgumentRange(value, minimum, maximum, message);
        }

        public BaseValidation SelfAssertArgumentTrue(bool boolValue, string message)
        {
            return AssertArgumentTrue(boolValue, message);
        }

        public BaseValidation SelfAssertStateFalse(bool boolValue, string message)
        {
            return AssertStateFalse(boolValue, message);
        }

        public BaseValidation SelfAssertStateTrue(bool boolValue, string message)
        {
            return AssertStateTrue(boolValue, message);
        }
    }
}
