using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilCarBehaviour : MonoBehaviour
{
    public float crashDamage = 20f;

    public float civilCarSpeed = 6f;
    public int direction = -1;

    private Vector3 civilCarPosition;

    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, direction, 0) * civilCarSpeed * Time.deltaTime);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.GetComponent<PlayerCarMovement>().durability -= crashDamage / 5;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCarMovement>().durability -= crashDamage;
            Debug.Log("Gracz w nas wjechał");
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "EndOfTheROad")
        {
            Destroy(this.gameObject);
        }
    }
}
