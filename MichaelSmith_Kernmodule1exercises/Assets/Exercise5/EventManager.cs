public static class EventManager<T>
{
	public delegate void MyDelegate(T t);
	public static event MyDelegate myEvent;

	public static void AddListener(MyDelegate func)
	{
		myEvent += func;
	}

	public static void RemoveListener(MyDelegate func)
	{
		myEvent -= func;
	}

	public static void RaiseMyEvent(T t)
	{
		myEvent?.Invoke(t);
	}
}