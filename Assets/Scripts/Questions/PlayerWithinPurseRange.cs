using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

//the PlayerWithinPurseRange question asks if the player is within a specified distance
//from the player, if the condition is true then the behaviour/question return a result of success
//otherwise it returns failure

public class PlayerWithinPurseRange : AIBehaviour {

    public float range = 20.0f;

    private FirstPersonController player;

    void Start()
    {
        player = FindObjectOfType<FirstPersonController>();
    }

    public override AIBehaviour.BehaviourResult Execute(NavMeshAgent agent)
    {
        if (Vector3.Distance(agent.transform.position, player.transform.position) < range)
            return AIBehaviour.BehaviourResult.Success;
        else
            return AIBehaviour.BehaviourResult.Failure;

    }
}
