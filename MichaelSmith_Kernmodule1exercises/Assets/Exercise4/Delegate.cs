using UnityEngine;

public class Delegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate wave;

	private void Start()
	{
		wave = wave + SpawnOrc + SpawnZombie;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{ 
			wave(); 
		}
	}

	public void SpawnOrc()
	{
		return;
	}

	public void SpawnZombie()
	{
		return;
	}
}
