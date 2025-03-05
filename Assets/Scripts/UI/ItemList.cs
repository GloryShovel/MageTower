using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public GameObject tabItemPrefab;

    public List<Sprite> icons, rarities;

    private int itemSelected = -1;

    public void Init(List<Item> list)
    {
        GameObject item;

        for (int i = 0; i < list.Count; i++)
        {
#if UNITY_EDITOR
            if(icons.Count <= 0 || rarities.Count <= 0)
            {
                Debug.LogError("Check ItemLists references");
            }
#endif

            item = Instantiate(tabItemPrefab, transform);
            item.GetComponent<TabItem>().Init(list[i], icons[(int)list[i].category], rarities[(int)list[i].rarity]);
            item.GetComponent<Button>().onClick.AddListener(delegate { itemSelected = i; });
        }
    }
}
