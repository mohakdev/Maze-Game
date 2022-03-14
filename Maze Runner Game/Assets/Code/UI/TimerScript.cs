using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static TimerScript instance;
    TimeSpan timePlaying;
    public Text timeLabel;
    bool TimerGoing;
    float elapsedTime;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        timeLabel.text = "00:00:00";
        TimerGoing = false;
    }
    public void BeginTimer()
    {
        TimerGoing = true;
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
        Printer.PrintMsg("Timer Started");
    }
    IEnumerator UpdateTimer()
    {
        while (TimerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string TimeStr = timePlaying.ToString("mm':'ss'.'ff");
            timeLabel.text = TimeStr;
            yield return null;
        }
    }
    public void EndTimer()
    {
        TimerGoing = false;
    }
}
