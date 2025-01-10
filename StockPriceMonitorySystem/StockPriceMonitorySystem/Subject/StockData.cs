using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitorySystem.Subject
{
  public class StockData
  {
    [JsonProperty("c")]
    public double CurrentPrice { get; set; }
  }
}
