using UnityEngine;

public class GameManager6 : MonoBehaviour
{
    InputHandler _inputHandler;
    ICommand _command;

    void Start()
    {
        _inputHandler = new InputHandler(new JumpCommand(), new AttackCommand());
    }

    void Update()
    {
        _command = _inputHandler.HandleInput();
        if (_command != null)
        {
            //execute this command on a gameobject (probably the player)
            _command.Execute(gameObject);
        }
    }
}
