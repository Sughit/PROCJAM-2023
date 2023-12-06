using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovingChef : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    public Animator anim;
    public GameObject particule;
    public GameObject mersSFX;

    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
        if(agent.velocity.magnitude <1f)
        {
            anim.SetBool("mers", false);
            particule.SetActive(false);
            mersSFX.SetActive(false);
        }    
        else
        {
            anim.SetBool("mers", true);
            particule.SetActive(true);
            mersSFX.SetActive(true);
        }    

    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        //variabile din navMesh
        agent.stoppingDistance = newTarget.radius * .6f;
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        //variabile din navMesh
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
