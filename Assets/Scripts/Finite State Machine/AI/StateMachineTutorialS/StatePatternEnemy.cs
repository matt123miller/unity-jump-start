using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour {

    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public float sightRange = 20f;
    public Transform[] waypoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, 0.5f, 0);
    public MeshRenderer meshRendererFlag;


    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;


    private void Awake()
    {
        chaseTarget = new ChaseState(this);
        alertState = new AlertState(this);
        patrolState = new PatrolState(this);

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Use this for initialization
    void Start () {

        currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update () {

        currentState.UpdateState();
	}

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
