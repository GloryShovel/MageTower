using System.Collections.Generic;

/// <summary>
/// I made this here since Json data provided is in form of "Object with list"
/// </summary>
public class ItemsReciver
{
    public List<Item> items = new List<Item>();
}

public class Items
{
    public List<Item> armorItems = new List<Item>();
    public List<Item> bootsItems = new List<Item>();
    public List<Item> helmetItems = new List<Item>();
    public List<Item> necklaceItems = new List<Item>();
    public List<Item> ringItems = new List<Item>();
    public List<Item> weaponItems = new List<Item>();

    public void Init(ItemsReciver itemsList)
    {
        for (int i = 0; i < itemsList.items.Count; i++)
        {
            switch (itemsList.items[i].category)
            {
                case Category.Armor:
                    armorItems.Add(itemsList.items[i]);
                    break;
                case Category.Boots:
                    bootsItems.Add(itemsList.items[i]);
                    break;
                case Category.Helmet:
                    helmetItems.Add(itemsList.items[i]);
                    break;
                case Category.Necklace:
                    necklaceItems.Add(itemsList.items[i]);
                    break;
                case Category.Ring:
                    ringItems.Add(itemsList.items[i]);
                    break;
                case Category.Weapon:
                    weaponItems.Add(itemsList.items[i]);
                    break;
            }
        }
    }
}