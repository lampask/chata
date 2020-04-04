using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject navigation;
    public GameObject options;

    void Start()
    {
        navigation.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(Play);  
        navigation.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(Tutorial);
        navigation.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(Options);
        navigation.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(Quit);
    }



    public void Play() {
        Debug.Log("Play trigerred!");
        ScreenManager.instance.LoadGame();
    }

    public void Tutorial() {
        Debug.Log("Stats trigerred!");
    }

    public void Options() {
        Debug.Log("Options trigerred!");
        options.SetActive(!options.activeSelf);
    }

    public void Quit() {
        Debug.Log("Quit trigerred!");
        
    }

    public void Cretits() {
        Debug.Log("Credits trigerred!");
        ScreenManager.instance.LoadCredits();
    }

    public void ClearSelection() {
        //foreach(var button in navigation.GetComponentsInChildren<Button>()) 
            //if (button.)button.Select();
    }
}

