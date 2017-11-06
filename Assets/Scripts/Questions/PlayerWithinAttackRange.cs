using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

public class PlayerWithinAttackRange : AIBehaviour
{
    public float range = 2.0f;

    private FirstPersonController player;

    void Start()
    {
        player = FindObjectOfType<FirstPersonController>();
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if (Vector3.Distance(agent.transform.position, player.transform.position) < range)
            return BehaviourResult.Success;
       
        return BehaviourResult.Failure;
    }
}
