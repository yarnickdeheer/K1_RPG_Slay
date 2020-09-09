using UnityEngine;

public class CreateObjectCommand : ICommand2
{
    public GameObject _prefab;
    public Vector3 _position;
    public Quaternion _rotation;
    public GameObject _gameObjectInstance;

    public CreateObjectCommand(GameObject prefab, Vector3 position, Quaternion rotation)
	{
        _prefab = prefab;
        _position = position;
        _rotation = rotation;
	}

    public void Execute()
    {
        _gameObjectInstance = Object.Instantiate(_prefab, _position, _rotation);
    }

    public void Undo()
    {
        Object.Destroy(_gameObjectInstance);
    }
}
