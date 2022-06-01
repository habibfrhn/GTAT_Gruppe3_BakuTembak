using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //CAN ONLY BE CALLED INGAME
public static PauseMenu Instance;
[SerializeField] GameObject IngameMenu, MenuPause;
    void Awake()
    {
        Instance = this;
    }
    public void ToggleIngameMenu(bool onOff){
        IngameMenu.SetActive(onOff);
        MenuPause.SetActive(onOff);
    }
    public void ResumeBtnAction(){
        Debug.Log("Resume Pressed");
        MenuManager.Instance.UpdateGameState(GameState.ResumeGame);
    }
    public void RestartBtnAction(){
        Debug.Log("Restart Pressed");
        MenuManager.Instance.UpdateGameState(GameState.RestartGame);
    }
    public void OptionsBtnAction(){
        Debug.Log("Options Pressed");
        MenuManager.Instance.UpdateGameState(GameState.OptionsGame);
    }
    public void ExitBtnAction(){
        MenuManager.Instance.UpdateGameState(GameState.ExitGame);
    }
}