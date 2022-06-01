using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public GameState State;

    void Awake()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                HandleMainMenu();         
                break;
            case GameState.StartGame:
                HandleStartGame();
                break;
            case GameState.PauseGame:
                HandlePauseGame();
                break;
            case GameState.ResumeGame:
                HandleResumeGame();
                break;
            case GameState.OptionsGame:
                HandleOptionsGame();
                break;
            case GameState.RestartGame:
                HandleRestartGame();
                break;
            case GameState.ExitGame:
                Debug.Log("Quit");
                Application.Quit();
                break;
            case GameState.WinGame:
            WinLoseManager.Instance.WinSetup(true);
                break;
            case GameState.LoseGame:
            WinLoseManager.Instance.WinSetup(false);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        Debug.Log("Called   " + newState);
    }
    
    private void HandleMainMenu(){
        Debug.Log("mainMenu");
        SceneManager.LoadScene("MainMenu");
    }
    private void HandleStartGame(){
        Debug.Log("startGame");
        SceneManager.LoadScene("Level1");
    }
    private void HandleRestartGame(){
        HandleResumeGame();
        HandleStartGame();
    }
    private void HandleOptionsGame(){
        OptionsMenu.Instance.openOptionsMenu();
    }
    private void HandlePauseGame(){
        PauseMenu.Instance.ToggleIngameMenu(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
    private void HandleResumeGame(){
        PauseMenu.Instance.ToggleIngameMenu(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}

public enum GameState
{
    MainMenu,
    StartGame,
    PauseGame,
    ResumeGame,
    OptionsGame,
    RestartGame,
    ExitGame,
    WinGame,
    LoseGame
}