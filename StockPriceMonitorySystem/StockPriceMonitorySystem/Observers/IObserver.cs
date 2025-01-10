using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitorySystem.Observers
{
  public interface IObserver
  {
    void Update(string stockSymbol, double stockPrice);
  }
}
