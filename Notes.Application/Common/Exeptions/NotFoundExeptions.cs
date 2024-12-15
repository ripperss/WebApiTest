using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Common.Exeptions
{
    public class NotFoundExeptions : Exception
    {
        public NotFoundExeptions(string name, object key) : base($"Entity {name}  ({key}) not found." ) 
        { 

        }
    }
}
