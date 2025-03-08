using UnityEngine;
using UnityEngine.UI;

public class TabItem : MonoBehaviour
{

    public Image icon, background, equipedIcon;
    public StatWriter statWriter;

    public void Init(Item item, Sprite iconRef, Sprite backgroundRef)
    {
        icon.sprite = iconRef;
        background.sprite = backgroundRef;
        equipedIcon.enabled = false;
        statWriter.Write(item.stats);
    }


    public void Click()
    {
        background.color = Color.black;
    }
}
