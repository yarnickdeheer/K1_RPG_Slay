using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager
{
	GameManager _gm;

	public ScenesManager()
	{
		_gm = GameManager.Instance;
	}

	public void SceneSwitch()
	{
		Scene currentScene = SceneManager.GetActiveScene();

		//this part of the script knows what scene to switch to
		switch (currentScene.buildIndex)
		{
			case 0: //go to map
				LoadScene1();
				_gm._selectButton = null;
				SceneManager.LoadScene(currentScene.buildIndex + 1);
				break;
			case 1: //go to battle
				LoadScene2();
				_gm._em = null;
				SceneManager.LoadScene(currentScene.buildIndex + 1);
				break;
			case 2: //go to end screen
				LoadScene3();
				SceneManager.LoadScene(currentScene.buildIndex + 1);
				break;
			case 3: //back to map
				LoadScene1();
				SceneManager.LoadScene(currentScene.buildIndex - 2);
				break;
			default:
				break;
		}

		GC.Collect();
	}

	public void LoadScene0()
	{
		//instantiate a new selectbutton which handles the player input on the startscreen
		_gm._selectButton = new SelectButton(Resources.Load<Sprite>("Sprites/PlayerSelect"),
				Resources.Load<Sprite>("Sprites/PlayerDeselect"),
				Resources.Load<GameObject>("Prefabs/Button"), false);

		_gm._im.OnLeftButtonPressed += _gm._selectButton.SelectedActionLeft;
		_gm._im.OnRightButtonPressed += _gm._selectButton.SelectedActionRight;
		_gm._im.OnSelectButtonPressed += _gm._selectButton.Use;
	}

	public void LoadScene1()
	{
		//instantiate a new encountermanager script which handles the map logic
		_gm._em = new EncounterManager();

		_gm._im.OnLeftButtonPressed += _gm._em.SelectedEncounterLeft;
		_gm._im.OnRightButtonPressed += _gm._em.SelectedEncounterRight;
		_gm._im.OnSelectButtonPressed += _gm._em.Use;
	}

	public void LoadScene2()
	{
		_gm._selectButton = new SelectButton(Resources.Load<Sprite>("Sprites/PlayerSelect"),
			Resources.Load<Sprite>("Sprites/PlayerDeselect"),
			Resources.Load<GameObject>("Prefabs/Button"), true);
		_gm._combatHandler = new CombatHandler(1, false, 1, 9);

		_gm._im.OnLeftButtonPressed += _gm._selectButton.SelectedActionLeft;
		_gm._im.OnRightButtonPressed += _gm._selectButton.SelectedActionRight;
		_gm._im.OnSelectButtonPressed += _gm._selectButton.Use;
	}

	public void LoadScene3()
	{

	}
}