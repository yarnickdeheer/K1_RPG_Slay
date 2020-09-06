using UnityEngine;

public class EventCaller<T> : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			T t = default;
			EventManager<T>.RaiseMyEvent(t);
		}
	}
}
