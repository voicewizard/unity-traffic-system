using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public int carsNumber;
    public Transform carPrefab;
    public Transform waypointsParent;

    private List<Transform> waypoints;
    private Transform spawnPoint;


    void Start()
    {
        waypoints = new List<Transform>();
        for (int i = 0; i < waypointsParent.childCount; i++)
        {
            waypoints.Add(waypointsParent.GetChild(i));
        }
        for (int i = 0; i < carsNumber; i++)
        {
            var rand = UnityEngine.Random.Range(0, waypoints.Count);
            spawnPoint = waypoints[rand];
            var car = Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);
            car.parent = transform;
            var cn = car.GetComponent<CarNavigation>();
            cn.waypoint = spawnPoint.GetComponent<Waypoint>();
            cn.speed = UnityEngine.Random.Range(cn.speed - 10f, cn.speed);
            waypoints.Remove(spawnPoint);
        }
    }
}
