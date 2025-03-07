using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    Loading,
    MainMenu,
    Gameplay,
    HowTo,
    Lore
}

public class UIController: MonoBehaviour
{
    public GameController gameController;
    public CanvasGroup mainMenu, gameplay, howTo, lore, loadingScreen;

    private UIState uiState;

    public void Init()
    {
        uiState = UIState.MainMenu;

        loadingScreen.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        gameplay.gameObject.SetActive(false);
        howTo.gameObject.SetActive(false);
        lore.gameObject.SetActive(false);
    }

    public void RequestState(UIState desiredState)
    {
        //TODO
        //Tried to serialize gamestate enum, but it doesn't work becouse of Unity, well this is for future improvement
        switch (gameController.gameState)
        {
            case GameStates.MainMenu:
                Transition(desiredState);
                break;
            case GameStates.UI:
            case GameStates.Gameplay:
                break;
            case GameStates.Loading:
                break;
        }
    }
    private void Transition(UIState desiredState)
    {
        loadingScreen.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        gameplay.gameObject.SetActive(false);
        howTo.gameObject.SetActive(false);
        lore.gameObject.SetActive(false);

        switch (desiredState)
        {
            case UIState.Loading: loadingScreen.gameObject.SetActive(true); break;
            case UIState.MainMenu: mainMenu.gameObject.SetActive(true); break;
            case UIState.Gameplay: gameplay.gameObject.SetActive(true); break;
            case UIState.HowTo: howTo.gameObject.SetActive(true); break;
            case UIState.Lore: lore.gameObject.SetActive(true); break;
        }

        uiState = desiredState;
    }

    public void OnMainMenu()
    {
        RequestState(UIState.MainMenu);
    }
    public void OnGameplay()
    {
        RequestState(UIState.Gameplay);
    }
    public void OnHowTo()
    {
        RequestState(UIState.HowTo);
    }
    public void OnLore()
    {
        RequestState(UIState.Lore);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
