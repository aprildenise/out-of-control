﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Destructible
{


    public float maxHealth;
    public float currentHealth;
    public int fruit;
    public int money;

    public bool placedFirstPlant = false;

    public Animator anim;
    public SpriteRenderer sprite;
    public float interactionRadius; 
    private new Rigidbody rigidbody;
    public float health;
    public float moveSpeed;
    public bool isMoving;
    public Vector3 moveVelocity;
    public Transform overHeadPosition;
    public GameObject currentlyHolding;

    public static PlayerController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        currentHealth = maxHealth;
        instance = this;

    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get axis input for movement.
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        isMoving = moveInput != Vector3.zero;
        anim.SetBool("isMoving", isMoving);
        moveVelocity = moveInput.normalized * moveSpeed;

        // TODO: CHANGE INPUT KEY ACCORDINGLY
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!placedFirstPlant)
            {
                int random = Random.Range(1, 3 + 1);
                GameObject spawn = PrefabManager.instance.InitPrefab(random, transform.position);
                placedFirstPlant = true;
                return;
            }

            //if (currentlyHolding.GetComponent<Plant>())
            //{

            //}

            Collider[] hits = Physics.OverlapSphere(transform.position, interactionRadius);
            foreach (Collider hit in hits)
            {
                Debug.Log("possible interaction with:" + hit.gameObject.name);
                Interactible interactible = hit.gameObject.GetComponent<Interactible>();
                if (interactible != null)
                {
                    interactible.InteractWith();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //rigidbody.MovePosition(moveVelocity * Time.fixedDeltaTime);
        
        if (isMoving) rigidbody.MovePosition(rigidbody.position + moveVelocity * Time.fixedDeltaTime);
        //rigidbody.AddForce(rigidbody.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    public void TakeDamage()
    {
        Debug.Log("Player took damage");
        currentHealth -= 10;

        float healthPercentage = (1f - (currentHealth / maxHealth));
        sprite.color = Color.HSVToRGB(0, healthPercentage, 1);
    }

    public void ResetHealth()
    {
        Debug.Log("Player heal");
        currentHealth = maxHealth;
        float healthPercentage = (1f - (currentHealth / maxHealth));
        sprite.color = Color.HSVToRGB(0, healthPercentage, 1);
    }
}
