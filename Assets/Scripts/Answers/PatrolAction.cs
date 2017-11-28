using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

//the agent has access to a list of waypoints, if the player within purse range question
//returns a result of failure the agent will pick a random integer and set and its destination
//to be the waypoint that waypoint in the list 

public class PatrolAction : AIBehaviour
{
    private int waypoint_number = 0;

    public Waypoint waypoints;
    public float patrol_point_timer = 0;
    public int patrol_point_time;
    public PlayerWithinPurseRange player_within_pursue_range;
    public float speed = 5.0f;

    // Use this for initialization
    void Start () {
        waypoints = FindObjectOfType<Waypoint>();
        patrol_point_time = Random.Range(2, 3);
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if(player_within_pursue_range.Execute(agent) == BehaviourResult.Failure)
        {
            patrol_point_timer -= Time.deltaTime;

            agent.speed = speed;

            if (patrol_point_timer <= 0)
            {
                waypoint_number = Random.Range(1, 57);
                patrol_point_timer = patrol_point_time;
            }

            agent.destination = waypoints.way_points_list[waypoint_number].transform.position;
        }

        return BehaviourResult.Success;
    }
}
