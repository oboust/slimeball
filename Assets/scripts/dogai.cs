using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogai : MonoBehaviour
{
    public float speed;
    GameObject player;
    public float distance;
    public bool isfollowing;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (distance > 2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
