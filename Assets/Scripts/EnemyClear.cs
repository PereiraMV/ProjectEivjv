using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClear : MonoBehaviour
{
    public static int killGoal = 16;
    private static int killCount;
    public GameObject gen;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (killCount >= killGoal) {
            Destroy(gameObject);
            Destroy(gen);
        }
    }

    public static void countKill() { killCount++; }

    public static int getKillCount() { return killCount; }
    

}
