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
        private static List<Trade> _tradeListing = new List<Trade>
            {
                new Trade 
                {
                    TradeId = Guid.NewGuid(),
                    DateExecuted = DateTime.UtcNow
                },
                new Trade 
                {
                    TradeId = Guid.NewGuid(),
                    DateExecuted = DateTime.UtcNow
                },
                new Trade 
                {
                    TradeId = Guid.NewGuid(),
                    DateExecuted = DateTime.UtcNow
                },
            };

        /// <summary>
        /// Adds a new trade to the list.
        /// </summary>
        /// <param name="tradeToAdd">The trade to add to the listing.</param>
        public void AddTrade(Trade tradeToAdd)
        {
            _tradeListing.Add(tradeToAdd);
        }

        /// <summary>
        /// Returns a list of all the trades executed today.
        /// </summary>
        /// <returns>A list of trades.</returns>
        public List<Trade> GetTodaysTrades()
        {
            return _tradeListing;
        }

        /// <summary>
        /// Logs the current user in to the system.
        /// </summary>
        public void Login()
        {
            PermissionsStub.IsUserPermittedToContinue = true;
        }
    }
}
