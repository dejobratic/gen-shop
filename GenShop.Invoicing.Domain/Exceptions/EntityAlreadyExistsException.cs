using System;

namespace GenShop.Invoicing.Domain.Exceptions
{
    public class EntityAlreadyExistsException :
        Exception
    {
        public EntityAlreadyExistsException(Type type)
            : base($"{type.Name} already exists.")
        {
        }
    }
}
