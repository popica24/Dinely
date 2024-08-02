using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dinely.Domain.Common.Models;

namespace Dinely.Domain.Bill.ValueObjects
{
    public class BillId : ValueObject
    {
        public Guid Value { get; }

        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new BillId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}