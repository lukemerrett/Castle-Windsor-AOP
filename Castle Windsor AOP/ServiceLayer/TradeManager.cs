using Castle_Windsor_AOP.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle_Windsor_AOP.ServiceLayer
{
    /// <summary>
    /// Responsible for CRUD operations against <see cref="Trade"/> objects.
    /// </summary>
    public class TradeManager : Castle_Windsor_AOP.ServiceLayer.ITradeManager
    {
        /// <summary>
        /// Returns a list of all the trades executed today.
        /// </summary>
        /// <returns>A list of trades.</returns>
        public List<Trade> GetTodaysTrades()
        {
            return new List<Trade>
            {
                new Trade 
                {
                    TradeId = 1,
                    DateExecuted = DateTime.UtcNow
                },
                new Trade 
                {
                    TradeId = 2,
                    DateExecuted = DateTime.UtcNow
                },
                new Trade 
                {
                    TradeId = 3,
                    DateExecuted = DateTime.UtcNow
                },
            };
        }
    }
}
