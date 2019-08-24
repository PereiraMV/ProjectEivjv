using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLamp : MonoBehaviour
{
    private bool isActivate;

    // Start is called before the first frame update
    void Start()
    {
        isActivate = false;
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor(Shader.PropertyToID("_Color"), Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            isActivate = true;
            Renderer rend = GetComponent<Renderer>();
            rend.material.SetColor(Shader.PropertyToID("_Color"), Color.green);
        }
    }

    public bool getIsActivate()
    {
        return isActivate;
    }
}
