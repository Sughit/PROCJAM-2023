using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    [HideInInspector]
    public bool isFocus;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        //a fost facuta ca sa dai overwrite
    }   

    void Update()
    {
        if(isFocus  && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius && !Extinctor.luatExt && !Produce.extinguishing)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
