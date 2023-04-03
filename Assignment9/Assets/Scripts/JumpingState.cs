/*
 * Gerard Lamoureux
 * JumpingState
 * Assignment9
 * Handles the player jumping state
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : PlayerState
{
    private PlayerController playerController;

    private bool hasStartedFalling = false;

    public JumpingState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void EnterState()
    {
        Debug.Log("Entering jumping state");
        playerController.rb.AddForce(Vector2.up * 500f);
    }

    public void UpdateState()
    {
        if(playerController.rb.velocity.y < 0f)
        {
            hasStartedFalling = true;
        }
        Debug.Log(hasStartedFalling);

        if(playerController.rb.velocity.y == 0 && IsGrounded() && hasStartedFalling)
        {
            playerController.SetState(playerController.idleState);
        }
    }

    public void ExitState()
    {
        hasStartedFalling = false;
        Debug.Log("Landed");
    }

    private bool IsGrounded()
    {
        float bottom = playerController.GetComponent<Collider2D>().bounds.min.y;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(playerController.transform.position.x, bottom-0.01f), Vector2.down, 0.1f);
        return hit.collider != null;
    }
}
