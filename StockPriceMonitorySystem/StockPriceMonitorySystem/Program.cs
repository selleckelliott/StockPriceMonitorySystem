using System;
using System.Threading.Tasks;
using StockPriceMonitorySystem.Observers;
using StockPriceMonitorySystem.Subject;

namespace StockPriceMonitorySystem
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var stockTracker = new StockTracker();

      var consoleLogger = new ConsoleLogger();
      var emailAlert = new EmailAlert();
      var mobileApp = new MobileApp();

      stockTracker.Subscribe(consoleLogger);
      stockTracker.Subscribe(emailAlert);
      stockTracker.Subscribe(mobileApp);

      await stockTracker.FetchAndNotify("AAPL");
      await stockTracker.FetchAndNotify("MSFT");
      await stockTracker.FetchAndNotify("TSLA");
    }
  }
}