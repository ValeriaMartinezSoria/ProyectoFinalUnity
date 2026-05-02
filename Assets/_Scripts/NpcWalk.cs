using UnityEngine;
using UnityEngine.AI;

public class NpcWalk : NpcBase
{
    protected NavMeshAgent agent;

    private float radiusMove = 10f;
    private float awaitTimeMin = 2f;
    private float awaitTimeMax = 5f;
    private float awaitTime = 0f;
    private bool wait = false;

    protected override void Start()
    {
        base.Start();  
        agent = GetComponent<NavMeshAgent>();
        StartMoving();
    }

    protected virtual void Update()
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

    protected void StartMoving()
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

    public override void OnInteract()
    {
        Debug.Log(nombreNPC + " no responde a interacciones");
    }
}