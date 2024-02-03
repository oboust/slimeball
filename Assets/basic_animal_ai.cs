using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_animal_ai : MonoBehaviour
{
    public float speed, range, maxdistance;
    Vector2 waypoint;
    // Start is called before the first frame update
    void Start()
    {
        setNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, waypoint, speed * speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoint) < range)
        {
            setNewDestination();
        }
    }
    void setNewDestination()
    {
        waypoint = new Vector2(Random.Range(-maxdistance, maxdistance), Random.Range(-maxdistance, maxdistance));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        setNewDestination();
    }
}
