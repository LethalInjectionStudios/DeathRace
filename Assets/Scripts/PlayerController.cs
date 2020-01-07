using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 2f;
    private float boostCooldown = 0f;
    private float boostTime = 0f;
    private float shotCooldown = 0f;
    private float spinCooldown = 0f;

    public GameObject cannon;

    public GameObject missile;
    
    // Update is called once per frame
    void Update()
    {     
        boostCooldown -= Time.deltaTime;
        boostTime -= Time.deltaTime;
        shotCooldown -= Time.deltaTime;
        spinCooldown -= Time.deltaTime;

        if(boostTime > 0){
            moveSpeed = 8f;
        }
        else {
            moveSpeed = 2f;
        }

        if(spinCooldown >= 0)
        {
            this.transform.eulerAngles += Vector3.forward * 45f;
        }

        if(spinCooldown <= 0)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position += transform.up * moveSpeed * Time.deltaTime;
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                this.transform.eulerAngles += Vector3.forward * 45f;
            }

            if(Input.GetKeyDown(KeyCode.RightArrow)){
                this.transform.eulerAngles -= Vector3.forward * 45f;
            }

            if(Input.GetKeyDown(KeyCode.RightControl) && boostCooldown <= 0){
                boostTime = 1f;
                boostCooldown = 5f;
            }

            if(Input.GetKeyDown(KeyCode.RightShift) && shotCooldown <= 0){
                Instantiate(missile, cannon.transform.position, cannon.transform.rotation);
                shotCooldown = 5f;
            }
        }
    }

    public void TakeHit()
    {
        spinCooldown = 1f;
    }
}
