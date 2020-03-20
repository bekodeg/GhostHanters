using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class Clock : MonoBehaviour
{
    #region singleton
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
    #endregion

    public List<Timer> timers;
    private void Start()
    {
        timers = new List<Timer>();
    }

    public void SetTimer(float seconds, UnityAction onEnd)
    {
        Timer t = new Timer(seconds, onEnd);
        timers.Add(t);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Timer timer in timers)
        {
            timer.val -= Time.deltaTime;
            if (timer.val <= 0f)
            {
                timer.OnEnd.Invoke();
                print("tick!");
                timers.Remove(timer);
            }
        }
    }
}
public class Timer
{
    public float val;
    public UnityAction OnEnd;

    public Timer(float seconds, UnityAction action)
    {
        this.val = seconds;
        this.OnEnd = action;
    }
}