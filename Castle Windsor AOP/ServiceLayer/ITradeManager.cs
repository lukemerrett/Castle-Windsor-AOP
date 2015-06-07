using Castle_Windsor_AOP.DTOs;
using Castle_Windsor_AOP.Interceptors.Attributes;
using System;
using System.Collections.Generic;

namespace Castle_Windsor_AOP.ServiceLayer
{
    public interface ITradeManager
    {
        /// <summary>
        /// Adds a new trade to the list.
        /// </summary>
        /// <param name="tradeToAdd">The trade to add to the listing.</param>
        void AddTrade(Trade tradeToAdd);

        /// <summary>
        /// Returns a list of all the trades executed today.
        /// </summary>
        /// <returns>A list of trades.</returns>
        List<Trade> GetTodaysTrades();

        /// <summary>
        /// Logs the current user in to the system.
        /// </summary>
        [DoNotPerformPermissionCheck]
        void Login();
    }
}
