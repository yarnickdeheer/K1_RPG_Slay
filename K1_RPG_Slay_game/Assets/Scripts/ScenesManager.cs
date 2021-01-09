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
				SceneManager.LoadScene(currentScene.buildIndex + 1);
				_gm.StartCoroutineLoadScene(1);
				break;
			case 1: //go to battle
				SceneManager.LoadScene(currentScene.buildIndex + 1);
				_gm.StartCoroutineLoadScene(2);
				break;
			case 2: //go to end screen
				SceneManager.LoadScene(currentScene.buildIndex + 1);
				_gm.StartCoroutineLoadScene(3);
				break;
			case 3: //back to map
				SceneManager.LoadScene(currentScene.buildIndex - 2);
				_gm.StartCoroutineLoadScene(1);
				break;
			default:
				break;
		}

		GC.Collect();
	}

	//for when you go back to the main menu
	public void LoadScene0()
	{
		//instantiate a new selectbutton which handles the player input on the startscreen
		_gm._selectButton = new SelectButton(Resources.Load<Sprite>("Sprites/PlayerSelect"),
				Resources.Load<Sprite>("Sprites/PlayerDeselect"),
				Resources.Load<GameObject>("Prefabs/Button"), false);

		EventManager.AddListener(EventType.ON_LEFT, _gm._selectButton.SelectedActionLeft);
		EventManager.AddListener(EventType.ON_RIGHT, _gm._selectButton.SelectedActionRight);
		EventManager.AddListener(EventType.ON_USE, _gm._selectButton.Use);
	}

	public void LoadScene1()
	{
		//instantiate a new encountermanager script which handles the map logic
		_gm._em = new EncounterManager();

		EventManager.AddListener(EventType.ON_LEFT, _gm._em.SelectedEncounterLeft);
		EventManager.AddListener(EventType.ON_RIGHT, _gm._em.SelectedEncounterRight);
		EventManager.AddListener(EventType.ON_USE, _gm._em.Use);
	}

	public void LoadScene2()
	{
		_gm._currentEnemy = new Enemy(2, 2, 2, 2);

		_gm._selectButton = new SelectButton(Resources.Load<Sprite>("Sprites/PlayerSelect"),
		Resources.Load<Sprite>("Sprites/PlayerDeselect"),
		Resources.Load<GameObject>("Prefabs/Button"), true);

		_gm._combatDisplay = new CombatDisplay(Resources.Load<GameObject>("Prefabs/dis"),
		Resources.Load<GameObject>("Prefabs/moveP"),
		Resources.Load<GameObject>("Prefabs/Php"),
		Resources.Load<GameObject>("Prefabs/EEhp"),
		Resources.Load<GameObject>("Prefabs/Canvas"));
		_gm._combatHandler = new CombatHandler(1, false, 1, 9, _gm._player as IPlayer, true, _gm._currentEnemy as IEnemy, _gm._combatDisplay);

		EventManager.AddListener(EventType.ON_LEFT, _gm._selectButton.SelectedActionLeft);
		EventManager.AddListener(EventType.ON_RIGHT, _gm._selectButton.SelectedActionRight);
		EventManager.AddListener(EventType.ON_USE, _gm._selectButton.Use);
	}

	public void LoadScene3()
	{

	}
}