using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    bool StopwatchActive;
    public float CurrentTime;

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
