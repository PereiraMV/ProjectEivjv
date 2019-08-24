using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    public int pointVie = 5;
    private bool invincible = false;
    public Slider slider;
    public int timeInvicibility = 20;
    private float startingInvicibility;

    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = pointVie;
        slider.value = pointVie;

    }

    void FixedUpdate()
    {

        if (invincible)
        {
            GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("_Color"), Color.red);
            if (Time.time > timeInvicibility + startingInvicibility)
            {
                invincible = false;
                GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("_Color"), Color.white);
            }
        }
    }

    void dead()
    {
        gameObject.GetComponent<Behaviour>().enabled = false;
        
    }

        void OnCollisionEnter(Collision collision)
        {
            if ((collision.collider.tag == "BulletEnnemi" || (collision.collider.tag == "Ennemi" && !collision.collider.GetComponent<NaveMeshEnnemi>().getisDead())) && !invincible)
            {
                if (pointVie > 1)
                {


                    pointVie -= 1;
                    Debug.Log(pointVie);
                    invincible = true;
                    Debug.Log(invincible);
                    slider.value -= 1;
                    startingInvicibility = Time.time;
                }
                else
                {
                    pointVie -= 1;
                    slider.value -= 1;
                dead();

                }

            }
        }
    }

