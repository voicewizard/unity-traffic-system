using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class CarNavigation : MonoBehaviour
{
    public float speed = 10f;
    public float distance = 1f;
    private float curSpeed;

    private Transform target;
    public Waypoint waypoint;
    private Waypoint prevWaypoint;
    public Transform RayShooter;
    //private Quaternion newRotation;
    //private bool onIntersection;
    //private bool canUpdate = true;

    //private float timer = 0;
    //private float timerMax = 0;

    void Start()
    {
        //canUpdate = true;
        curSpeed = speed;
        target = waypoint.transform;
        LookAt();
    }

    void Update()
    {
        //if (canUpdate)
        //{
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * curSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.5f)
            {
                SetNextWaypoint();
            }
        CheckDistance();
        TrafficLightsCheck();
        //} 
    }

    void TrafficLightsCheck()
    {
        if (prevWaypoint.trafficLight != null)
        {
            if (!prevWaypoint.trafficLight.canGo) curSpeed = 0f;
        }
    }

    void SetNextWaypoint()
    {
        if (waypoint.possibleNextWaypoints.Count == 1)
        {
            /*if (onIntersection && waypoint.intersection == null)
            {
                prevWaypoint.intersection.queueOfCarIDs.Dequeue();
                Debug.Log("Left queue");
                onIntersection = false;
            }*/
            prevWaypoint = waypoint;
            waypoint = waypoint.possibleNextWaypoints[0];
            //curSpeed = speed;
        }
        else
        {
            //curSpeed = 0f;
            //onIntersection = true;
            //waypoint.intersection.queueOfCarIDs.Enqueue(gameObject.GetInstanceID());
            //Debug.Log("Entered queue, " + gameObject.GetInstanceID().ToString());
            //перевірити чергу, якщо перший це я, то міняю вейпоінт і швидкість, якщо ні, то чекаю 1 секунду і знов перевіряю
            //while (gameObject.GetInstanceID() != waypoint.intersection.queueOfCarIDs.Peek())
            //canUpdate = false;
            //StartCoroutine(Wait());
            //{ if (!Waited(1)) return; }
            //Debug.Log(gameObject.GetInstanceID() != waypoint.intersection.queueOfCarIDs.Peek());
            prevWaypoint = waypoint;
            waypoint = waypoint.possibleNextWaypoints[UnityEngine.Random.Range(0, waypoint.possibleNextWaypoints.Count)];
            //curSpeed = speed; 
        }
        target = waypoint.transform;
        LookAt();
    }

    void LookAt()
    {
        //newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
        //newRotation.x = 0f;
        //newRotation.z = 0f;
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 1000);
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
    }

    void CheckDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(RayShooter.transform.position, RayShooter.transform.forward, out hit, distance))
        //if (Physics.SphereCast(RayShooter.transform.position, 5f, RayShooter.transform.forward, out hit, distance))
        {
            if (hit.transform.name == "Car(Clone)") curSpeed = 0f;
            else curSpeed = speed;
        }
        else curSpeed = speed;
    }

    /*IEnumerator Wait()
    {
        canUpdate = false;
        yield return new WaitForSeconds(1);
        canUpdate = true;
    }

    private bool Waited(float seconds)
    {
        timerMax = seconds;
        timer += Time.deltaTime;
        if (timer >= timerMax) return true;

        return false;
    }*/
}
