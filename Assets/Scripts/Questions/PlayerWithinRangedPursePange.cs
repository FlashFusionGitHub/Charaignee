using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerWithinRangedPursePange : AIBehaviour {

    private FirstPersonController player;

    public float range = 10.0f;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<FirstPersonController>();
	}

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if (Vector3.Distance(player.transform.position, agent.transform.position) <= range)
            return BehaviourResult.Success;
        else
            return BehaviourResult.Failure;
    }
}
