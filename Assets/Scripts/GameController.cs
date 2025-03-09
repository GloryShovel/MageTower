using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    MainMenu,
    UI_off,
    Gameplay,
    Loading
}

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public Player player;
    public InventoryController inventoryController;
    public Spawner[] spawners;

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

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].Init(1);
        }
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

    public void StartWave()
    {
        UIController.instance.RequestState(UIState.Wave);

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].SendEnemies(5);
        }
    }

    public void DamagePlayer(int damage)
    {
        if (player.RequestTakeDamage(damage))
        {
            GameOver();
        }
        UIController.instance.statisticsController.UpdateData(player.calculatedStats);
    }

    public void DamageEnemy(Enemy enemy, int damage)
    {
        if (enemy.RequestTakeDamage(damage))
        {
            enemy.RestoreToPool();

            bool isWaveFinished = false;
            for (int i = 0;i < spawners.Length;i++)
            {
                if (spawners[i].finished)
                {
                    isWaveFinished = true;
                }
            }
            if (isWaveFinished)
            {
                EndWave();
            }
        }
    }

    private void EndWave()
    {
        UIController.instance.RequestState(UIState.Gameplay);
        player.RecalculateStats();
        UIController.instance.statisticsController.UpdateData(player.calculatedStats);
    }

    private void GameOver()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].KillAll();
        }

        UIController.instance.RequestState(UIState.GameOver);
    }
}
