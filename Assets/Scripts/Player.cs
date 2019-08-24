using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    private Camera cam;
    public Image colorSquare;
    public Transform bulletOrigin;
    public GameObject bullet;
    private Rigidbody mb;
   
    public float fireRate;
    private float nextFire=0;
    public int speed = 10;

    private Color[] bulletColor = { Color.blue, Color.yellow, Color.magenta };

    private int bulletTypeUsed=0;
    // Start is called before the first frame update
    void Start()
    {
        mb = GetComponent<Rigidbody>();
        cam = Camera.main;
        colorSquare.color = Color.blue;

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject  tempBullet=Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation) ;
            tempBullet.GetComponent<Mover>().iniType(this.bulletColor[bulletTypeUsed]) ;


        }
        if (Input.GetMouseButtonDown(1))
        {
            if (bulletTypeUsed < 2)
            {
                bulletTypeUsed += 1;
                
            }
            else
            {
                bulletTypeUsed = 0;

            }
            colorSquare.color = bulletColor[bulletTypeUsed];
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mb.velocity = Vector3.zero;
        // Handle the movement of the player
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        mb.transform.Translate(movement * Time.fixedDeltaTime *speed, Space.World);

        
        //Handle the rotation of the player with mouse position

        Vector3 point=new Vector3();
        Vector3 mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);
        Plane ground = new Plane(Vector3.up,Vector3.zero);

        float rayD;
        //return True si le raycast rencontre le plan ground
        if (ground.Raycast(ray,out rayD))
        {
           point = ray.GetPoint(rayD)+new Vector3(0,1,0);
        }

        mb.transform.LookAt(point);

        //Debug.DrawLine(mb.transform.position, point);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp") { fireRate /= 1.5f; }
    }
    
}
