using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krathong : MonoBehaviour
{
    public int kratongtimes = 1;
    
    private void Update()
    {
        if (transform.position.y <= -13)
        {
            if (tag == "Krathong")
            {
                Score_System.instance.combos = 0;
                Debug.Log("Combo Break!");
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            if (tag == "Krathong")
            {   

                
                int Kratong = 10;

                int Combotimes = Score_System.instance.combotimes;
                if (Player_Control.booster == true)
                {

                    Kratong *= kratongtimes;
                    Kratong *= Player_Control.boostertimes;
                    if (Score_System.instance.combos >= 100)
                    {
                        Kratong += 20;
                    }
                    else if (Score_System.instance.combos >= 50)
                    {
                        Kratong += 10;
                    }
                    else if (Score_System.instance.combos >= 25)
                    {
                        Kratong += 5;
                    }
                    Score_System.instance.ScoreUpdate(Kratong);
                }
                else if (Player_Control.booster != true)
                {
                    Kratong *= kratongtimes;
                    if (Score_System.instance.combos >= 100)
                    {
                        Kratong += 20;
                    }
                    else if (Score_System.instance.combos >= 50)
                    {
                        Kratong += 10;
                    }
                    else if (Score_System.instance.combos >= 25)
                    {
                        Kratong += 5;
                    }
                    Score_System.instance.ScoreUpdate(Kratong);
                }
            }

        }


    }
}
