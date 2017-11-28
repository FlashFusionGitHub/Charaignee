using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

//The ranged purse action sets the agents destination the the players current position
//if the player within ranged purse ranged question returns success.
//When this behaviour/action completes it returns a success result 

public class RangedPurseAction : AIBehaviour {

    public PlayerWithinRangedPursePange player_within_ranged_pursue_range;
    public float speed = 10.0f;

    private FirstPersonController player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<FirstPersonController>();
    }


    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if (player_within_ranged_pursue_range.Execute(agent) == BehaviourResult.Success)
        {
            agent.speed = speed;

            agent.destination = player.transform.position;
        }

        return BehaviourResult.Success;
    }
}
