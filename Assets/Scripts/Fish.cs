using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    public Vector2 movment;

    private bool isFollowing = false;
    public static bool particalBool = false;
    public GameObject targetObject;

    private bool _trigger= false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if (isFollowing && targetObject != null)
        {
            transform.position = targetObject.transform.position;
        }

        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * moveSpeed * Time.deltaTime);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("deadzone"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("hook"))
        {
            targetObject = collision.gameObject;
            isFollowing = true;
            trapper.caught += 1;
            particalBool = true;
        }
    }

}
