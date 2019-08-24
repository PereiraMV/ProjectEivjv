using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampInteraction : MonoBehaviour
{
    private Color type;
    private bool isActivate;
    private Color curentColor;
    private readonly Color[] possibleColor = { Color.blue, Color.yellow, Color.magenta };

    // Start is called before the first frame update
    void Start()
    {
        type = possibleColor[Random.Range(0, 3)];
        curentColor = Color.white;
        isActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor(Shader.PropertyToID("_Color"), curentColor);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Color bulletType = (collision.gameObject).GetComponent<Mover>().getType();
            curentColor = bulletType;
            if (bulletType == type)
            {
                Destroy(collision.gameObject);
                isActivate = true;
            }
        }
    }

    public bool getIsActivate()
    {
        return isActivate;
    }
}
