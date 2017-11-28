using System.Collections.Generic;
using UnityEngine.AI;

public abstract class Composite : AIBehaviour
{

    public List<AIBehaviour> child_behaviours = new List<AIBehaviour>(); // instantiates the behavioour list

    public abstract override BehaviourResult Execute(NavMeshAgent agent);
}
