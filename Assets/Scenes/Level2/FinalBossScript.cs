using System.Collections;
using System.Collections.Generic;
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
    Vector3 targetPos;
    public float attackTimer;
    float timePassed;
    float tol = 0.1f;

    int movingTowards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        attackTimer += Time.deltaTime;
        if (attackTimer > 5) {
            GameObject g =  Instantiate(attack, referencePoint.transform.position, Quaternion.identity);
            FInalBossAttack gfbt = g.GetComponent<FInalBossAttack>();
            gfbt.shoot(referencePoint.transform.position, player.transform.position, attackVelocity);
            attackTimer = 0;
        }

        if (targetPos == new Vector3(0,0,0) || timePassed >= 5) { 
            newTargetPosition(Random.Range(0, (int)(cones.Length - 0.1f)));
        }

        if (Mathf.Abs(targetPos.x - transform.position.x)<tol && Mathf.Abs(targetPos.y - transform.position.y) < tol && Mathf.Abs(targetPos.z - transform.position.z) < tol)
        {
            timePassed += Time.deltaTime;
        }
        else
        {
            timePassed = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        transform.LookAt(player.transform.position);
        Vector3 rotAngle = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler( rotAngle.x, rotAngle.y, rotAngle.z);
    }

    private void newTargetPosition(int i) {
        movingTowards = i;
        targetPos = cones[i].transform.position;
        targetPos.y = 40;
    }
}
