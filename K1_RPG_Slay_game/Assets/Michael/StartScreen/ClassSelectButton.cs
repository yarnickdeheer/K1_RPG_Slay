using UnityEngine;

public class ClassSelectButton : SelectButton
{
	SpriteRenderer _buttonSR;

	private ClassSelectButton()
	{
		GameObject go = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Button"));
		_buttonSR = go.GetComponent<SpriteRenderer>();
		OnCreateButton(go);
	}
}