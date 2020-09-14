using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Define the events (In a bigger project, move these into a seperate class)
public enum EventEnum
{
    ON_GAME_START = 0,
    SPAWN_WAVE_1 = 1
}

public static class EventManager
{
    public delegate void MyDelegate();
    private static Dictionary<EventEnum, MyDelegate> allEvents = new Dictionary<EventEnum, MyDelegate>();

    //Add an event.
    public static void SubscribeToEvent(EventEnum eventType, MyDelegate func)
    {
        if (!allEvents.ContainsKey(eventType)) //if the event type doesnt exist yet, add it.
        {
            allEvents.Add(eventType, null);
        }
        allEvents[eventType] += func;
    }

    //remove an event
    public static void RemoveListener(EventEnum eventType, MyDelegate func)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType] != null) //remove a listener, if the event doesnt exist you cant remove it.
        {
            allEvents[eventType] -= func;
        }
    }

    //Call all the events with the event key
    public static void RaiseEvent(EventEnum eventType)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType] != null)
        {
            allEvents[eventType].Invoke();
        }
    }
}

public static class EventManager<T>
{
    //public delegate void MyGenericDelegate(T input);

    private static Dictionary<EventEnum, System.Action<T>> allEvents = new Dictionary<EventEnum, System.Action<T>>();

    //Add an event.
    public static void SubscribeToEvent(EventEnum eventType, System.Action<T> func)
    {
        if (!allEvents.ContainsKey(eventType)) //if the event type doesnt exist yet, add it.
        {
            allEvents.Add(eventType, null);
        }
        allEvents[eventType] += func;
    }

    //remove an event
    public static void RemoveListener(EventEnum eventType, System.Action<T> func)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType] != null) //remove a listener, if the event doesnt exist you cant remove it.
        {
            allEvents[eventType] -= func;
        }
    }

    //Call all the events with the event key
    public static void RaiseEvent(EventEnum eventType)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType] != null)
        {
            //allEvents[eventType].Invoke();
        }
    }
}