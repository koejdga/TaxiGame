using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    NpcController controller;
    public Waypoint currentWaypoint;

    int direction;

    private void Awake()
    {
        controller = GetComponent<NpcController>();
    }

    private void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0,2));
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    { 
        if (controller.reachedDestination)
        {
            bool shouldBranch = false;

            if (currentWaypoint != null)
            {
                if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
                {
                    shouldBranch = Random.Range(0, 1) <= currentWaypoint.branchRatio ? true : false;
                }

                if (shouldBranch)
                {
                    currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
                }
                else
                {
                    if (direction == 0)
                    {
                        if (currentWaypoint.nextWaypoint != null)
                        {
                            currentWaypoint = currentWaypoint.nextWaypoint;
                        }
                        else
                        {
                            currentWaypoint = currentWaypoint.nextWaypoint;
                            direction = 1;
                        }

                    }
                    else if (direction == 1)
                    {
                        if (currentWaypoint.previousWaypoint != null)
                        {
                            currentWaypoint = currentWaypoint.previousWaypoint;
                        }
                        else
                        {
                            currentWaypoint = currentWaypoint.nextWaypoint;
                            direction = 0;
                        }
                    }
                }

                controller.SetDestination(currentWaypoint.GetPosition());
            }
            
        }
    }

}
