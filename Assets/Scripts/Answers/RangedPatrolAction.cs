using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class RangedPatrolAction : AIBehaviour
{

    private int waypoint_number = 0;

    private Waypoint waypoints;
    public float patrol_point_timer = 0;
    public int patrol_point_time;
    public float speed = 10.0f;

    public PlayerWithinRangedPursePange player_within_ranged_purse_range;

    // Use this for initialization
    void Start () {
        waypoints = FindObjectOfType<Waypoint>();
        patrol_point_time = Random.Range(1, 5);
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if (player_within_ranged_purse_range.Execute(agent) == BehaviourResult.Failure)
        {
            agent.speed = speed;

            patrol_point_timer -= Time.deltaTime;

            if (patrol_point_timer <= 0)
            {
                waypoint_number = Random.Range(1, 90);
                patrol_point_timer = patrol_point_time;
            }

            agent.destination = waypoints.way_points_list[waypoint_number].transform.position;
        }

        return BehaviourResult.Success;
    }
}
