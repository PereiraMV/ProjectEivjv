using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Plateforme : MonoBehaviour
{
    public GameObject lamp1;
    public GameObject lamp2;
    public GameObject lamp3;
    private List<GameObject> lamps;
    private bool isClear;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        lamps = new List<GameObject>();
        lamps.Add(lamp1);
        lamps.Add(lamp2);
        lamps.Add(lamp3);
    }

    // Update is called once per frame
    void Update()
    {
        isClear = true;
        foreach (GameObject l in lamps)
        {
            //Debug.Log(l.GetComponent<LampInteraction>().getIsActivate());
            if (!l.GetComponent<LampInteraction>().getIsActivate()) { isClear = false; }
        }

        if (isClear) { Destroy(gameObject); }
    }
}
