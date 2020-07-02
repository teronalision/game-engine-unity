﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{

    public float speed;
    public float jumpPower;

    private float jumpGage;

    private CharacterController cc;
    private WeaponHandle wh;

    Vector3 keyinput;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        wh = GetComponentInChildren<WeaponHandle>();
        keyinput = new Vector3();
        jumpGage = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        keyinput = new Vector3(Input.GetAxis("Horizontal") * speed, -5, 0);

        if (cc.isGrounded) {
            jumpGage = 0.2f;        
        }
        if (Input.GetButton("Jump") && jumpGage > 0)
        {
            keyinput.y = jumpPower;
            jumpGage -= Time.deltaTime;
        }


        cc.Move(keyinput * Time.deltaTime);

        ////
        Vector2 mouse = Input.mousePosition;
        mouse -= new Vector2(Screen.width/2, Screen.height/2);
        mouse = mouse.normalized;
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(mouse);
            wh.Shot("Players", mouse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            GameObject.Find("StageManager").GetComponent<StageManager>().StageClear();
        }
        else if (other.gameObject.tag == "Enermy")
        {
            GameObject.Find("StageManager").GetComponent<StageManager>().Dieing();
            GameObject.Destroy(other);
        }
    }
}
