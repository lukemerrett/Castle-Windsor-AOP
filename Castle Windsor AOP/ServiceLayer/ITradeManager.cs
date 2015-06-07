using System;

namespace Castle_Windsor_AOP.ServiceLayer
{
    public interface ITradeManager
    {
        System.Collections.Generic.List<Castle_Windsor_AOP.DTOs.Trade> GetTodaysTrades();
    }
}
