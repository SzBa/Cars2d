using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject[] bonuses;
    public int minDelay;
    public int maxDelay;

    private float delay;

    private void Start()
    {
        delay = Random.Range(minDelay, maxDelay);
    }

    private void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0)
        {
            delay = Random.Range(minDelay, maxDelay);
            SpawnBonus();
        }
    }

    private void SpawnBonus()
    {
        Instantiate(bonuses[(int)Random.Range(0,3)], new Vector3(Random.Range(-3.88f, 3.88f),9.5f, 0), Quaternion.identity);     //Instantiate dlatego ze tworzymy obiekt a nic nie zwracamy
    }
}
