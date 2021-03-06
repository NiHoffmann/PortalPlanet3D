using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class FinalBossScript : MonoBehaviour
{
    [SerializeField] GameObject[] cones;
    [SerializeField] GameObject center;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    [SerializeField] GameObject referencePoint;
    [SerializeField] GameObject attack;
    [SerializeField] float attackVelocity = 15;
    [SerializeField] float maxHits = 1;
    [SerializeField] DialogLevel2 diaLev2;
    [SerializeField] Material hitMaterial;
    [SerializeField] Material normalMaterial;
    [SerializeField] MeshRenderer Head;

    Vector3 targetPos;
    public float attackTimer;
    float timePassed;
    float tol = 0.1f;
    public bool started = false;
    bool alive = true;
    public int hitCounter = 0;
    public bool angy = false;
    public float angyTimer = 0;
    float stationaryTimer = 7;
    float attackCooldown = 4.5f;

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            transform.LookAt(player.transform.position);
            return;
        }

        if (angy) {
            angyTimer += Time.deltaTime;
            if (angyTimer >= 2.5f) {
                Head.material = normalMaterial;
                angy = false;
                angyTimer = 0;
            }
        }

        attackTimer += Time.deltaTime;

        if (attackTimer > attackCooldown || (angy & attackTimer > 1))  {
            GameObject g =  Instantiate(attack, referencePoint.transform.position, Quaternion.identity);
            FInalBossAttack gfbt = g.GetComponent<FInalBossAttack>();
            gfbt.shoot(referencePoint.transform.position, player.transform.position, attackVelocity);
            attackTimer = 0;
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }

        if (targetPos == new Vector3(0,0,0) || timePassed >= stationaryTimer) { 
            newTargetPosition(Random.Range(0, (int)(cones.Length - 0.1f)));
            timePassed = 0;
        }

        if (Mathf.Abs(targetPos.x - transform.position.x)<tol && Mathf.Abs(targetPos.y - transform.position.y) < tol && Mathf.Abs(targetPos.z - transform.position.z) < tol)
        {
            timePassed += Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        transform.LookAt(player.transform.position);
        Vector3 rotAngle = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler( rotAngle.x, rotAngle.y, rotAngle.z);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (!alive) return;

        if (other.gameObject.CompareTag("Throwable")) {
            if (!angy)
            {
                angy = true;
                Head.material = hitMaterial;
                hitCounter++;
                speed += 5;
                stationaryTimer -= 2;
                attackVelocity += 5;
                attackCooldown -= 1;
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
                
            
            if (hitCounter >= maxHits) {
                alive = false;
                started = false;
                GetComponent<Rigidbody>().useGravity = true;
                diaLev2.incrementCounter();
            }
        }
    }

    private void newTargetPosition(int i) {
        targetPos = cones[i].transform.position;
        targetPos.y = 33;
    }
}
