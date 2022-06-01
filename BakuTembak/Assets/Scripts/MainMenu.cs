using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{   
    public static MainMenu Instance;
    [SerializeField] GameObject MenuScreen, OptionsScreen;
    void Awake()
    {
        Instance = this;
    }
    public void PlayBtnAction(){
        Debug.Log("Play Pressed");
        MenuManager.Instance.UpdateGameState(GameState.StartGame);
    }
    public void OptionsBtnAction(){
        Debug.Log("Options Pressed");
        MenuManager.Instance.UpdateGameState(GameState.OptionsGame);
    }
    public void openOptionsMenu(){
        MenuScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }
    public void ExitBtnAction(){
        MenuManager.Instance.UpdateGameState(GameState.ExitGame);
    }
}
