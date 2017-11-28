using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sequence : Composite {

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        foreach (AIBehaviour child in child_behaviours)
        {
            if (child.Execute(agent) == BehaviourResult.Failure)
                return BehaviourResult.Failure;
        }

        return BehaviourResult.Success;
    }
}
