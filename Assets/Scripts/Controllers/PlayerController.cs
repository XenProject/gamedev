using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interactable focus;

    private Camera cam;
    private PlayerMotor motor;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(LayerMask.LayerToName(hit.transform.gameObject.layer) == "Ground")
                {
                    motor.MoveToPoint(hit.point);
                    RemoveFocus();
                }
                else
                {
                    Interactable interactable = hit.transform.GetComponent<Interactable>();
                    if(interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }
	}

    private void SetFocus(Interactable new_focus)
    {
        if(new_focus != focus)
        {
            if(focus != null)
                focus.OnDefocused();
            focus = new_focus;
            new_focus.OnFocused(transform);
        }
        
        motor.FollowTarget(new_focus);
    }

    private void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }
}
