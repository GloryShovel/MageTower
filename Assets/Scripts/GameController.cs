using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    MainMenu,
    UI,
    Gameplay,
    Loading
}

public class GameController : MonoBehaviour
{
    public Character player;

    public UIController uiController;
    public InventoryController inventoryController;
    public GameStates gameState;

    private GameServerMock m_gameServerMock;
    private Items m_items = new Items();

    public async void NewGame()
    {
        uiController.RequestState(UIState.Loading);

        ItemsReciver m_itemList;
        m_itemList = JsonConvert.DeserializeObject<ItemsReciver>(await m_gameServerMock.GetItemsAsync());
        m_items.Init(m_itemList);
        inventoryController.Init(m_items);
        player.Init(null);

        uiController.RequestState(UIState.Gameplay);
    }

    void Awake()
    {
        gameState = GameStates.MainMenu;
        uiController.Init();
        m_gameServerMock = new GameServerMock();

        //Debug.Log("List " + m_itemList.items[0].itemName);
        //Debug.Log("List " + m_itemList.items[0].category);
        //Debug.Log("List " + m_itemList.items[0].rarity);
        //Debug.Log("List " + m_itemList.items[0].damage);
        //Debug.Log("List " + m_itemList.items[0].healthPoints);
        //Debug.Log("List " + m_itemList.items[0].defense);
        //Debug.Log("List " + m_itemList.items[0].lifeSteal);
        //Debug.Log("List " + m_itemList.items[0].criticalStrikeChance);
        //Debug.Log("List " + m_itemList.items[0].attackSpeed);
        //Debug.Log("List " + m_itemList.items[0].movementSpeed);
        //Debug.Log("List " + m_itemList.items[0].luck);
    }
}
