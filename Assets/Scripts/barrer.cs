using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrer : MonoBehaviour
{
    public static bool barrers = false;

    

    
    private void Update()
    {
        Debug.Log(barrers);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hook"))
        {
            barrers = true;
        }
    }

}
