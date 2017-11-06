using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class PurseAction : AIBehaviour
{
    public PlayerWithinPurseRange player_within_pursue_range;

    private FirstPersonController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<FirstPersonController>();
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if(player_within_pursue_range.Execute(agent) == BehaviourResult.Success)
        {
            agent.destination = player.transform.position;
        }

        return BehaviourResult.Success;
    }
}
