using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour   
{

    public GameObject EnemyRb;
   // public bool stopSpawning = false;
   // public float SpawnibTime;
    //public float SpawnDelay;

    // Start is called before the first frame update
    //void Start()
    //{
    //    InvokeRepeating("SpawnObj",SpawnibTime, SpawnDelay);
            
    //}
    
    //public void SpawnObject()
    //{
        //Vector3 randomPos = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-4.3f, 13.5f));
        //Instantiate(EnemyRb, randomPos, transform.rotation);
    //}
    
    

    void Update()
    {
         Vector3 randomPos = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-4.3f, 13.5f));

         Instantiate(EnemyRb, randomPos, transform.rotation);
        //???????????? ??????? transform.rotation ???? Quaternion.identit ??
        //Instantiate(EnemyRb, transform.position, transform.rotation);
    }

}
