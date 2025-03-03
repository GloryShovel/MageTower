using System.Collections.Generic;

/// <summary>
/// I made this here since Json data provided is in form of "Object with list" and want to make this procject atomic for future expanding
/// </summary>
public class Items
{
    public List<Item> items = new List<Item>();
}