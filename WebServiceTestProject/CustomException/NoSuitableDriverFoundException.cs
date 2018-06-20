using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTestProject.CustomException
{
    public class NoSuitableDriverFoundException : Exception
    {
        public NoSuitableDriverFoundException(string msg) : base(msg)
        {
        }
    }
}