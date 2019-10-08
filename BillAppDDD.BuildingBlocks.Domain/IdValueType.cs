using System;

namespace BillAppDDD.BuildingBlocks.Domain
{
    public class IdValueType: IEquatable<IdValueType>
    {
        public IdValueType(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static bool operator ==(IdValueType obj1, IdValueType obj2)
        {
            return obj1.Value == obj2.Value;
        }
        public static bool operator !=(IdValueType obj1, IdValueType obj2)
        {
            return obj1.Value != obj2.Value;
        }

        public bool Equals(IdValueType other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
