using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemie;
    public Vector3 spawnValues , center, size;
    public float spawnWait, spawnMostWait, spawnLeasWait;
    public int startWait,enemiesSpawned = 0,maxEnemies;
    public bool stop;

    int randEnemy;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        if (maxEnemies <= enemiesSpawned)
        {
            stop = true;
        }
        else
        {
            stop = false;
        }

        spawnWait = Random.Range(spawnLeasWait, spawnMostWait);

    }

    /*public void SpawnArea()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
   
    }*/

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(spawnWait);
        
        while (!stop)
        {
            enemiesSpawned++;
            randEnemy = Random.Range(0 , 2);
            Vector3 spawnPositon = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z)); //maybe
            Instantiate(enemie[randEnemy], spawnPositon + transform.position, gameObject.transform.rotation);//maybe
            //Instantiate(enemie[randEnemy], spawnPositon + transform.TransformDirection(0, 0, 0), gameObject.transform.rotation);//maybe
            yield return new WaitForSeconds(spawnWait);

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawCube(center, size);
        Gizmos.DrawCube(transform.position, spawnValues); 
    }
}
