using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id{ get; set; } // ıd yi intle temsil etmiyoruz
        public DateTime DateTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
