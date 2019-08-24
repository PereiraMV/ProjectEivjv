using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnnemiGenerator : MonoBehaviour
{

    public GameObject[] start;
    public GameObject Ennemi;
    private int countNumberEnnemi;
    private int timeBetweenSpawn=5;
    private int numberOnMap;

    public static int countEnnemies=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // on choisit une position random de spawn dans la liste


        int rd = Random.Range(0,start.Length-1);
        Vector3 spawn = start[rd].transform.position;


        if (countEnnemies<10)
        {
            Instantiate(Ennemi, spawn, Quaternion.identity);
            countEnnemies++;
        }

    }
}
