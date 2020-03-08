using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject Good;
    public GameObject bad;
    public int min;
    public int max;
    public int num;
    public int secondGood;
    public int secondBad;
    

    void Start()
    {
        RandomSpawnGood();
        RandomSpawnBad();
        
    }

    public void Start1()
    {
        
        RandomSpawnGood();
        RandomSpawnBad();
        
    }

    

    void RandomSpawnGood()
    {
        double a = 0;
        while (a != num)
        {
            Vector2 position = new Vector2(UnityEngine.Random.Range(min, max), -125);
            GameObject go = Instantiate(Good);
            go.transform.position = position;
            a = a + 1;
            StartCoroutine(SpawnTimeGood());
        }
    }
    IEnumerator SpawnTimeGood()
    {
        double a = 0;
        while (a != num)
        {
            Vector2 position = new Vector2(UnityEngine.Random.Range(min, max), 55);
            GameObject go = Instantiate(Good);
            go.transform.position = position;
            a = a + 0.1;
            yield return new WaitForSeconds(secondGood);
        }
    }
    void RandomSpawnBad()
    {
        double a = 0;
        while (a != num)
        {
            Vector2 position = new Vector2(UnityEngine.Random.Range(min, max), -125);
            GameObject go = Instantiate(bad);
            go.transform.position = position;
            a = a + 1;
            StartCoroutine(SpawnTimeBad());
        }
    }
    IEnumerator SpawnTimeBad()
    {
        double a = 0;
        while (a != num)
        {
            Vector2 position = new Vector2(UnityEngine.Random.Range(min, max), 55);
            GameObject go = Instantiate(bad);
            go.transform.position = position;
            a = a + 0.1;
            yield return new WaitForSeconds(secondBad);
        }
    }
}  

