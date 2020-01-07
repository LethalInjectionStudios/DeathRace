using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy);
        Instantiate(enemy);
        timer = Random.Range(4f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Instantiate(enemy);
            timer = Random.Range(4f, 7f);
        }
    }
}
