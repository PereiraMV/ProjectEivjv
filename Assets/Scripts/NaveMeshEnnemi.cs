using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaveMeshEnnemi : MonoBehaviour
{
    private NavMeshAgent navAgent;

    public GameObject player;

    
    private Color type;
    private Color[] bulletColor = { Color.blue, Color.yellow, Color.magenta };
    private bool isDead = false;
    private int countWrongPresent = 0;
    private bool enraged = false;
    private Renderer rend;
    public GameObject bullet;
    private float nextFire = 5;
    private float firerate=5 ;
    private string[] routine = { "IAennemi","IAennemi2", "IAennemi3" };

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        navAgent = GetComponent<NavMeshAgent>();

        //give a routine, IA behavior
        int routineid = Random.Range(0, 3);

        StartCoroutine(routine[routineid]);

        //give a color to the agent
        int rd = Random.Range(0, 3);
        //give him a color
        type = bulletColor[rd];
        rend = GetComponent<Renderer>();
        

        Renderer hat = transform.GetChild(0).GetComponent<Renderer>();
        hat.materials[1].SetColor(Shader.PropertyToID("_Color"), type);


    }

    void FixedUpdate()
    {
        if (!isDead)    GetComponent<Rigidbody>().transform.LookAt(player.transform.position);
        if (EnemyClear.killGoal == EnemyClear.getKillCount())
        {
            isDead = true;
            navAgent.isStopped = true;
            navAgent.enabled = false;
            rend.material.SetColor(Shader.PropertyToID("_Color"), Color.green);

            Destroy(gameObject, 2.0f);
        }
    }


    IEnumerator IAennemi()
    {
        while (!isDead)
        {

            navAgent.SetDestination(player.transform.position);
            
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator IAennemi2()
    {
        int delayBeforeAttack=0;

        while (!isDead)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hit)){
                if (hit.collider.tag !="obstacle" && hit.collider.tag != "Ennemi")
                {
                    
                    //Debug.DrawLine(transform.position+transform.forward, player.transform.position,Color.green);
                    GetComponent<Rigidbody>().AddForce((player.transform.position - navAgent.transform.position).normalized*800*navAgent.speed);
                    delayBeforeAttack = 5;
                }
                else
                {
                    delayBeforeAttack = 1;
                    //Debug.DrawLine(transform.position + transform.forward, player.transform.position,Color.red);
                }
            }


            yield return new WaitForSeconds(delayBeforeAttack);
        }

    }


    IEnumerator IAennemi3()
    {
        while (!isDead)
        {
            
            float distance = Vector3.Distance(transform.position, player.transform.position);
            RaycastHit hit;
            if (Time.time > nextFire) 
            {

                if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hit))
                {
                    if (hit.collider.tag != "obstacle" && hit.collider.tag != "Ennemi")
                    {
                        nextFire = Time.time + firerate;
                        GameObject tempBullet = Instantiate(bullet, transform.position+transform.forward, transform.rotation);
                    }
                    else
                    {
                        nextFire = Time.time + 1;
                    }
                }

            }
            if ( distance< 18 && distance> 8)
            {
                navAgent.SetDestination(transform.right*15);
            }
            else if (distance > 15 ) {

                navAgent.SetDestination(player.transform.position);
            }
            else
            {

                navAgent.SetDestination(transform.position-transform.forward*5);

            }
            

            yield return new WaitForSeconds(0.2f);
        }
    }


    public bool getisDead()
    {
        return isDead;
    }

    public void BecomeEnraged()
    {
        if (countWrongPresent == 1)
        {
            rend.material.SetColor(Shader.PropertyToID("_Color"), Color.gray);
            navAgent.speed += 3;
            navAgent.acceleration += 3;
        }
        if (countWrongPresent == 5)
        {

            rend.material.SetColor(Shader.PropertyToID("_Color"), Color.black);
            navAgent.speed += 3;
            navAgent.acceleration += 3;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((collision.gameObject).GetComponent<Mover>().getType() ==type && !isDead  )
            {
                EnemyClear.countKill();
                isDead= true;
                navAgent.isStopped = true;
                navAgent.enabled = false;
                rend.material.SetColor(Shader.PropertyToID("_Color"), Color.green);

                Destroy(collision.gameObject);
                Destroy(gameObject, 2.0f);
                EnnemiGenerator.countEnnemies--;

            }
            else if (!isDead)
            {
                countWrongPresent += 1;
                BecomeEnraged();
            }
        }

        


    }
}

