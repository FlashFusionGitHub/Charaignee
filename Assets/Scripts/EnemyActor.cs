using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

//A Stupid "AI"
public class EnemyActor : MonoBehaviour
{
    private NavMeshAgent enemy_navmesh;
    private HealthBar playerHealth;
    private FirstPersonController player;
    private int waypoint_number = 0;

    public NavMeshAgent agent;

    public Waypoint waypoints;
    public float patrol_point_timer = 0;
    public int patrol_point_time = 0;

    // Use this for initialization
    void Start ()
    {
        enemy_navmesh = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<FirstPersonController>();
        waypoints = FindObjectOfType<Waypoint>();
        patrol_point_time = Random.Range(1, 5);
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        enemy_navmesh.destination = player.transform.position;

        if (Vector3.Distance(enemy_navmesh.transform.position, player.transform.position) < 1.5f)
        {
            Idle();
        }

        if (Vector3.Distance(enemy_navmesh.transform.position, player.transform.position) > 10)
        {
            Patrol();
        }

    }

    void Idle()
    {
        enemy_navmesh.velocity = new Vector3(0, 0, 0);
    }

    void Patrol()
    {
        patrol_point_timer -= Time.deltaTime;
        
        if(patrol_point_timer <= 0)
        {
            waypoint_number = Random.Range(1, 90);
            patrol_point_timer = patrol_point_time;
        }

        enemy_navmesh.destination = waypoints.way_points_list[waypoint_number].transform.position;
    }
}
