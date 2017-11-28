using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

//the PlayerWithinRangedAttackRange question asks if the player is within a specified distance
//from the player, if the condition is true then the behaviour/question return a result of success
//otherwise it returns failure

public class PlayerWithinRangedAttackRange : AIBehaviour {

    public float range = 10.0f;

    private FirstPersonController player;

    void Start()
    {
        player = FindObjectOfType<FirstPersonController>();
    }

    public override AIBehaviour.BehaviourResult Execute(NavMeshAgent agent)
    {
        if (Vector3.Distance(player.transform.position, agent.transform.position) <= range)
            return BehaviourResult.Success;
        else
            return BehaviourResult.Failure;
    }
}
