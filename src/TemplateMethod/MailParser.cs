using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod;

public abstract class MailParser
{
    public virtual void FindServer()
    {
        Console.WriteLine("Finding server...");
    }

    public abstract void AuthenticateToServer();

    public string ParseHtmlMailBody(string identifier)
    {
        Console.WriteLine("Parsing HTML mail body...");
        return $"This is the body of mail with id {identifier}";
    }

    /// <summary>
    /// Template method
    /// </summary> 
    public string ParseMailBody(string identifier)
    {
        Console.WriteLine("Parsing mail body (in template method)...");
        FindServer();
        AuthenticateToServer();
        return ParseHtmlMailBody(identifier);
    }
}

public class ExchangeMailParser : MailParser
{
    public override void AuthenticateToServer()
    {
        Console.WriteLine("Connecting to Exchange");
    }
}

public class ApacheMailParser : MailParser
{
    public override void AuthenticateToServer()
    {
        Console.WriteLine("Connecting to Apache");
    }
}

public class EudoraMailParser : MailParser
{
    public override void FindServer()
    {
        Console.WriteLine("Finding Eudora server through a custom algorithm...");
    }
    public override void AuthenticateToServer()
    {
        Console.WriteLine("Connecting to Eudora");
    }
}

public class MailParserClient
{
    public void TemplateMethodCall()
    {
        ExchangeMailParser exchangeMailParser = new();
        Console.WriteLine(exchangeMailParser.ParseMailBody("bf3a298c-9990-4b02-873d-3d3c98ad16d2"));
        Console.WriteLine();

        ApacheMailParser apacheMailParser = new();
        Console.WriteLine(apacheMailParser.ParseMailBody("07b8a8c7-c598-4b6c-9049-ecce9fe4a56b"));
        Console.WriteLine();

        EudoraMailParser eudoraMailParser = new();
        Console.WriteLine(eudoraMailParser.ParseMailBody("789fe935-ced2-4fbd-865b-172909560a93"));

        Console.ReadKey();
    }
}
