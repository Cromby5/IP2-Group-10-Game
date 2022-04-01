using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
 
    NavMeshAgent agent;

    // Point to go to when not actively tracking the player
    public Vector3 roamPath;
    public float roamDistance;
    private bool hasRoamPath;

    // Start is called before the first frame update
    void Start()
    {
        hasRoamPath = false;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Roam();
    }

    void Roam()
    {
        // If the enemy does not have a destination to roam to get a random point inside a sphere and check with the nav mesh that it is an area the enemy can get to
        if (!hasRoamPath)
        {
            getRoamPath();
        }
        else
        {
            // Go towards the destination
            agent.SetDestination(roamPath);
            Vector3 distanceToDestination = transform.position - roamPath;
            // If our distance to the destination is less than x set roam path to false to create a new point for the enemy to go towards
            if (distanceToDestination.magnitude < 1f)
            {
                hasRoamPath = false;
            }
            if (distanceToDestination.magnitude == float.PositiveInfinity)
            {
                hasRoamPath = false;
            }
        }
    }
    void getRoamPath()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * roamDistance;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, roamDistance, NavMesh.AllAreas); // Finds the nearest point on the navmesh specificed with the range
        roamPath = hit.position;
        hasRoamPath = true;
    }
}
