using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointsIndex = 0;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointsIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointsIndex++;
            if(currentWaypointsIndex >= waypoints.Length)
            {
                currentWaypointsIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointsIndex].transform.position, Time.deltaTime * speed);

    }
}
