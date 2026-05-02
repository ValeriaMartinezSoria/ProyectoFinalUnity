using UnityEngine;

public class NpcTalk : NpcWalk
{
    private float radioDeteccionNPC = 3f;
    private float duracionConversacion = 5f;
    private float waitTimeAfterTalk = 5f;
    private float timeTalking = 0f;
    private float cooldownAfterTalk = 0f;
    private bool talking = false;
    

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (talking)
        {
            timeTalking -= Time.deltaTime;
            if (timeTalking <= 0f)
            {
                FinishTalking();
            }
            return;
        }

        if (cooldownAfterTalk > 0f)
        {
            cooldownAfterTalk -= Time.deltaTime;
        }

        base.Update();

        if (cooldownAfterTalk <= 0f)
        {
            LookNpc();
        }
    }

    void LookNpc()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioDeteccionNPC);
        foreach (Collider c in colliders)
        {
            if (c.gameObject == gameObject)
            {
                continue;
            }

            NpcTalk other = c.GetComponent<NpcTalk>();
            if (other != null && !other.IsTalking())
            {
                StartTalking(other);
                other.StartTalking(this);
                return;
            }
        }
    }

    public void StartTalking(NpcTalk anotherNpc)
    {
        talking = true;
        timeTalking = duracionConversacion;

        if (agent != null) agent.isStopped = true;

        Vector3 dir = anotherNpc.transform.position - transform.position;
        dir.y = 0f;
        if (dir.sqrMagnitude > 0.001f)
            transform.rotation = Quaternion.LookRotation(dir);

        if (animator != null)
        {
            animator.SetFloat("Speed", 0f);
            animator.SetBool("IsTalking", true);
        }

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        Debug.Log(nombreNPC + " conversa con " + anotherNpc.nombreNPC);
    }

    void FinishTalking()
    {
        talking = false;
        cooldownAfterTalk = waitTimeAfterTalk;

        if (agent != null)
        {
            agent.isStopped = false;
        }
        if (animator != null)
        {
            animator.SetBool("IsTalking", false);
        }
        if (audioSource != null)
        {
            audioSource.Stop();
        }


        StartMoving(); 
    }

    public bool IsTalking()
    {
        return talking;
    }

    public bool IsInCooldown()
    {
        return cooldownAfterTalk > 0f;
    }
}