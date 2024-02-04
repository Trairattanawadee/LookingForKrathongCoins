using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAreas : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector3(x, y, z);
        }
        
    }
}

