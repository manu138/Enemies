using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearAIController : MonoBehaviour
{
    public float sightRange = 20f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public NavMeshAgentController navMeshAgent;
    [HideInInspector]
    public Transform chaseTarget;

    [SerializeField]
    private float force;
    public Transform shotSpawn;

    [SerializeField]
    private Rigidbody bullet;
    public bool isOn = false;


    private BearStateBase currentState;
    private Dictionary<BearState, BearStateBase> states;

    private void Awake()
    {
        states = new Dictionary<BearState, BearStateBase>();
        states.Add(BearState.Patrol, new PatrolState(this));
        states.Add(BearState.Alert, new AlertState(this));
        states.Add(BearState.Chase, new ChaseState(this));
        states.Add(BearState.Attack, new AttackState(this));
        currentState = states[BearState.Patrol];
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void MakeTransition(BearState state)
    {
        Debug.Log(state);
        currentState = states[state];
        currentState.StartState();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isOn = true;
        }
        currentState.OnTriggerEnter(other);

    }

    public void Disparar()
    {
        if (isOn == true)
        {
            Rigidbody shot = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

            shot.velocity = transform.forward * force;
            isOn = false;
        }

    }
}
