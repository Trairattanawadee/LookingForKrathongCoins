using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public Vector2 minPosition, maxPosition;

    public float moveSpeed = 6f;
    public float BoostSpeed = 2f;
    void Update()
    {
        if (Score_System.gamestart)
        {
            float h = Input.GetAxis("Horizontal");
            Vector3 pos = transform.position;
            float moveDelta = moveSpeed * Time.deltaTime;
            Vector3 movement = new Vector3(h, 0, 0) * moveDelta;

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                movement *= BoostSpeed;
                Debug.Log("Start Running");
            }
            pos += movement;

            if (pos.x <= minPosition.x)
            {
                pos.x = minPosition.x;
            }
            if (pos.x >= maxPosition.x)
            {
                pos.x = maxPosition.x;
            }
            if (pos.y <= minPosition.y)
            {
                pos.y = minPosition.y;
            }
            if (pos.y >= maxPosition.y)
            {
                pos.y = maxPosition.y;
            }

            transform.position = pos;

        }

        if (teleporter)
        {
            teleporterOBJ.SetActive(true);
            if (teleportimer <= 0)
            {
                teleporter = false;
                SoundManager.instance.TeleportState();
                Debug.Log("Teleport Expired...");

            }
            teleportimer -= Time.deltaTime;
        }
        if (!teleporter)
        {
            teleporterOBJ.SetActive(false);
        }
        if (booster)
        {
            if (boosttimer <= 0)
            {
                booster = false;
                Debug.Log("Booster Expired...");
            }
            boosttimer -= Time.deltaTime;
        }

    }
    
    public static int boostertimes = 5;
    public static bool booster, shield, teleporter = false;
    public static float boosttimer, teleportimer;
    public GameObject Idle, Hurt, shieldON, shieldHurt, teleporterOBJ;

    private void OnTriggerEnter(Collider other)
    {
        shieldHurt.SetActive(false);
        Idle.SetActive(true);

        if (other.gameObject.CompareTag("Krathong") && Score_System.gamestart)
        {
           SoundManager.instance.CollectKrathong();
           Score_System.instance.combos++;
           Destroy(other.gameObject);
           Idle.SetActive(true);
           Hurt.SetActive(false);
           shieldHurt.SetActive(false);
           Debug.Log("Krathong Collected !");
        }
        if (other.gameObject.CompareTag("Bomb"))
        {
            SoundManager.instance.CollectBomb();
            if (shield)
            {
                shield = false;
                shieldHurt.SetActive(true);
                shieldON.SetActive(false);
                Debug.Log("Bomb Collected but Blocked!");
            }
            else if (!shield)
            {
                Score_System.instance.life++;
                Score_System.instance.combos = 0;
                Debug.Log("Bomb Collected !");
                Idle.SetActive(false);
                Hurt.SetActive(true);
            }

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Booster"))
        {
            SoundManager.instance.CollectItem(1);
            booster = true;
            boosttimer = 10;
            Debug.Log("Booster Gain");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Shield"))
        {
            SoundManager.instance.CollectItem(2);
            shield = true;
            shieldHurt.SetActive(false);
            shieldON.SetActive(true);
            Debug.Log("Shield Gain");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Teleport"))
        {
            SoundManager.instance.CollectItem(3);
            teleporter = true;
            teleportimer = 10;
            Debug.Log("Teleport Gain");
            Destroy(other.gameObject);
        }
    }
}
