using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
	private static Dictionary<EventType, System.Action> eventDictionary = new Dictionary<EventType, System.Action>();

	public static void AddListener(EventType type, System.Action function)
	{
		if (!eventDictionary.ContainsKey(type))
		{
			eventDictionary.Add(type, null);
		}
		eventDictionary[type] += function;
	}

	public static void RemoveListener(EventType type, System.Action function)
	{
		if (eventDictionary.ContainsKey(type) & eventDictionary[type] != null)
		{
			eventDictionary[type] -= function;
		}
	}

	public static void RaiseEvent(EventType type)
	{
		eventDictionary[type]?.Invoke();
	}
}
