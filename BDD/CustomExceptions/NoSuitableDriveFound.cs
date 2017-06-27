using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.CustomExceptions
{
   public class NoSuitableDriveFound :Exception
    {
        public NoSuitableDriveFound(String message) : base(message)
        {
        }
    }
}
