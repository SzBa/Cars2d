using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarMovement : MonoBehaviour
{
    public float carHorizontalSpeed = 3f;
    private Vector3 carPosition;
    private float liquidity = 9f; // plynnosc przechylenia samochodu przy skręcie
    private float angle = 30f; //kat przechylenia samochodu przy skrecie

    public float maxDurability = 100f;

    //[HideInInspector] // ukrycie w inspektorze
    public float durability;

    void Start()
    {
        carPosition = this.gameObject.transform.position;
        durability = maxDurability;
    }

    private void Update()
    {
        float katPrzechyleniaOsiZ = -Input.GetAxis("Horizontal") * angle;
        float mobilnyKatPrzechyleniaOsiZ = -Input.acceleration.x * angle;
        Quaternion target = Quaternion.Euler(0, 0, katPrzechyleniaOsiZ);
        Quaternion target2 = Quaternion.Euler(0, 0, mobilnyKatPrzechyleniaOsiZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * liquidity);
        transform.rotation = Quaternion.Slerp(transform.rotation, target2, Time.deltaTime * liquidity);
        carPosition.x += Input.GetAxis("Horizontal") * carHorizontalSpeed * Time.deltaTime;
        carPosition.x += Input.acceleration.x * carHorizontalSpeed * Time.deltaTime * 2;
        carPosition.x = Mathf.Clamp(carPosition.x, -3.04f, 3.04f);
        this.gameObject.transform.position = carPosition;
    }
}
