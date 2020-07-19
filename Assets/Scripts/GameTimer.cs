using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class GameTimer : MonoBehaviour
{
    float waiting = 0f;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        waiting += Time.deltaTime;
        var ts = TimeSpan.FromSeconds(waiting);
        GetComponent<TextMeshProUGUI>().text = String.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
    }
}
