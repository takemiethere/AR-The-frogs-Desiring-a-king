using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour   
{

    public GameObject EnemyRb;

    // Start is called before the first frame update
   /*void Start()
    {
        Vector3 randomPos = new Vector3(Random.Range(-3.5f,3.5f), Random.Range(- 4.3f,13.5f));
        
        Instantiate(EnemyRb, randomPos, transform.rotation);
        //Instantiate(EnemyRb, transform.position, transform.rotation);
    }*/
    
    // Update is called once per frame
    void Update()
    {
         Vector3 randomPos = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-4.3f, 13.5f));

         Instantiate(EnemyRb, randomPos, transform.rotation);
        //???????????? ??????? transform.rotation ???? Quaternion.identit ??
        //Instantiate(EnemyRb, transform.position, transform.rotation);
    }

}
