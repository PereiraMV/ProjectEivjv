using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{
    private Rigidbody myrb;
    public float speed;


    // Start is called before the first frame update

    void Start()
    {
        myrb = GetComponent<Rigidbody>();

        myrb.velocity = transform.forward * speed;
    }
}

