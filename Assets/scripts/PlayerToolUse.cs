using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolUse : MonoBehaviour
{
    player player;
    Rigidbody2D RB;
    [SerializeField] float OffsetDistance = 1.0f;
    [SerializeField] float SizeInteractableArea = 1.2f;
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        player = GetComponent<player>();
    }
    void OnFire()
    {
        UseTool();
    }
    private void UseTool()
    {
        Vector2 position = RB.position + player.lastMotionVector * OffsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, SizeInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolUse use = c.GetComponent<ToolUse>();
            if (use != null)
            {
                use.hit();
                break;
            }
        }
    }
}
