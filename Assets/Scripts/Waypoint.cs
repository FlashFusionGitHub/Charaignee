using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoint : MonoBehaviour {

    //Colour of way point gizmo
    public Color way_point_colour = Color.white;
    //List containing the waypoints
    public List<Transform> way_points_list = new List<Transform>();
    //array of transforms
    Transform[] waypoint_array;

    void OnDrawGizmos()
    {
        Gizmos.color = way_point_colour;

        waypoint_array = GetComponentsInChildren<Transform>();

        way_points_list.Clear();

        foreach(Transform waypoint in waypoint_array)
        {
            if(waypoint != this.transform)
            {
                way_points_list.Add(waypoint);
            }
        }

        for (int i = 0; i < way_points_list.Count; i++)
        {
            Gizmos.DrawSphere(way_points_list[i].transform.position, 0.2f);
        }
    }
}
