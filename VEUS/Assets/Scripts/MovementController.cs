using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }

    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Vector3 target;
    Rigidbody2D rb2d;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public float interactionRadius = 2.0f;

    void Start()
    {
        target = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateState();
        //UpdateStateMouse();
    }
    private void UpdateState()
    {
        CharStates state = CharStates.idleSouth;
        if (movement.x > 0)
        {
            state = CharStates.walkEast;
        }
        else if (movement.x < 0)
        {
            state = CharStates.walkWest;
        }
        else if (movement.y > 0)
        {
            state = CharStates.walkNorth;
        }
        else if (movement.y < 0)
        {
            state = CharStates.walkSouth;
        }
        animator.SetInteger("AnimationState", (int)state);
        spriteRenderer.flipX = (state == CharStates.walkWest);
    }

    private void UpdateStateMouse()
    {
        CharStates state = CharStates.idleSouth;
        if (target.x > 0)
        {
            state = CharStates.walkEast;
        }
        else if (target.x < 0)
        {
            state = CharStates.walkWest;
        }
        else if (target.y > 0)
        {
            state = CharStates.walkNorth;
        }
        else if (target.y < 0)
        {
            state = CharStates.walkSouth;
        }
        animator.SetInteger("AnimationState", (int)state);
        spriteRenderer.flipX = (state == CharStates.walkWest);
    }

    private void FixedUpdate()
    {
        //Movimiento ratón
        //if (Input.GetMouseButtonDown(0))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    target.z = 0f;
        //}
        //transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);

        //Movimiento teclas
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rb2d.velocity = movement * movementSpeed;
    }
}
