using UnityEngine.AI;

public class Sequence : Composite {

    public override BehaviourResult Execute(NavMeshAgent agent) {
        foreach (AIBehaviour child in child_behaviours) {
            if (child.Execute(agent) == BehaviourResult.Failure)
                return BehaviourResult.Failure; // of the operation fails, return failed
        }

        return BehaviourResult.Success;
    }
}