using System;

namespace SintaxFeatures
{
    class NameOfExpression
    {
        public NameOfExpression()
        {
            var before = new PersonBeforeNameOfExpression("João", "Augusto");
            var after = new PersonAfterNameOfExpression("Cleber", "Machado");
        }

    }
    class PersonBeforeNameOfExpression : BaseValidation
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                ValidateNullField("firstName");
            }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                ValidateNullField("lastName");
            }
        }
        public PersonBeforeNameOfExpression(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    class PersonAfterNameOfExpression : BaseValidation
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                ValidateNullField(nameof(firstName));
            }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                ValidateNullField(nameof(lastName));
            }
        }
        public PersonAfterNameOfExpression(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    internal class BaseValidation
    {
        protected void ValidateNullField(string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter)) throw new ArgumentException("Cannot be null", parameter);
        }
    }
}
