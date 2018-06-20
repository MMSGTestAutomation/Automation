using System;

namespace WebServiceTestProject.CustomException
{
    public class NoSutiableDriverFound : Exception
    {
        public NoSutiableDriverFound(string msg) : base(msg)
        {
        }
    }
}