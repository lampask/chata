using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject navigation;
    public GameObject options;
    private bool trigger;

    void Start()
    {
        trigger = false;
        SoundManager.instance.Play("Menu", true);
        navigation.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(Play);  
        navigation.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(Tutorial);
        navigation.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(Options);
        navigation.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(Quit);
    }


    public void Play() {
        if (!trigger) {
            SoundManager.instance.Play("ButtonClick", false, GetComponent<AudioSource>());
            Debug.Log("Play trigerred!");
            StartCoroutine(Play_waiter());
            trigger = true;
        }
    }
    IEnumerator Play_waiter() {
        yield return new WaitWhile (()=> GetComponent<AudioSource>().isPlaying);
        ScreenManager.instance.LoadGame();
    }

    // DISABLED
    public void Tutorial() {
        SoundManager.instance.Play("ButtonClick", false, GetComponent<AudioSource>());
        Debug.Log("Stats trigerred!");
    }

    // DISABLED
    public void Options() {
        SoundManager.instance.Play("ButtonClick", false, GetComponent<AudioSource>());
        Debug.Log("Options trigerred!");
        options.SetActive(!options.activeSelf);
    }

    public void Quit() {
        if (!trigger) {
            SoundManager.instance.Play("ButtonClick", false, GetComponent<AudioSource>());
            Debug.Log("Quit trigerred!");
            StartCoroutine(Quit_waiter());
            trigger = true;
        }
    }
    IEnumerator Quit_waiter() {
        yield return new WaitWhile (()=> GetComponent<AudioSource>().isPlaying);
        Application.Quit();
    }

    public void Cretits() {
        SoundManager.instance.Play("ButtonClick", false, GetComponent<AudioSource>());
        Debug.Log("Credits trigerred!");
        ScreenManager.instance.LoadCredits();
    }

    public void ClearSelection() {
        //foreach(var button in navigation.GetComponentsInChildren<Button>()) 
            //if (button.)button.Select();
    }
}

