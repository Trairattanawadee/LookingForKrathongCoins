using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y <= -13)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bomb")
        {
            Destroy(gameObject);
        }
        else if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }

    }
}
