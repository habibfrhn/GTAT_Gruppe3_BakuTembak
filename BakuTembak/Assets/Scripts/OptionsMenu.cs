using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //SHOULD BE ABLE TO BE CALLED FROM MAIN MENU SCENE and LEVEL 1/2 SCENES
    public static OptionsMenu Instance;
    [SerializeField] GameObject MenuScreen, OptionsScreen;
    [SerializeField] Slider slider;
    void Awake()
    {
        Instance = this;
    }
    void Start(){
        //slider.onValueChanger.AddListener();
    }
    public void openOptionsMenu(){
        MenuScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }
    public void BackBtnAction(){
        Debug.Log("Back Btn Pressed"); 
        MenuScreen.SetActive(true);
        OptionsScreen.SetActive(false);
    }
    //TODO SLIDER FOR SOUNDMANAGER
}
