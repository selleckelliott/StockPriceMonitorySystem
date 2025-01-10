﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitorySystem.Observers
{
  public class ConsoleLogger : IObserver
  {
    public void Update(string stockSymbol, double stockPrice)
    {
      Console.WriteLine($"[LOG]: Stock {stockSymbol} is now ${stockPrice:F2}");
    }
  }
}
