using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellIconBehaviour : MonoBehaviour
{

    private GameObject collidingWith = null;

    public GameObject CollidingWith { get => collidingWith; set => collidingWith = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("COLLIDER");
        collidingWith = collision.gameObject;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
    }

    void OnTriggerExit2D()
    {
        //Debug.Log("NO COLLIDER");
        collidingWith = null;
    }
}
