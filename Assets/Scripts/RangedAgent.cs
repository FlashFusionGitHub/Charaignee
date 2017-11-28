using UnityEngine;
using UnityEngine.AI;

public class RangedAgent : MonoBehaviour {

    public float health = 100;
    public Animator rangeEnemyAnimator;

    public NavMeshAgent agent;

    public RangedPatrolAction patrol;
    public RangedPurseAction purse;
    public RangedAttackAction attack;
    public PlayerWithinRangedPursePange player_within_pursue_range;
    public PlayerWithinRangedAttackRange player_within_attack_range;

    public Selector attackRange;
    public Sequence attackRange2;

    private AIBehaviour aibehaviour;
    private AIBehaviour aibehaviour2;
    private AIBehaviour aibehaviour3;

    // Use this for initialization
    void Start () {
        aibehaviour = patrol;
        aibehaviour2 = purse;
        aibehaviour3 = attack;

        attackRange.child_behaviours.Add(player_within_attack_range);
        attackRange.child_behaviours.Add(player_within_pursue_range);

        attackRange2.child_behaviours.Add(player_within_attack_range);
        attackRange2.child_behaviours.Add(player_within_pursue_range);
    }

    // Update is called once per frame
    void Update() {
        if (attackRange.Execute(agent) == AIBehaviour.BehaviourResult.Failure) {
            aibehaviour.Execute(agent);
            rangeEnemyAnimator.SetBool("isWalking", true);
            rangeEnemyAnimator.SetBool("isShooting", false);
        }

        if (attackRange.Execute(agent) == AIBehaviour.BehaviourResult.Success) {
            aibehaviour2.Execute(agent);
            rangeEnemyAnimator.SetBool("isWalking", false);
        }

        if (attackRange2.Execute(agent) == AIBehaviour.BehaviourResult.Success) {
            aibehaviour3.Execute(agent);
            rangeEnemyAnimator.SetBool("isShooting", true);
        }

        if (health <= 0) {
            Destroy(agent.gameObject);
        }
    }

    public void agentTakeDamage(float playerAttack) {
        health -= playerAttack;
        Debug.Log(health);
    }
}
