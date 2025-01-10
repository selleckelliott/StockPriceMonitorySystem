using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitorySystem.Observers
{
  public class EmailAlert : IObserver
  {
    public void Update(string stockSymbol, double stockPrice)
    {
      Console.WriteLine($"[EMAIL ALERT]: Stock {stockSymbol} is now ${stockPrice:F2}");
    }
  }
}
