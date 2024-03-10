using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace StrategyTests;

public class ExportServiceTests
{
    [Fact]
    public void ExportToJson_WithOrder_CallsExportService()
    {
        // Arrange
        var order = new Order("Test Customer", 100, "Test Order");
        var service = new JsonExportService();
        var originalConsoleOut = Console.Out; // Preserve the original console output.
        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        order.Export(service);

        // Assert
        var expectedOutput = $"Exporting Test Order to Json.{Environment.NewLine}";
        Assert.Equal(expectedOutput, consoleOutput.ToString());

        // Cleanup
        Console.SetOut(originalConsoleOut); // Restore original console output.
    }

    [Fact]
    public void ExportToXML_WithOrder_CallsExportService()
    {
        // Arrange
        var order = new Order("Test Customer", 100, "Test Order");
        var service = new XMLExportService();
        var originalConsoleOut = Console.Out;
        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        order.Export(service);

        // Assert
        var expectedOutput = $"Exporting Test Order to XML.{Environment.NewLine}";
        Assert.Equal(expectedOutput, consoleOutput.ToString());

        // Cleanup
        Console.SetOut(originalConsoleOut);
    }

    [Fact]
    public void ExportToCSV_WithOrder_CallsExportService()
    {
        // Arrange
        var order = new Order("Test Customer", 100, "Test Order");
        var service = new CSVExportService();
        var originalConsoleOut = Console.Out;
        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        order.Export(service);

        // Assert
        var expectedOutput = $"Exporting Test Order to CSV.{Environment.NewLine}";
        Assert.Equal(expectedOutput, consoleOutput.ToString());

        // Cleanup
        Console.SetOut(originalConsoleOut);
    }

}