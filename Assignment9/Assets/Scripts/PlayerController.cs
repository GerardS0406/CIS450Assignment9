/*
 * Gerard Lamoureux
 * PlayerController
 * Assignment9
 * Handles the player and its states.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerState idleState;
    public PlayerState walkingState;
    public PlayerState jumpingState;
    public PlayerState defenseState;
    public PlayerState defenseAndWalkingState;
    public PlayerState deadState;

    private PlayerState currentState;

    public Rigidbody2D rb { get; private set; }

    public SpriteRenderer spriteRenderer { get; private set; }

    public int health { get; private set; } = 100;

    [HideInInspector] public int shield = 0;

    public GameObject shieldObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        idleState = new IdleState(this);
        walkingState = new WalkingState(this, 8f);
        jumpingState = new JumpingState(this);
        defenseState = new DefenseState(this, 8);
        defenseAndWalkingState = new DefenseAndWalkingState(this, 3f, 3);
        deadState = new DeadState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if(currentState != jumpingState && currentState != deadState)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetState(jumpingState);
            }
            else if (Input.GetAxisRaw("Horizontal") != 0f && Input.GetMouseButton(1))
            {
                if(currentState != defenseAndWalkingState)
                    SetState(defenseAndWalkingState);
            }
            else if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                if(currentState != walkingState)
                    SetState(walkingState);
            }
            else if (Input.GetMouseButton(1))
            {
                if(currentState != defenseState)
                    SetState(defenseState);
            }
        }

        currentState.UpdateState();
    }

    public void SetState(PlayerState newState)
    {
        if(currentState != null)
        {
            currentState.ExitState();
        }

        currentState = newState;

        if(currentState != null)
        {
            currentState.EnterState();
        }
    }

    public void TakeDamage(int temp)
    {
        int damage = temp - shield;
        if (damage < 0)
            damage = 0;
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            if(currentState != deadState)
            SetState(deadState);
        }
    }
}
