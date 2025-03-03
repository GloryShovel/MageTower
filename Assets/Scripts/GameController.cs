using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameServerMock m_gameServerMock;
    private Items m_itemList;

    private void Init()
    {
        m_gameServerMock = new GameServerMock();
    }

    async void Start()
    {
        Init();

        //TOMOVE - when we start game
        m_itemList = JsonConvert.DeserializeObject<Items>(await m_gameServerMock.GetItemsAsync());
        Debug.Log("List " + m_itemList.items.Count);
    }
}
