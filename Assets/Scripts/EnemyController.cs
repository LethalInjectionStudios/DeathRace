using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private int direction = 0;
    private float moveSpeed = .5f;
    private float timer = 2.5f;
    public Sprite grave;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        direction = Random.Range(0, 3);
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            direction = Random.Range(0, 3);
            timer = 2.5f;
        }

        if(direction == 0)
            this.transform.position += transform.up * moveSpeed * Time.deltaTime;
        if(direction == 1)
            this.transform.position -= transform.up * moveSpeed * Time.deltaTime;
        if(direction == 2)
            this.transform.position += transform.right * moveSpeed * Time.deltaTime;
        if(direction == 3)
            this.transform.position -= transform.right * moveSpeed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collision");
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            other.gameObject.GetComponent<ScoreController>().Score();
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = grave;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameManager.gameObject.GetComponent<GameManager>().Spawn();
            this.gameObject.GetComponent<EnemyController>().enabled = false;
        }

        if(other.gameObject.name == "L_Boundary_Enemy")
        {
            direction = 2;
        }
        if(other.gameObject.name == "R_Boundary_Enemy")
        {
            direction = 3;
        }
        if(other.gameObject.name == "T_Boundary")
        {
            direction = 1;
        }
        if(other.gameObject.name == "B_Boundary")
        {
            direction = 0;
        }
    }
}
