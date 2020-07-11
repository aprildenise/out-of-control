using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float interactionRadius; 
    private new Rigidbody rigidbody;
    public float health;
    public float moveSpeed;
    public bool isMoving;
    public Vector3 moveVelocity;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get axis input for movement.
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        isMoving = moveInput != Vector3.zero;
        moveVelocity = moveInput.normalized * moveSpeed;

        // TODO: CHANGE INPUT KEY ACCORDINGLY
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, interactionRadius);
            foreach (Collider hit in hits)
            {
                Interactible interactible = hit.gameObject.GetComponent<Interactible>();
                if (interactible != null)
                {
                    interactible.Interact();
                }
                else
                {
                    continue;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

}
