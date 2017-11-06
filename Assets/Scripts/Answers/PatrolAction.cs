using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class PatrolAction : AIBehaviour
{
    private int waypoint_number = 0;

    public Waypoint waypoints;
    public float patrol_point_timer = 0;
    public int patrol_point_time;
    public PlayerWithinPurseRange player_within_pursue_range;

    // Use this for initialization
    void Start () {
        waypoints = FindObjectOfType<Waypoint>();
        patrol_point_time = Random.Range(1, 5);
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if(player_within_pursue_range.Execute(agent) == BehaviourResult.Failure)
        {
            patrol_point_timer -= Time.deltaTime;

            if (patrol_point_timer <= 0)
            {
                waypoint_number = Random.Range(1, 7);
                patrol_point_timer = patrol_point_time;
            }

            agent.destination = waypoints.way_points_list[waypoint_number].transform.position;
        }

        return BehaviourResult.Success;
    }
}
