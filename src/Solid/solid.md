# SOLID Principles in C#

The SOLID principles are a set of guidelines for object-oriented design and programming that enhance software maintainability and flexibility. Here's a brief overview of each principle with C# examples:

## Single Responsibility Principle (SRP)

A class should have only one reason to change, signifying it should only have one job or responsibility.

### Example

**Before SRP:**

A class handling both user management and email notifications.

```csharp
public class UserManager
{
    public void AddUser(string username, string email)
    {
        // Add user to database
    }

    public void SendEmail(string email, string message)
    {
        // Send email
    }
}
```

**After SRP:**

Separating user management and email notification into two classes.

```csharp
public class UserManager
{
	public void AddUser(string username, string email)
	{
		// Add user to database
	}
}

public class EmailService
{
	public void SendEmail(string email, string message)
	{
		// Send email
	}
}
```

## Open/Closed Principle (OCP)

A class should be open for extension but closed for modification, meaning it should be easily extendable without altering its source code.

### Example

**Before OCP:**

A class with a switch statement that needs to be modified every time a new shape is added.

```csharp

public class AreaCalculator
{
	public double CalculateArea(object shape)
	{
		if (shape is Rectangle)
		{
			var rectangle = (Rectangle)shape;
			return rectangle.Width * rectangle.Height;
		}
		else if (shape is Circle)
		{
			var circle = (Circle)shape;
			return circle.Radius * circle.Radius * Math.PI;
		}
		// ... more shapes
	}
}
```

**After OCP:**

Using polymorphism to extend the class without modifying its source code.

```csharp

public abstract class Shape
{
	public abstract double CalculateArea();
}

public class Rectangle : Shape
{
	public double Width { get; set; }
	public double Height { get; set; }

	public override double CalculateArea()
	{
		return Width * Height;
	}
}

public class Circle : Shape
{
	public double Radius { get; set; }

	public override double CalculateArea()
	{
		return Radius * Radius * Math.PI;
	}
}

public class AreaCalculator
{
	public double CalculateArea(Shape shape)
	{
		return shape.CalculateArea();
	}
}
```

## Liskov Substitution Principle (LSP)

Objects of a superclass should be replaceable with objects of its subclasses without affecting the functionality of the program.

### Example

**Before LSP:**

A square class that violates the LSP.

```csharp	
public class Rectangle
{
	public virtual int Width { get; set; }
	public virtual int Height { get; set; }
}

public class Square : Rectangle
{
	public override int Width
	{
		set { base.Width = base.Height = value; }
	}

	public override int Height
	{
		set { base.Width = base.Height = value; }
	}
}

////////////////////////////////////////////////////////////////////
// Using these classes could lead to runtime errors if you mistakenly call Fly on a Penguin object treated as a Bird.
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("This bird is flying.");
    }

    public void Swim()
    {
        Console.WriteLine("This bird is swimming.");
    }
}

public class Duck : Bird
{
    // Duck is fine with the base Bird implementation
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Penguins cannot fly.");
    }
}
```

**After LSP:**

Using a separate Square class that doesn't inherit from Rectangle.

```csharp
public class Rectangle
{
	public int Width { get; set; }
	public int Height { get; set; }
}

public class Square
{
	public int Side { get; set; }
}


////////////////////////////////////////////////////////////////////

public interface IFly
{
    void Fly();
}

public interface ISwim
{
    void Swim();
}

public class Duck : IFly, ISwim
{
    public void Fly()
    {
        Console.WriteLine("Duck is flying.");
    }

    public void Swim()
    {
        Console.WriteLine("Duck is swimming.");
    }
}

public class Penguin : ISwim
{
    public void Swim()
    {
        Console.WriteLine("Penguin is swimming.");
    }
}
```

## Interface Segregation Principle (ISP)

A client should not be forced to implement an interface that it doesn't use, signifying that interfaces should be fine-grained.

### Example

**Before ISP:**

A single large interface that contains methods for all types of printers.

```csharp
public interface IPrinter
{
	void Print(string document);
	void Scan(string document);
	void Fax(string document);
}


////////////////////////////////////////////////////////////////////
public interface IPrinter
{
    void Print(Document d);
}

public interface IScanner
{
    void Scan(Document d);
}

public interface IFax
{
    void Fax(Document d);
}

```


**After ISP:**

Separating the large interface into smaller, more specific interfaces.

```csharp
public interface IPrinter
{
	void Print(string document);
}

public interface IScanner
{
	void Scan(string document);
}

public interface IFax
{
	void Fax(string document);
}
////////////////////////////////////////////////////////////////////
public class SimplePrinter : IPrinter
{
    public void Print(Document d)
    {
        // Implementation for printing
    }
}

public class MultiFunctionMachine : IPrinter, IScanner, IFax
{
    private IPrinter printer;
    private IScanner scanner;
    private IFax fax;

    public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFax fax)
    {
        this.printer = printer;
        this.scanner = scanner;
        this.fax = fax;
    }

    public void Print(Document d)
    {
        printer.Print(d);
    }

    public void Scan(Document d)
    {
        scanner.Scan(d);
    }

    public void Fax(Document d)
    {
        fax.Fax(d);
    }
}
```

## Dependency Inversion Principle (DIP)

High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

### Example A

**Before DIP:**

A high-level module directly depends on a low-level module.

```csharp

public class LightBulb
{
	public void TurnOn()
	{
		// Turn on the light
	}
}

public class Switch
{
	private LightBulb _lightBulb = new LightBulb();

	public void Toggle()
	{
		// Toggle the light
	}
}


```

**After DIP:**

Using an interface to decouple the high-level module from the low-level module.

```csharp
public interface ISwitchable
{
	void TurnOn();
	void TurnOff();
}

public class LightBulb : ISwitchable
{
	public void TurnOn()
	{
		// Turn on the light
	}

	public void TurnOff()
	{
		// Turn off the light
	}
}

public class Switch
{
	private ISwitchable _device;

	public Switch(ISwitchable device)
	{
		_device = device;
	}

	public void Toggle()
	{
		if (_device == null)
		{
			throw new Exception("Device has no power supply");
		}

		if (_device.IsOn)
		{
			_device.TurnOff();
		}
		else
		{
			_device.TurnOn();
		}
	}
}



```

## Conclusion

The SOLID principles are a set of guidelines that help developers design maintainable and flexible software. By following these principles, you can create code that is easier to understand, maintain, and extend. While it may take some time to get used to these principles, they can greatly improve the quality of your code and make your life as a developer much easier.

