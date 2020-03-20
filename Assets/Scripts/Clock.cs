using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Clock : MonoBehaviour
{
    private static Clock _clock;
    public static Clock Instance()
    {
        return _clock;
    }
    private void Awake()
    {
        if (Clock.Instance() == null)
            _clock = this;
        DontDestroyOnLoad(this);
    }


    public List<queuing> timerQueue;
    public (int, int) time;
    float counter = 0.0f;

    private void Start()
    {
        timerQueue = new List<queuing>();
        time = (0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 0)
        {
            time.Item1 += 1;
            time.Item2 += time.Item1 / 60;
            time.Item1 %= 60;
            CheckTimer();
        }
    }
    void CheckTimer()
    {
        for (int i = 0; i < timerQueue.Count; i++)
        {
            if (timerQueue[i].time == time)
                timerQueue[i].func();
        }
    }
}
public class queuing
{
    public (int, int) time;
    public delegate void voi();
    public voi func;
    public bool 
}