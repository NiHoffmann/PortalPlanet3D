using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public GameObject rayGun;
    [SerializeField] GameObject routeGameObject;
    private Vector3[] route = null;
    public float viewDistance;

    private Vector3 nextPoint;
    private bool isArrived;

    private GameObject target;                  
    private int childCount;

    private float speed = 5f;
    private float modelRotSpeed = 7f;
    private float gunRotSpeed = 3f;

    private float deathCounter = 0f;
    private float deathInc = 2f;
    public float maxDeathCounter = 5f;
    private Boolean deathCounterStarted = false;

    private Boolean isDead = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            Vector3 vel = collision.gameObject.transform.GetComponent<Rigidbody>().velocity;
            if (Mathf.Abs(vel.x + vel.y + vel.z) > 2f)
            {
                isDead = true;
                gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            }  
        }
        Debug.Log(collision.gameObject.tag == "Throwable");
        Debug.Log(collision.gameObject.transform.GetComponent<Rigidbody>().velocity);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        initRouteWithGameObject();
    }

    // Initialize route with a GameObject with children GameObjects
    private void initRouteWithGameObject()
    {
        if ((routeGameObject != null) && (routeGameObject.transform.childCount > 0))
        {
            route = new Vector3[routeGameObject.transform.childCount];
            for (int i = 0; i < routeGameObject.transform.childCount; i++)
            {
                route[i] = routeGameObject.transform.GetChild(i).position;
            }
        }
        isArrived = true;
        childCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            RotateRayToTarget();
            if (IsVisable())
            {
                // Player is Visable
                RotateModelToTarget();
            }
            else if ((route != null) && isArrived)
            {
                // Update next point to next route point
                updateChildCount();
                nextPoint = route[childCount];
                isArrived = false;
            }
            else if (!isArrived)
            {
                // Go to next point
                MoveToPoint();
            }

            if (!deathCounterStarted)
            {
                if (deathCounter - (deathInc * Time.deltaTime) >= 0f)
                {
                    deathCounter -= deathInc * Time.deltaTime;
                }
                else if (deathCounter > 0f)
                {
                    deathCounter = 0f;
                }
            }
        }
    }

    // Update ray gun rotation to player position
    private void RotateRayToTarget()
    {
        Vector3 lookPlayer = target.transform.position - transform.position;
        rayGun.transform.rotation = Quaternion.LookRotation(lookPlayer);
    }

    // Check if player is visable
    private bool IsVisable()
    {
        Vector3 rayGunPosition = rayGun.transform.position;
        Vector3 forwardDirection = rayGun.transform.forward;

        Ray ray = new Ray(rayGunPosition, forwardDirection);
        RaycastHit rayHit;

        bool isHit = Physics.Raycast(ray, out rayHit, viewDistance);

        if (isHit)
        {
            GameObject hitObject = rayHit.transform.gameObject;
            return hitObject == target;
        } else
        {
            deathCounterStarted = false;
        }
        return false;
    }

    // Rotate enemy to player
    private void RotateModelToTarget()
    {
        Vector3 lookPlayer = target.transform.position - transform.position;
        lookPlayer.y = 0;
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPlayer), Time.deltaTime * modelRotSpeed);
        transform.rotation = rot;

        if (Math.Abs(transform.rotation.eulerAngles.y - rot.eulerAngles.y) < 0.01)
        {
            deathCounterStarted = true;
            if (deathCounter > maxDeathCounter)
            {
                Debug.Log("youre dead");
            }else
            {
                deathCounter += deathInc * Time.deltaTime;
            }
        }
    }

    // Move to the next point
    private void MoveToPoint()
    {
        Vector3 lookPlayer = nextPoint - transform.position;
        lookPlayer.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPlayer), Time.deltaTime * modelRotSpeed);

        if (Vector3.Distance(Quaternion.LookRotation(lookPlayer).eulerAngles, transform.rotation.eulerAngles) < 10)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        Vector3 newPos = transform.position;
        float xTol = 1.0f;
        float zTol = 1.0f;
        if ((newPos.x < nextPoint.x + xTol) && (newPos.x > nextPoint.x - xTol) &&
            (newPos.z < nextPoint.z + zTol) && (newPos.z > nextPoint.z - zTol))
        {
            isArrived = true;
        }
    }

    // Increase childCount
    private void updateChildCount()
    {
        if (childCount + 1 >= route.Length)
        {
            childCount = 0;
        }
        else
        {
            childCount++;
        }
    }

    //Set the next point the enemy should move to
    public void setNextPoint(Vector3 nextPoint)
    {
        this.nextPoint = nextPoint;
        isArrived = false;
    }

    //Set route with a Vector3 array
    public void setRoute(Vector3[] input)
    {
        route = input;
        isArrived = true;
        childCount = 0;
    }

    //Set route with a GameObject with children GameObjects
    public void setRoute(GameObject input)
    {
        routeGameObject = input;
        initRouteWithGameObject();
    }
}
