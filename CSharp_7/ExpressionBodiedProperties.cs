using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp_7
{
    class ExpressionBodiedProperties
    {
        private string firstName;
        private FileStream serialize;

        public ExpressionBodiedProperties()
        {
            OldFirstName = "William";
            Console.WriteLine(OldFirstName);
            NewFirstName = "William";
            Console.WriteLine(NewFirstName);
            serialize = new FileStream(@"C:\Teste\package.json",FileMode.Open);
        }

        public ExpressionBodiedProperties(string firstName) => NewFirstName = firstName;

        public string OldFirstName
        {
            get { return firstName; }
            set { ValidadeName(value); }
        }
        public string NewFirstName
        {
            get => firstName;
            set => ValidadeName(value);
        }

        private void ValidadeName(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 3)
            {
                firstName = value;
            }
        }

        ~ExpressionBodiedProperties() => serialize?.Dispose(); //elvis

    }
}
