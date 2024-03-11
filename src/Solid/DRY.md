# DRY Principle (Don't Repeat Yourself)

## Overview

The DRY principle is a fundamental concept in software development, advocating for the reduction of duplication in code. It emphasizes the importance of having a single, unambiguous, authoritative representation for every piece of knowledge within a system. Adhering to DRY can lead to more maintainable, readable, and less error-prone code.

## Benefits

- **Reduce Redundancy**: Eliminates duplicate code, making the system easier to maintain.
- **Improve Maintainability**: Changes to the system need to be made in only one place, reducing the chance of inconsistent behavior.
- **Enhance Readability**: Simplifies understanding of the codebase by eliminating unnecessary repetition.

## DRY Violation Example

Consider an application that calculates both the area and circumference of a circle in different parts of the codebase using the formulae directly.

```csharp
public class CircleOperations
{
    public double CalculateArea(double radius)
    {
        return Math.PI * radius * radius; // Area = πr²
    }

    public double CalculateCircumference(double radius)
    {
        return 2 * Math.PI * radius; // Circumference = 2πr
    }

    public void DisplayCalculations(double radius)
    {
        Console.WriteLine("Area: " + CalculateArea(radius));
        Console.WriteLine("Circumference: " + CalculateCircumference(radius));
    }
}

////////////////////////////////////////

//DRY Compliant Solution

public class Circle
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius; // Centralize the calculation
    }

    public double CalculateCircumference()
    {
        return 2 * Math.PI * Radius; // Centralize the calculation
    }
}

public class CircleUtilities
{
    public static void DisplayCalculations(Circle circle)
    {
        Console.WriteLine($"Area: {circle.CalculateArea()}");
        Console.WriteLine($"Circumference: {circle.CalculateCircumference()}");
    }
}
```
