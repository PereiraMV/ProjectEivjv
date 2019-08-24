using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float timeBeforeDestroy=7;
    // Start is called before the first frame update
    void Start()
    {
        //detruire objet apres 7 seconde
        Destroy(gameObject, timeBeforeDestroy);


        // Si l'objet ne bouge plus on annule son collider

    }

    // Update is called once per frame
    void Update()
    {

    }



}
