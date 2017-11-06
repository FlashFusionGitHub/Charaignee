using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

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
