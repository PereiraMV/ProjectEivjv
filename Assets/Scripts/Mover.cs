using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody myrb;
    public float speed;


    private Renderer rend;

    private Color type=Color.blue;
    
    // Start is called before the first frame update

    void Start()
    {
        myrb = GetComponent<Rigidbody>();
        
        myrb.velocity = transform.forward * speed;

        rend = GetComponent<Renderer>();
        Debug.Log(type);
        rend.material.SetColor(Shader.PropertyToID("_Color"), type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void iniType(Color value)
    {
        type = value;
    }


    public Color getType( )
    {
        return type;
    }

}
