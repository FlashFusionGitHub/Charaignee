using UnityEngine;
using UnityEngine.AI;

public abstract class AIBehaviour : MonoBehaviour{

    public enum BehaviourResult {
        Success = 0, Failure
    };

    public abstract BehaviourResult Execute(NavMeshAgent agent);
}
