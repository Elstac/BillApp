using System;

namespace BillAppDDD.Modules.Bills.Domain.Bills
{
    public class BillId : IEquatable<BillId>
    {
        public BillId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get;}

        public static bool operator ==(BillId obj1, BillId obj2)
        {
            return obj1.Id == obj2.Id;
        }
        public static bool operator !=(BillId obj1, BillId obj2)
        {
            return obj1.Id != obj2.Id;
        }

        public bool Equals(BillId other)
        {
            return Id == other.Id;
        }
    }
}
