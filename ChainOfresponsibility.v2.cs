Tester.Test();

public abstract class Handler
{
    public Handler NextHandler;

    public void SetNextHandler(Handler NextHandler)
    {
        this.NextHandler = NextHandler;
    }
    public abstract void DispatchNote(long requestedAmount);
}

public class HundredHandler : Handler
{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 100;
        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Hundred notes are dispatched by HundredHandler");
            }
            else
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Hundred note is dispatched by HundredHandler");
            }
        }
    }
}

public class TwoHundredHandler : Handler
{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 200;
        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Two Hundred notes are dispatched by TwoHundredHandler");
            }
            else
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Two Hundred note is dispatched by TwoHundredHandler");
            }
        }
        long RemainingAmount = requestedAmount % 200;
        if (RemainingAmount > 0)
        {
            NextHandler.DispatchNote(RemainingAmount);
        }
    }
}

public class FiveHundredHandler : Handler
{
    public override void DispatchNote(long requestedAmount)
    {
        long numberofNotesToBeDispatched = requestedAmount / 500;
        if (numberofNotesToBeDispatched > 0)
        {
            if (numberofNotesToBeDispatched > 1)
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred notes are dispatched by FiveHundredHandler");
            }
            else
            {
                Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred note is dispatched by FiveHundredHandler");
            }
        }
        long RemainingAmount = requestedAmount % 500;
        if (RemainingAmount > 0)
        {
            NextHandler.DispatchNote(RemainingAmount);
        }
    }
}

public static class Tester
{
    public static void Test()
    {
        Handler hundredHandler = new HundredHandler();
        Handler twoHundredHandler = new TwoHundredHandler();
        Handler fiveHundredHandler = new FiveHundredHandler();

        hundredHandler.SetNextHandler(twoHundredHandler);
        twoHundredHandler.SetNextHandler(fiveHundredHandler);

        Console.WriteLine("Scenario 1:");
        hundredHandler.DispatchNote(1123);

        Console.WriteLine("\nScenario 2:");
        hundredHandler.DispatchNote(750);

        Console.WriteLine("\nScenario 3:");
        hundredHandler.DispatchNote(450);

        Console.WriteLine("\nScenario 4:");
        hundredHandler.DispatchNote(1000); ;
    }
}