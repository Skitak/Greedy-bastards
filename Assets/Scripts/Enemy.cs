using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : BaseEntity {

    public GameObject loot;
    NavMeshAgent navMeshAgent;
    public int lootValue = 1;
    public float searchFrequency;
    public float roamFrequency = 5f;
    public float searchRadius;
    public LayerMask searchMask;
    public int damages;
    public float attackRange;
    public bool showAttackRange;
    private GameObject target;
    private Vector3 roamTarget;
    private Timer searchTimer;
    private Timer roamTimer;
    private Collider myCollider;
    private bool isAttacking;
    private Timer attackTimer;
    private Timer attackCooldownTimer ;
    ArrayList playerInRange;
    enum EnemyStates {
        ROAM,CHASE,FLEE
    }
    private EnemyStates state = EnemyStates.ROAM;

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        if (showAttackRange)
            Gizmos.DrawSphere(transform.position, attackRange);

    }
    protected override void Start() {
        base.Start();
        searchTimer = new Timer(searchFrequency, LookForTarget);
        roamTimer = new Timer(roamFrequency, RoamAgain);
        navMeshAgent = GetComponent<NavMeshAgent>();
        myCollider = GetComponent<Collider>();
        attackTimer = new Timer(0.6f, AttackFinished);
        attackCooldownTimer = new Timer (0.6f, AttackCooldownFinished) ;
        LookForTarget();
    }
    private void Update() {
        if (IsDead())
            return;
        animator.SetFloat("OrientationY", orientation.y);
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        Vector3 destination;
        if (state == EnemyStates.FLEE)
            destination = GetFarAwayFromPlayers();
        else if (state == EnemyStates.CHASE){
            destination = target.transform.position;
            if (target.tag == "Player" && Vector3.Distance(destination, transform.position) < attackRange && !isAttacking )
                TryAttacking();
        }
        else
            destination = roamTarget;
        navMeshAgent.SetDestination(destination);
    }

    protected override void Die(){
        base.Die();
        navMeshAgent.SetDestination(transform.position);
        animator.SetBool("Dead", true);
        (Instantiate(loot, transform.position, Quaternion.identity) as GameObject).GetComponent<Loot>().value = lootValue;
        searchTimer.Pause();
        roamTimer.Pause();
        myCollider.enabled = false;
        // Destroy(this.gameObject);
    }
    void LookForTarget(){
        searchTimer.ResetPlay();
        if (isAttacking)
            return;
        target = null;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, searchRadius, searchMask);
        for (int i = 0; i < hitColliders.Length ; ++i){
            if (hitColliders[i].gameObject.tag == "LootBag"){
                target = hitColliders[i].gameObject;
                break;
            }
            if (target == null) 
                target = hitColliders[i].gameObject;
            if (Vector3.Distance(target.transform.position, this.transform.position) > 
                        Vector3.Distance(hitColliders[i].gameObject.transform.position, this.transform.position))
                target = hitColliders[i].gameObject;
        }
        if (target == null){
            if (state == EnemyStates.CHASE || roamTarget == Vector3.zero)
                RoamAgain();
            state = EnemyStates.ROAM;
        }
        else 
            state = EnemyStates.CHASE;
    }

    void RoamAgain(){
        roamTarget = new Vector3( Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)) + this.transform.position;
        roamTimer.ResetPlay();
    }

    protected override void LootBagGrabbed() {
        state = EnemyStates.FLEE;
        searchTimer.Pause();
    }

    public override void LootBagInRange(LootBag lootBag) {
        this.lootBag = lootBag;
        TryGrabBag();
    }
    protected Vector3 GetFarAwayFromPlayers() {
        Vector3 playerCenter = GameManager.GetCenterPointfromPlayers();
        Vector3 oppositeDirection = (transform.position- playerCenter ).normalized;
        oppositeDirection.y = 0;
        return oppositeDirection + transform.position;
    }

    void TryAttacking(){
        isAttacking = true;
        animator.SetTrigger("Attack");
        attackTimer.ResetPlay();
    }
    void AttackFinished() {
        if (Vector3.Distance(target.transform.position, transform.position) < attackRange)
            target.GetComponent<Character>().Health -= damages;
        attackCooldownTimer.ResetPlay();
    }   
    void AttackCooldownFinished() {
        isAttacking = false;
    }
    
}
