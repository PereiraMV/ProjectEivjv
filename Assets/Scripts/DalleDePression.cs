using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalleDePression : MonoBehaviour
{
    private bool isActivate;
    // Start is called before the first frame update
    void Start()
    {
        isActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        Color c = Color.red;
        if (isActivate == true) { c = Color.green; }

        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor(Shader.PropertyToID("_Color"), c);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (! (collider.gameObject.tag == "Bullet") ) { isActivate = true; }
    }

    private void OnTriggerExit(Collider collider)
    {
        isActivate = false;
    }

    public bool getIsActivate()
    {
        return isActivate;
    } 
}
