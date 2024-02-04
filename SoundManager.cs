using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource collectedFruitSound, collectedBombSound, collectedBoosterSound,
        collectedShieldSound, collectedTeleportSound, teleportExpired;
    // Start is called before the first frame update



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    public void CollectItem(int Item)
    {
        /*
           1 = Booster
           2 = Shield
           3 = Teleport
        */
        switch (Item)
        {
            case 1:
                collectedBoosterSound.Play();
                break;
            case 2:
                collectedShieldSound.Play();
                break;
            case 3:
                collectedTeleportSound.Play();
                break;
        }
    }
    public void CollectKrathong()
    {
        collectedFruitSound.Play();
    }
    public void CollectBomb()
    {
        collectedBombSound.Play();
    }
    public void TeleportState()
    {
        teleportExpired.Play();
    }
}
