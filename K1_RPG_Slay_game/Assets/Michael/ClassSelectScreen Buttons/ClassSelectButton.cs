using UnityEngine;

public class ClassSelectButton
{
	/*<summary>
	Small script that instantiates a button on a certain spot.
	</summary>*/

	public SpriteRenderer _buttonSR;
	public GameObject _go;

	public ClassSelectButton(GameObject button, float xLocation, float yLocation)
	{
		_go = Object.Instantiate(button, new Vector3(xLocation, yLocation, 0), Quaternion.identity);
		_buttonSR = _go.GetComponent<SpriteRenderer>();
	}
}