using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle_Windsor_AOP.DTOs
{
    public class Trade
    {
        public Guid TradeId { get; set; }

        public DateTime DateExecuted { get; set; }
    }
}
