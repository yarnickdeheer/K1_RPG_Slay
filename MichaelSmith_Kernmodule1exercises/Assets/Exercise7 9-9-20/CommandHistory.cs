using System.Collections.Generic;
using UnityEngine;

public class CommandHistory : MonoBehaviour
{
    List<ICommand2> _commands;

    public void RegisterCommand(ICommand2 command)
	{
		_commands.Add(command);
	}
}
