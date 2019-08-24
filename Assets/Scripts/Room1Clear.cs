using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Clear : MonoBehaviour
{
    public GameObject dalle1;
    public GameObject dalle2;
    private List<GameObject> dalles;

    public GameObject lamp;

    private bool isClear;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;

        dalles = new List<GameObject>();
        dalles.Add(dalle1);
        dalles.Add(dalle2);

    }

    void Update()
    {
        isClear = true;

        if (!lamp.GetComponent<LightLamp>().getIsActivate()) { isClear = false;  }

        foreach(GameObject d in dalles)
        {
            if (!d.GetComponent<DalleDePression>().getIsActivate()) { isClear = false; }
        }

        if (isClear) { Destroy(gameObject); }
    }

}
