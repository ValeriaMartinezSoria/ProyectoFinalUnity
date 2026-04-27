using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    public float radiusMove = 10f;       
    public float awaitTimeMin = 2f;        
    public float awaitTimeMax = 5f;        

    public Animator animator;

    private NavMeshAgent agent;
    private float awaitTime = 0f;
    private bool wait = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (animator == null)
            animator = GetComponent<Animator>();

        StartMoving();
    }

    void Update()
    {
        if (animator != null)
            animator.SetFloat("Speed", agent.velocity.magnitude);

        if (wait)
        {
            awaitTime -= Time.deltaTime;
            if (awaitTime <= 0f)
            {
                wait = false;
                StartMoving();
            }
            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            wait = true;
            awaitTime = Random.Range(awaitTimeMin, awaitTimeMax);
        }
    }

    void StartMoving()
    {
        Vector3 puntoAleatorio = ObtenerPuntoAleatorio(transform.position, radiusMove);
        agent.SetDestination(puntoAleatorio);
    }

    Vector3 ObtenerPuntoAleatorio(Vector3 centro, float radio)
    {
        Vector3 direccionAleatoria = Random.insideUnitSphere * radio;
        direccionAleatoria += centro;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(direccionAleatoria, out hit, radio, NavMesh.AllAreas))
            return hit.position;

        return transform.position;
    }
}
