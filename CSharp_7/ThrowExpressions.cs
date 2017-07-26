using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_7
{
    class ThrowExpressions
    {
        void OldSave(IList<Person> customers, Person currentUser)
        {
            if (customers == null || customers.Count == 0) throw new ArgumentException("No customers to save");

            SaveEach("Dbo.Cliente", customers, currentUser);
        }

        void NowSave(IList<Person> customers, Person currentUser)
        {
            SaveEach("dbo.Cliente", (customers == null || customers.Count == 0) ? customers : throw new ArgumentException("No customers to save"), currentUser);
        }

        private void SaveEach(string table, IList<Person> list, Person currentUser)
        {
            throw new NotImplementedException();
        }
    }
    class Person
    {
        public string Name { get; }

        public Person(string name) => Name = name ?? throw new ArgumentNullException("name");

        public string GetFirstName()
        {
            var parts = Name.Split(' ');
            return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
        }
        
    }

}
