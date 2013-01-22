using System;

namespace MappingExample
{
    public class Address
    {
        public virtual int AddressId { get; set; }

        public virtual string PropertyName{ get; set; }

        public virtual int PropertyNumber { get; set; }

        public virtual string PostCode { get; set; }

        public string LookupPostcode()
        { 
            throw new NotImplementedException();
        }

    }
}
