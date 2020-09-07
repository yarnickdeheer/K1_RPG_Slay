using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate waves;
    // Start is called before the first frame update



    public void SpawnOrc() 
    { 
  
       Spawner(5,"orc");
   
    }
    public void SpawnSkeleton()
    {
        
        Spawner(5, "skeleton");
   
    }
    void Start()
    {
        SpawnOrc(); 
        SpawnSkeleton();
    }

    public void Spawner(int num, string Type)
    {
        if (Type == "orc")
        {
            for (int i = 0; i<num;i++)
            {
                waves += SpawnOrc;
                Debug.Log("spawn orc");
                
            } 
        }
        else if (Type == "skeleton")
        {
            for (int i = 0; i<num;i++)
            {
                waves += SpawnSkeleton;
                Debug.Log("spawn skeleton");
            } 
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            waves();
        }
    }
}
