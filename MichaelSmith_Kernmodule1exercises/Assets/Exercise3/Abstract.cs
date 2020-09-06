using System.Collections.Generic;

public abstract class MyClass<T>
{
	public static Dictionary<T, string> myDictionary = new Dictionary<T, string>();
	public static string Find(T GenericVariable)
	{
		myDictionary.TryGetValue(GenericVariable, out string value);
		return value;
	}
}