using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    bool StopwatchActive;
    float CurrentTime;
    public Text CurrentTimeText;

    void Start()
    {
        CurrentTime = 0;
    }

    void Update()
    {
        if (StopwatchActive)
        {
            CurrentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        CurrentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartStopwatch()
    {
        StopwatchActive = true;
    }

    public void StopStopwatch()
    {
        StopwatchActive = false;
    }
}
