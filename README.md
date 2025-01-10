# Stock Price Monitoring System

A real-time stock price monitoring application implemented in C# using the **Observer Design Pattern**. This project utilizes the [Finnhub Stock API](https://finnhub.io/) to fetch live stock data and demonstrates how to notify different observers like a console logger, email alerts, and mobile app notifications when stock prices are updated.

## Key Features

- Fetches live stock price data for multiple companies.
- Implements the **Observer Design Pattern** for dynamic updates to subscribers.
- Notifies observers such as:
  - Console Logger
  - Email Alert System
  - Mobile App
- Supports real-time currency conversion for international stocks (using the **FreeCurrencyAPI**).

## Setup Instructions

1. Clone the repository:

   ```bash
   git clone https://github.com/YourUsername/StockPriceMonitoringSystem.git
   cd StockPriceMonitoringSystem
   ```

2. Install dependencies:

   - Add `Newtonsoft.Json` and `DotNetEnv` packages via NuGet:
     ```bash
     dotnet add package Newtonsoft.Json
     dotnet add package DotNetEnv
     ```

3. Add a `.env` file to the **project root**:

   ```plaintext
   FINNHUB_API_KEY=your_finnhub_api_key_here
   ```

4. Build and run the project:

   ```bash
   dotnet run
   ```

## Usage

- The application will automatically fetch stock prices for predefined companies.
- Observers will log stock price updates to the console, email alerts, and mobile app notifications.

**Sample Output**:

```
[LOG]: Stock AAPL is now $235.37
[MOBILE APP]: Stock AAPL is now $235.37
[EMAIL ALERT]: Stock AAPL is now $235.37
```

## Technologies Used

- **C# and .NET 8.0**
- **Finnhub Stock API**: Real-time stock price data
- **Observer Design Pattern**
- **DotNetEnv**: Secure environment variable management
- **Newtonsoft.Json**: JSON serialization/deserialization

