using UnityEngine;

public class ClassSelectButton
{
	public SpriteRenderer _buttonSR;

	public ClassSelectButton(GameObject button, float xLocation, float yLocation)
	{
		GameObject go = Object.Instantiate(button, new Vector3(xLocation, yLocation, 0), Quaternion.identity);
		_buttonSR = go.GetComponent<SpriteRenderer>();
	}
}