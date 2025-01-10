using Newtonsoft.Json;
using DotNetEnv;

namespace StockPriceMonitorySystem.Subject
{
  public class StockTracker
  {
    private readonly List<Observers.IObserver> _observers = new List<Observers.IObserver>();
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string _apiKey;

    /// <summary>
    /// Loads API
    /// </summary>
    /// <exception cref="_apiKey"></exception>
    public StockTracker()
    {
      DotNetEnv.Env.Load();
      var testApiKey = Environment.GetEnvironmentVariable("FINNHUB_API_KEY");
      _apiKey = Environment.GetEnvironmentVariable("FINNHUB_API_KEY") ?? throw new Exception("API Key not found");
    }

    /// <summary>
    /// Adds subscriber to the service.
    /// </summary>
    /// <param name="observer"></param>
    public void Subscribe(Observers.IObserver observer)
    {
      _observers.Add(observer);
    }

    /// <summary>
    /// Removes subscriber from the service.
    /// </summary>
    /// <param name="observer"></param>
    public void Unsubscribe(Observers.IObserver observer)
    {
      _observers.Remove(observer);
    }

    /// <summary>
    /// Gets current stock price for the selected symbol and notifies the different observers.
    /// </summary>
    /// <param name="stockSymbol"></param>
    /// <returns>Current stock price for the stock symbol.</returns>
    public async Task FetchAndNotify(string stockSymbol)
    {
      double stockPrice = await FetchStockPrice(stockSymbol);
      NotifyObservers(stockSymbol, stockPrice);
    }

    /// <summary>
    /// Calls API to get stock price.
    /// </summary>
    /// <param name="stockSymbol"></param>
    /// <returns>Current stock price.</returns>
    /// <exception cref="Exception"></exception>
    private async Task<double> FetchStockPrice(string stockSymbol)
    {
      var url = $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_apiKey}";
      var response = await _httpClient.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception($"Failed to fetch stock price for {stockSymbol}");
      }

      var content = await response.Content.ReadAsStringAsync();
      var stockData = JsonConvert.DeserializeObject<StockData>(content);

      return stockData?.CurrentPrice ?? throw new Exception("Failed to parse stock price.");
    }

    /// <summary>
    /// Helper method to update observers on stock price changes.
    /// </summary>
    /// <param name="stockSymbol"></param>
    /// <param name="stockPrice"></param>
    private void NotifyObservers(string stockSymbol, double stockPrice)
    {
      foreach (var observer in _observers)
      {
        observer.Update(stockSymbol, stockPrice);
      }
    }
  }
}
