using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbrellaCollider : MonoBehaviour
{
    public GameObject umbrella;
    private string fallingTag = "Fall";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(fallingTag) == true)
        {
            umbrella.GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(fallingTag) == true)
        {
            umbrella.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 30;
        }
    }
}
