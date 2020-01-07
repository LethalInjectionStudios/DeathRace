using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().TakeHit();
        }

        if(other.gameObject.tag == "Player2")
        {
            other.GetComponent<Player2Controller>().TakeHit();
        }    
    }
}
