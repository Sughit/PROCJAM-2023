using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(MovingChef))]
public class ControllingChef : MonoBehaviour
{
    public Interactable focus;
    // public static Transform focusGO;
    public LayerMask movementMask;

    MovingChef movement;
    Camera cam;

    void Start()
    {
        cam=Camera.main;
        movement=GetComponent<MovingChef>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, /*range*/100))
            {
                //Check if we hit an interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                Transform interactableGO = hit.collider.GetComponent<Transform>();
                //If we did set it as our focus
                if(interactable != null)
                {
                    SetFocus(interactable/*, interactableGO*/);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus/*, Transform newFocusGO*/)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
            //focusGO = newFocusGO;
            movement.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();

        focus = null;
        //focusGO = null;
        movement.StopFollowingTarget();
    }
}
