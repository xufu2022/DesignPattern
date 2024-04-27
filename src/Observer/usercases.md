# Observer Definition

The Observer pattern is a software design pattern that defines a one-to-many dependency relationship between objects so that when one object changes state, all its dependents are notified and updated automatically. This pattern is particularly useful for implementing distributed event-handling systems, where the creation of an event by one object needs to trigger actions in other subscriber objects.

## Components of the Observer Pattern

The Observer pattern typically involves the following key components:

	- Subject (Observable):
		This is the entity that holds data and the state that, when changed, needs to trigger notifications to attached observers. It maintains a list of observers and provides methods to add, remove, and notify observers.
	- Observer:
		This is an interface or abstract class defining the method(s) that should be called whenever the subject's state changes. Concrete observers implement these methods to react to the notifications from the subject.
	- Concrete Subject:
		A subclass of Subject that implements the mechanisms to manage the list of observers and notify them of any state changes.
	- Concrete Observer:
		A subclass of Observer that implements the response to the notifications issued by the subject. Each observer usually contains a reference to a concrete subject to observe its state changes.

## How the Observer Pattern Works

	- Registration: Observers register themselves with a subject to begin receiving updates.
	- Notification: Whenever the subject undergoes a change in its state, it automatically notifies all registered observers by calling one of their methods defined in the observer interface. This method can be used by observers to update themselves according to the subject's new state.
	- Deregistration: Observers can unregister from the subject if they no longer need to receive updates.

## Benefits of Using the Observer Pattern

	- Loose Coupling: The subject does not need to know anything about the observers other than that they implement a certain interface. This makes the system components loosely coupled and easier to manage and extend.
	- Dynamic Relationships: You can dynamically add or remove observers without modifying the subject or other observers, which makes the system highly flexible.
	- Broadcast Communication: The Observer pattern allows the subject to broadcast notifications to multiple observers in a standard way, which is efficient for scenarios where the state change in one component needs to affect multiple others.

## Typical Use Cases

	- GUI Implementations: Many graphical user interfaces use the Observer pattern to handle the interaction where user actions trigger responses in the interface components.
	- Event Management Systems: Systems that handle events such as notifications, alarms, or system messages often use this pattern to ensure that all subscribers to an event receive the necessary updates.
	- Data Monitoring: Applications that monitor and react to changes in data, such as stock tickers, weather applications, or data-driven analytics, often implement the Observer pattern.


## Example of the Observer Pattern

### 1. Financial Market Data Feed
Scenario: A stock market application where multiple modules (such as trading algorithms, UI dashboards, and archival systems) need to receive updates about stock prices in real-time.

Implementation:

Subject: StockTicker class that maintains a stock price and notifies observers whenever the stock price updates.
Observers: TradingAlgorithm, DashboardUpdate, and DataArchiver classes that implement the observer interface to react to stock price changes.



```csharp
protected interface IObserver
{
	void Update(Stock stock);
}

protected class StockTicker
{
	private Stock _stock;
	private List<IObserver> _observers = new List<IObserver>();

	public void Register(IObserver observer)
	{
		_observers.Add(observer);
	}

	public void Unregister(IObserver observer)
	{
		_observers.Remove(observer);
	}

	public void Notify()
	{
		foreach (var observer in _observers)
		{
			observer.Update(_stock);
		}
	}

	public Stock Stock
	{
		get { return _stock; }
		set
		{
			_stock = value;
			Notify();
		}
	}
}

protected class Stock
{
	public string Symbol { get; set; }
	public decimal Price { get; set; }
}

protected class TradingAlgorithm : IObserver
{
	public void Update(Stock stock)
	{
		Console.WriteLine($"Trading algorithm received update for {stock.Symbol}: {stock.Price}");
	}
}

protected class DashboardUpdate : IObserver
{
	public void Update(Stock stock)
	{
		Console.WriteLine($"Dashboard updated for {stock.Symbol}: {stock.Price}");
	}
}

protected class DataArchiver : IObserver
{
	public void Update(Stock stock)
	{
		Console.WriteLine($"Data archived for {stock.Symbol}: {stock.Price}");
	}
}

public class Program
{
	public static void Main()
	{
		var stockTicker = new StockTicker();
		var tradingAlgorithm = new TradingAlgorithm();
		var dashboardUpdate = new DashboardUpdate();
		var dataArchiver = new DataArchiver();

		stockTicker.Register(tradingAlgorithm);
		stockTicker.Register(dashboardUpdate);
		stockTicker.Register(dataArchiver);

		stockTicker.Stock = new Stock { Symbol = "AAPL", Price = 150.0m };
		stockTicker.Stock = new Stock { Symbol = "GOOGL", Price = 2500.0m };
	}
}
```


### 2. Real-time Sports Score Updates

Scenario:

A sports app provides live score updates to various display components, such as a mobile app UI, website, and push notification services. As the game progresses and scores change, these components need to update immediately to reflect the latest scores.

Implementation:

	- Subject: GameScoreTracker that tracks scores for different sports games and notifies observers whenever there's a score update.
	- Observers: MobileAppDisplay, WebsiteDisplay, and PushNotificationService that react to changes in the game score.

```csharp


protected interface IObserver
{
	void Update(GameScore gameScore);
}

protected class GameScoreTracker
{
	private GameScore _gameScore;
	private List<IObserver> _observers = new List<IObserver>();

	public void Register(IObserver observer)
	{
		_observers.Add(observer);
	}

	public void Unregister(IObserver observer)
	{
		_observers.Remove(observer);
	}

	public void Notify()
	{
		foreach (var observer in _observers)
		{
			observer.Update(_gameScore);
		}
	}

	public GameScore GameScore
	{
		get { return _gameScore; }
		set
		{
			_gameScore = value;
			Notify();
		}
	}
}

protected class GameScore
{
	public string Team1 { get; set; }
	public string Team2 { get; set; }
	public int Score1 { get; set; }
	public int Score2 { get; set; }
}

protected class MobileAppDisplay : IObserver
{
	public void Update(GameScore gameScore)
	{
		Console.WriteLine($"Mobile app updated: {gameScore.Team1} {gameScore.Score1} - {gameScore.Team2} {gameScore.Score2}");
	}
}

protected class WebsiteDisplay : IObserver
{
	public void Update(GameScore gameScore)
	{
		Console.WriteLine($"Website updated: {gameScore.Team1} {gameScore.Score1} - {gameScore.Team2} {gameScore.Score2}");
	}
}

protected class PushNotificationService : IObserver
{
	public void Update(GameScore gameScore)
	{
		Console.WriteLine($"Push notification sent: {gameScore.Team1} {gameScore.Score1} - {gameScore.Team2} {gameScore.Score2}");
	}
}

public class Program
{
	public static void Main()
	{
		var gameScoreTracker = new GameScoreTracker();
		var mobileAppDisplay = new MobileAppDisplay();
		var websiteDisplay = new WebsiteDisplay();
		var pushNotificationService = new PushNotificationService();

		gameScoreTracker.Register(mobileAppDisplay);
		gameScoreTracker.Register(websiteDisplay);
		gameScoreTracker.Register(pushNotificationService);

		gameScoreTracker.GameScore = new GameScore { Team1 = "Team A", Team2 = "Team B", Score1 = 1, Score2 = 0 };
		gameScoreTracker.GameScore = new GameScore { Team1 = "Team A", Team2 = "Team B", Score1 = 1, Score2 = 1 };
	}
}
```





		