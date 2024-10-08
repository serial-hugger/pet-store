using System;
using System.Reflection;

namespace pet_store;

public class UILogic
{
    public string OptionSelect()
    {
        Say("1: Add product 2: Search product 3: Add order 4: Search order");
        return Ask("Type 'exit' to quit");
    }
    public string Ask(string text)
    {
        Console.WriteLine(text);
        return Console.ReadLine();
    }

    public void Say(string text)
    {
        Console.WriteLine(text);
    }
}