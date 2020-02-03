using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarDurabilityManager : MonoBehaviour
{
    public GameObject playerCarPrefab;
    public GameObject spawnPoint;
    public TextMesh durabilityText;
    public TextMesh lifeText;
    public TextMesh timer;
    public int time = 0;
    public int lifes;
    private GameObject playerCar;

    private void Start()
    {
        playerCar = (GameObject)Instantiate(playerCarPrefab, spawnPoint.transform.position, Quaternion.identity);
        StartCoroutine("StartTime");
    }

    private void Update()
    {
        if(playerCar.GetComponent<PlayerCarMovement>().durability <= 0)
        {
            Destroy(playerCar);
            lifes--;
            if(lifes > 0)
            {
                StartCoroutine("SpawnaCar");
            }
        }
        else if(playerCar.GetComponent<PlayerCarMovement>().durability > 100)
        {
            playerCar.GetComponent<PlayerCarMovement>().durability = playerCar.GetComponent<PlayerCarMovement>().maxDurability;

        }

        durabilityText.text = "Hp: " + playerCar.GetComponent<PlayerCarMovement>().durability + "/" + playerCar.GetComponent<PlayerCarMovement>().maxDurability;
        lifeText.text = "Lifes: " + GetComponent<CarDurabilityManager>().lifes + "/" + "3";
        timer.text = ("" + time + " seconds you alive :)");

        if(lifes == 0)
        {
            time = 0;
            SceneManager.LoadScene("mainlevel");
        }
    }

    IEnumerator SpawnaCar()
    {
        playerCar = (GameObject)Instantiate(playerCarPrefab, spawnPoint.transform.position, Quaternion.identity); // miesjce spawnu
        playerCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f); // ustawienie koloru chwilowej niesmietelnosci
        playerCar.GetComponent<BoxCollider2D>().isTrigger = true; // niezniszczalnosc
        playerCar.tag = "Untouchable";
        yield return new WaitForSeconds(3); // niesmietelność
        playerCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f); // ustawienie normalnego koloru zeby gracz wiedzial ze jest smiertelny
        playerCar.GetComponent<BoxCollider2D>().isTrigger = false;
        playerCar.tag = "Player";
    }

    IEnumerator StartTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
}
