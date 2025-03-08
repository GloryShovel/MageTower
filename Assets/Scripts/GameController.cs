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
    public static GameController instance { get; private set; }

    public Character player;

    public InventoryController inventoryController;
    public GameStates gameState { get; private set; }

    private GameServerMock m_gameServerMock;
    private Items m_items = new Items();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
#if UNITY_EDITOR
            Debug.LogWarning("You have duplicates of:" + this.name);
#endif
        }
        else
        {
            instance = this;
        }

        gameState = GameStates.MainMenu;
        m_gameServerMock = new GameServerMock();

        player.Init(null);
        UIController.instance.Init(new Stats());

    }
    public async void NewGame()
    {
        UIController.instance.RequestState(UIState.Loading);

        ItemsReciver m_itemList;
        m_itemList = JsonConvert.DeserializeObject<ItemsReciver>(await m_gameServerMock.GetItemsAsync());
        m_items.Init(m_itemList);
        inventoryController.Init(m_items);

        player.RecalculateStats();
        UIController.instance.statisticsController.UpdateData(player.calculatedStats);

        UIController.instance.RequestState(UIState.Gameplay);
    }
}
