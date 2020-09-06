using UnityEngine;

public class UI<T> : MonoBehaviour
{
	public void Start()
	{
		EventManager<T>.AddListener(ChangeUI());
	}

	public EventManager<T>.MyDelegate ChangeUI()
	{
		//Change the UI
		return ChangeUI();
	}
}
