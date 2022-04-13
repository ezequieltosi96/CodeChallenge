using System;

namespace CodeChallenge.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, int key) : base($"{name} ID {key} not found.")
        {
        }
    }
}
