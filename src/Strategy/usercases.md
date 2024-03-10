# Strategy Definition

The Strategy pattern is a behavioral design pattern that enables an algorithm's behavior to be selected at runtime. 
Instead of implementing a single algorithm directly, code receives run-time instructions as to which in a family of algorithms to use. This pattern:

- Defines a family of algorithms,
- Encapsulates each algorithm, and
- Makes the algorithms interchangeable within that family.

## Payment Processing System

The Strategy pattern is used to create an algorithm that can be selected at runtime. 
In this example, we have a payment processing system that can process payments using different payment gateways. The payment gateways are the algorithms that can be selected at runtime.

The `PaymentProcessor` class is the context class that uses the `PaymentGateway` interface. 
The `PaymentGateway` interface is the strategy interface that defines the algorithm to be used. 
The `CreditCardPaymentGateway` and `PaypalPaymentGateway` classes are the concrete strategy classes that implement the `PaymentGateway` interface.

## When to use the Strategy Pattern	


- When you want to define a class that will have one behavior that is similar to other behaviors in a list
- When you need to use one of several behaviors dynamically
- You use this pattern when you need to dynamically change an algorithm used by an object at run time
- You use this pattern when you have a class that has a lot of conditional statements that can be moved to their own strategy class
- You use this pattern when you have a lot of similar classes that only differ in the way they execute some behavior
- You use this pattern when you need to isolate the business logic of a class from the implementation details of algorithms that may not be as important to the client code
- You use this pattern when you want to be able to choose the algorithm that suits the context of the application
- You use this pattern when you want to define a class that will have one behavior that is similar to other behaviors in a list
- You use this pattern when you need to use one of several behaviors dynamically
- You use this pattern when you need to change the behavior of an object at run time
- You use this pattern when you have a class that has a lot of conditional statements that can be moved to their own strategy class
- You use this pattern when you have a lot of similar classes that only differ in the way they execute some behavior
- You use this pattern when you need to isolate the business logic of a class from the implementation details of algorithms that may not be as important to the client code
- You use this pattern when you want to be able to choose the algorithm that suits the context of the application

## Provided Another 10 user cases for the Strategy Pattern

### A game that allows players to choose different characters with different abilities	

- In a game, you have different characters with different abilities. You can use the Strategy pattern to define the abilities of the characters and allow the player to choose the character with the ability they want to use.
- The `Character` class is the context class that uses the `Ability` interface.
- The `Ability` interface is the strategy interface that defines the ability to be used.
- The `FireAbility` and `IceAbility` classes are the concrete strategy classes that implement the `Ability` interface.
- The `Character` class has a method that allows the player to choose the ability they want to use.
- The `Character` class uses the ability selected by the player to perform the action.
- The `Character` class can change the ability used at runtime.
- The `Character` class can have different abilities that can be used interchangeably.

```csharp
public interface IAbility
{
	void UseAbility();
}

public class FireAbility : IAbility
{
	public void UseAbility()
	{
		Console.WriteLine("Fire Ability");
	}
}

public class IceAbility : IAbility
{
	public void UseAbility()
	{
		Console.WriteLine("Ice Ability");
	}
}

public class Character
{
	private IAbility _ability;

	public void SetAbility(IAbility ability)
	{
		_ability = ability;
	}

	public void UseAbility()
	{
		_ability.UseAbility();
	}
}

public class Program
{
	public static void Main()
	{
		var character = new Character();
		character.SetAbility(new FireAbility());
		character.UseAbility();
		character.SetAbility(new IceAbility());
		character.UseAbility();
	}
}
```


### A document editor that allows users to choose different file formats to save documents

- In a document editor, you have different file formats to save documents. 
- You can use the Strategy pattern to define the file formats and allow the user to choose the file format they want to use.
- The `DocumentEditor` class is the context class that uses the `FileFormat` interface.
- The `FileFormat` interface is the strategy interface that defines the file format to be used.
- The `PdfFileFormat` and `DocFileFormat` classes are the concrete strategy classes that implement the `FileFormat` interface.
- The `DocumentEditor` class has a method that allows the user to choose the file format they want to use.
- The `DocumentEditor` class uses the file format selected by the user to save the document.
- The `DocumentEditor` class can change the file format used at runtime.
- The `DocumentEditor` class can have different file formats that can be used interchangeably.

```csharp
public interface IFileFormat
{
	void SaveDocument();
}

public class PdfFileFormat : IFileFormat
{
	public void SaveDocument()
	{
		Console.WriteLine("Save as PDF");
	}
}

public class DocFileFormat : IFileFormat
{
	public void SaveDocument()
	{
		Console.WriteLine("Save as DOC");
	}
}

public class DocumentEditor
{
	private IFileFormat _fileFormat;

	public void SetFileFormat(IFileFormat fileFormat)
	{
		_fileFormat = fileFormat;
	}

	public void SaveDocument()
	{
		_fileFormat.SaveDocument();
	}
}

public class Program
{
	public static void Main()
	{
		var documentEditor = new DocumentEditor();
		documentEditor.SetFileFormat(new PdfFileFormat());
		documentEditor.SaveDocument();
		documentEditor.SetFileFormat(new DocFileFormat());
		documentEditor.SaveDocument();
	}
}
```

### A music player that allows users to choose different audio formats to play music
		


		- In a music player, you have different audio formats to play music.
		- You can use the Strategy pattern to define the audio formats and allow the user to choose the audio format they want to use.
		- The `MusicPlayer` class is the context class that uses the `AudioFormat` interface.
		- The `AudioFormat` interface is the strategy interface that defines the audio format to be used.
		- The `Mp3AudioFormat` and `WavAudioFormat` classes are the concrete strategy classes that implement the `AudioFormat` interface.
		- The `MusicPlayer` class has a method that allows the user to choose the audio format they want to use.
		- The `MusicPlayer` class uses the audio format selected by the user to play the music.
		- The `MusicPlayer` class can change the audio format used at runtime.
		- The `MusicPlayer` class can have different audio formats that can be used interchangeably.

		```csharp
		public interface IAudioFormat
		{
			void PlayMusic();
		}
			

			public class Mp3AudioFormat : IAudioFormat
		{
			public void PlayMusic()
			{
				Console.WriteLine("Play MP3");
			}
		}


		public class WavAudioFormat : IAudioFormat
		{
			public void PlayMusic()
			{
				Console.WriteLine("Play WAV");
			}
		}

		public class MusicPlayer
		{
			private IAudioFormat _audioFormat;

			public void SetAudioFormat(IAudioFormat audioFormat)
			{
				_audioFormat = audioFormat;
			}

			public void PlayMusic()
			{
				_audioFormat.PlayMusic();
			}
		}

		public class Program
		{
			public static void Main()
			{
				var musicPlayer = new MusicPlayer();
				musicPlayer.SetAudioFormat(new Mp3AudioFormat());
				musicPlayer.PlayMusic();
				musicPlayer.SetAudioFormat(new WavAudioFormat());
				musicPlayer.PlayMusic();
			}
		}
		```




		