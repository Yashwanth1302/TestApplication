using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App5.AppResources
{
    public class LocalizedStrings
    {
        private static readonly Resource _resource = new Resource();
        public Resource LocalResource { get { return _resource; } }
    }
}
