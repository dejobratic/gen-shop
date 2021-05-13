using System;

namespace GenShop.Invoicing.Domain.Exceptions
{
    public class EntityNotFoundException :
        Exception
    {
        public EntityNotFoundException(Type type)
            : base($"{type.Name} not found.")
        {
        }
    }
}
