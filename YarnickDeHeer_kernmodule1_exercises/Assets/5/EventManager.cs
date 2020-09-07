using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public enum EventEnum
    {
        ON_GAME_START = 0
    }

    public delegate void VoidDelegate();
    private Dictionary<EventEnum, VoidDelegate> allEvents = new Dictionary<EventEnum, VoidDelegate>();
    public void SubscribeToEvent(EventEnum eventType,VoidDelegate func)
    {
        if (!allEvents.ContainsKey(eventType))
        {
            allEvents[eventType] += func;
        }
        allEvents[eventType] += func;
        
        //eventmanager.AddListener()
    }
    public void RemoveListener(EventEnum eventType, VoidDelegate func)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType]!=null)
        {
            allEvents[eventType] -= func;
        }
    }
    public void RaiseEvent(EventEnum eventType)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType]!=null)
        {
            allEvents[eventType].Invoke();
        }
        
    }

}
public static class EventManager<T>
{
    public enum EventEnum
    {
        ON_GAME_START = 0
    }

    public delegate void VoidDelegate();
    private static Dictionary<EventEnum, VoidDelegate> allEvents = new Dictionary<EventEnum, VoidDelegate>();
    public static void SubscribeToEvent(EventEnum eventType, VoidDelegate func)
    {
        if (!allEvents.ContainsKey(eventType))
        {
            allEvents[eventType] += func;
        }
        allEvents[eventType] += func;

        //eventmanager.AddListener()
    }
    public static void RemoveListener(EventEnum eventType, VoidDelegate func)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType] != null)
        {
            allEvents[eventType] -= func;
        }
    }
    public static void RaiseEvent(EventEnum eventType)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType] != null)
        {
            allEvents[eventType].Invoke();
        }

    }

}