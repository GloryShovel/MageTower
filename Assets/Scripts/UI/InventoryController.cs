using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public List<GameObject> inventoryTabs;
    public List<Button> tabButtons;

    public void Init(Items items)
    {
        //Tab swich logic injection
        for (int i = 0; i < tabButtons.Count; i++)
        {
            var safeI = i;
            tabButtons[i].onClick.AddListener(() => { SelectTab(safeI); });
        }

        //Population
        inventoryTabs[(int)Category.Armor].GetComponentInChildren<ItemList>().Init(items.armorItems);
        inventoryTabs[(int)Category.Boots].GetComponentInChildren<ItemList>().Init(items.bootsItems);
        inventoryTabs[(int)Category.Helmet].GetComponentInChildren<ItemList>().Init(items.helmetItems);
        inventoryTabs[(int)Category.Necklace].GetComponentInChildren<ItemList>().Init(items.necklaceItems);
        inventoryTabs[(int)Category.Ring].GetComponentInChildren<ItemList>().Init(items.ringItems);
        inventoryTabs[(int)Category.Weapon].GetComponentInChildren<ItemList>().Init(items.weaponItems);

        //Hiding
        SelectTab(0);
    }

    public void SelectTab(int number)
    {
        for(int i = 0;i < inventoryTabs.Count;i++)
        {
            inventoryTabs[i].SetActive(false);
        }
        inventoryTabs[number].SetActive(true);
    }
}
