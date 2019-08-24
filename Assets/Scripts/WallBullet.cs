using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBullet : MonoBehaviour
{
    private Color type;
    //private readonly Color[] possibleColor = { Color.blue, Color.yellow, Color.magenta };

    // Start is called before the first frame update
    void Start()
    {
        //type = possibleColor[Random.Range(0, 3)];
        type = Color.yellow;
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor(Shader.PropertyToID("_Color"), type);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            Color bulletType = (collider.gameObject).GetComponent<Mover>().getType();

            if (bulletType != type)
            {
                Destroy(collider.gameObject);
            }
        }
    }    

}
