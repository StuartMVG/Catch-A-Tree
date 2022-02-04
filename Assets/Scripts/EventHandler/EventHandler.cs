using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventHandler
{
    public static event Action<int> UpdateScoreEvent;
    public static void CallUpdateScoreEvent(int scoreAmount)
    {
        if (UpdateScoreEvent != null)
        {
            UpdateScoreEvent(scoreAmount);
        }
    }

    public static event Action<float, float> UpdateTimerEvent;
    public static void CallUpdateTimerEvent(float timeLeft, float maxTime)
    {
        if (UpdateTimerEvent != null)
        {
            UpdateTimerEvent(timeLeft, maxTime);
        }
    }

    public static event Action<GameObject> CaughtTreeEvent;
    public static void CallCaughtTreeEvent(GameObject caughtTree)
    {
        if (CaughtTreeEvent != null)
        {
            CaughtTreeEvent(caughtTree);
        }
    }

    public static event Action MissedTreeEvent;
    public static void CallMissedTreeEvent()
    {
        if (MissedTreeEvent != null)
        {
            MissedTreeEvent();
        }
    }

    public static event Action ResetGameEvent;
    public static void CallResetGameEvent()
    {
        if (ResetGameEvent != null)
        {
            ResetGameEvent();
        }
    }
}

