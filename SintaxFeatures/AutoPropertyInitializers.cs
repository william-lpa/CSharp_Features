using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintaxFeatures
{
    class AutoPropertyInitializers
    {
        public AutoPropertyInitializers()
        {
            new BeforeAutoPropertyInitializers("João", "Silva", "000.000.000-00");
            new AfterAutoPropertyInitializers();
        }
    }

    class BeforeAutoPropertyInitializers
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Cpf { get; } = "000.000.000-00";
        public ICollection<double> Grades { get; private set; }

        public BeforeAutoPropertyInitializers(string name, string lastName, string cpf)
        {
            Name = name;
            LastName = lastName;
            Cpf = cpf;
            Grades = new List<double>();
        }
    }
    class AfterAutoPropertyInitializers
    {
        public string Name { get; private set; } = "João";
        public string LastName { get; private set; } = "Silva";
        public string Cpf { get; } = "000.000.000-00";
        public ICollection<double> Grades { get; } = new List<double>();
    }
}
