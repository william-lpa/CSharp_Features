using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintaxFeatures
{
    class ReadOnlyAutoProperties
    {
        public ReadOnlyAutoProperties()
        {
            var _readonly = new AutoPropertiesReadOnly();
            _readonly.ChangeName();
            var _notReadonly = new AutoPropertiesNotReadOnly();
            _notReadonly.ChangeName();
        }
    }

    class AutoPropertiesReadOnly
    {
        public string Name { get; }
        public int Age { get; }
        public AutoPropertiesReadOnly()
        {
            Name = "Gomes";
            Age = 21;
        }
        public void ChangeName()
        {
            Name = "Lucas";
        }
    }
    class AutoPropertiesNotReadOnly
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public AutoPropertiesNotReadOnly()
        {
            Name = "Bianca";
            Age = 21;
        }
        public void ChangeName()
        {
            Name = "Josie";
        }
    }

}

