﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

//The purse action sets the agents destination the the players current position
//if the player within purse ranged question returns success.
//when this behaviour/action completes it returns a success result 

public class PurseAction : AIBehaviour
{
    public PlayerWithinPurseRange player_within_pursue_range;

    private FirstPersonController player;

    public float speed = 5.0f;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<FirstPersonController>();
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if(player_within_pursue_range.Execute(agent) == BehaviourResult.Success)
        {
            agent.speed = speed;
            agent.destination = player.transform.position;
        }

        return BehaviourResult.Success;
    }
}
