using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] GameObject winScreen, loseScreen, background, canvas, ui;
    public static WinLoseManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public void Start(){
        background.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }
    public void WinLoseScreenToggle(){
        canvas.SetActive(false);
    }
    public void WinSetup(bool winLose){
        canvas.SetActive(true);
        ui.SetActive(false);
        Debug.Log("CALLED");
        background.SetActive(true);
        
        if(winLose){
        loseScreen.SetActive(false);
        winScreen.SetActive(true);
        }else{            
        winScreen.SetActive(false);
        loseScreen.SetActive(true);
        }
    }
}
