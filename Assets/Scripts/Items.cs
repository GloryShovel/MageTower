using System.Collections.Generic;

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
                    armorItems.Add((Item)itemsList.items[i]);
                    break;
                case Category.Boots:
                    bootsItems.Add((Item)itemsList.items[i]);
                    break;
                case Category.Helmet:
                    helmetItems.Add((Item)itemsList.items[i]);
                    break;
                case Category.Necklace:
                    necklaceItems.Add((Item)itemsList.items[i]);
                    break;
                case Category.Ring:
                    ringItems.Add((Item)itemsList.items[i]);
                    break;
                case Category.Weapon:
                    weaponItems.Add((Item)itemsList.items[i]);
                    break;
            }
        }
    }
}