using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1.2f;

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f){

            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length){
                currentWaypointIndex = 0;
            }
        }
        //Moving platform directly by its position frame by frame. Reusable code for more waypoints since they belong to an array.
        //Using Time.deltaTime to make behaviour independent from frame rate.
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
