using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
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

        mainMenu.gameObject.SetActive(true);
        gameplay.gameObject.SetActive(false);
        howTo.gameObject.SetActive(false);
        lore.gameObject.SetActive(false);
        loadingScreen.alpha = 0;
    }

    private void RequestTransition(UIState desiredState)
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
        //I just mocked transition screen i think about doing this on events, that way I can load when no one sees XD
        //loadingScreen.alpha = 1;

        mainMenu.gameObject.SetActive(false);
        gameplay.gameObject.SetActive(false);
        howTo.gameObject.SetActive(false);
        lore.gameObject.SetActive(false);

        switch (desiredState)
        {
            case UIState.MainMenu: mainMenu.gameObject.SetActive(true); break;
            case UIState.Gameplay: gameplay.gameObject.SetActive(true); break;
            case UIState.HowTo: howTo.gameObject.SetActive(true); break;
            case UIState.Lore: lore.gameObject.SetActive(true); break;
        }

        //loadingScreen.alpha = 0;
    }

    public void OnMainMenu()
    {
        RequestTransition(UIState.MainMenu);
    }
    public void OnGameplay()
    {
        RequestTransition(UIState.Gameplay);
    }
    public void OnHowTo()
    {
        RequestTransition(UIState.HowTo);
    }
    public void OnLore()
    {
        RequestTransition(UIState.Lore);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
