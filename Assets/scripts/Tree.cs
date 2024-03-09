using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ToolUse
{
    public InteractionSystem player;
    public GameObject prefab;
    void OnFire()
    {
        hit();
    }
    public override void hit()
    {
        if (player.isCuttable)
        {
            Instantiate(prefab, new Vector2(player.transform.position.x, player.transform.position.y - 1.25f), Quaternion.identity);
        }
    }

}
