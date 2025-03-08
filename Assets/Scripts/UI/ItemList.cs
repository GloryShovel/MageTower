using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public TabItem tabItemPrefab;

    public Sprite[] icons, rarities;
    private List<TabItem> tabItems = new List<TabItem>();

    public void Init(List<Item> list)
    {
        TabItem item;

        for (int i = 0; i < list.Count; i++)
        {
#if UNITY_EDITOR
            if(icons.Length <= 0 || rarities.Length <= 0)
            {
                Debug.LogError("Check ItemLists references");
            }
#endif

            item = Instantiate(tabItemPrefab, transform);
            item.Init(list[i], icons[(int)list[i].category], rarities[(int)list[i].rarity]);

            var safeI = i;
            var safeItem = item;
            item.gameObject.GetComponent<Button>().onClick.AddListener(() => { GameController.instance.player.EquipItem(list[safeI]); EquipSign(safeItem); });

            tabItems.Add(item);
        }

        EquipSign(null);
    }

    public void EquipSign(TabItem item)
    {
        bool isSelectable = false;

        if(item != null)
        {
            isSelectable = !item.equipedIcon.enabled;
        }

        for (int i = 0;i < tabItems.Count;i++)
        {
            tabItems[i].equipedIcon.enabled = false;
        }

        if (isSelectable)
        {
            item.equipedIcon.enabled = true;
        }
    }
}
