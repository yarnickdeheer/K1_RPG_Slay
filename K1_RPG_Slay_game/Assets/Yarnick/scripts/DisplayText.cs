using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText 
{
	public Text _objectText;
	public GameObject _text;

	public DisplayText(GameObject text,GameObject parent, float xpos,float ypos)
	{
		_text = Object.Instantiate(text, new Vector3(xpos,ypos,0), Quaternion.identity, parent.transform);
		_objectText = _text.GetComponent<Text>();
	}
}
