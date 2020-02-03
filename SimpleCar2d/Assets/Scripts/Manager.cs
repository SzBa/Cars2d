using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [Header("Wave 1(Civil Cars)")]
    public float civilCarSpawnDelay;
    public GameObject civilCar;
    public int civilCarsAmount; 


    private float[] lanesArray;
    private float spawnDelay;

    private void Start()
    {
        lanesArray = new float[4];
        lanesArray[0] = -2.76f;
        lanesArray[1] = -0.9f;
        lanesArray[2] = 0.9f;
        lanesArray[3] = 2.76f;

        spawnDelay = civilCarSpawnDelay;
    }

    private void Update()
    {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay <= 0)
        {
            spawnCar();
            spawnDelay = civilCarSpawnDelay;
        }
    }

    void spawnCar()
    {
        int lane = Random.Range(0,4);
        if(lane == 0 || lane == 1)
        {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(lanesArray[lane], 9.4f), Quaternion.Euler(new Vector3(0, 0, 180)));
            car.GetComponent<CivilCarBehaviour>().direction = 1;
            car.GetComponent<CivilCarBehaviour>().civilCarSpeed = 12f;
        }
        if(lane == 2 || lane == 3)
        {
            Instantiate(civilCar, new Vector3(lanesArray[lane], 9.4f, 0), Quaternion.identity); // quaternion odpowiada za rotacje obiektu
        }
        civilCarsAmount--;
        
    }

}
