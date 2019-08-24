using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speedRotation;
    public float takeSpeed;
    public float takeRotation;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speedRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") { takePowerUp(); }
    }

    private void takePowerUp()
    {
        Destroy(gameObject, 0.25f);
        rb.AddForce(transform.up * takeSpeed);
        speedRotation = takeRotation;
    }
}
