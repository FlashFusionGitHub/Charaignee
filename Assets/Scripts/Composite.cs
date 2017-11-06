using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Composite : AIBehaviour
{

    public List<AIBehaviour> child_behaviours = new List<AIBehaviour>();

    public abstract override BehaviourResult Execute(NavMeshAgent agent);
}
