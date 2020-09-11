using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFunction : MonoBehaviour
{

    public delegate void WaveDelegate();
    public WaveDelegate wave;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.SubscribeToEvent(EventEnum.SPAWN_WAVE_1, SpawnDragon);
        EventManager.SubscribeToEvent(EventEnum.SPAWN_WAVE_1, SpawnOrc);
        EventManager.SubscribeToEvent(EventEnum.SPAWN_WAVE_1, SpawnSkeleton);
        EventManager.SubscribeToEvent(EventEnum.SPAWN_WAVE_1, SpawnOrc);
        EventManager.SubscribeToEvent(EventEnum.SPAWN_WAVE_1, SpawnOrc);
        EventManager.SubscribeToEvent(EventEnum.SPAWN_WAVE_1, SpawnSkeleton);

        //Generic even manager like this
        //EventManager<IPointable>.SubscribeToEvent(EventEnum.SPAWN_WAVE_1, SpawnOrc, this);

        EventManager.RaiseEvent(EventEnum.SPAWN_WAVE_1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.RaiseEvent(EventEnum.SPAWN_WAVE_1);
        }
    }

    public void SpawnDragon()
    {
        Debug.Log("Dragon has been spawned");
    }

    public void SpawnSkeleton()
    {
        Debug.Log("Skeleton has been spawned");
    }

    public void SpawnOrc()
    {
        Debug.Log("Orc has been spawned");
    }
}
