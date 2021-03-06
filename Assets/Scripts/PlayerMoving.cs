﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    static public Vector3 pos;


    public float speed;
    public float jumpPower;

    private float jumpGage;

    private CharacterController cc;
    private WeaponHandle wh;
    private Animation ani;
    

    Vector3 keyinput;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        wh = GetComponentInChildren<WeaponHandle>();
        ani = GetComponent<Animation>();
        
        keyinput = new Vector3();
        jumpGage = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {

        keyinput = new Vector3(Input.GetAxis("Horizontal") * speed, -5, 0);

        if (cc.isGrounded) {
            jumpGage = 0.3f;        
        }
        if (Input.GetButton("Jump") && jumpGage > 0)
        {
            keyinput.y = jumpPower;
            jumpGage -= Time.deltaTime;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpGage = 0;
        }


        cc.Move(keyinput * Time.deltaTime);
        if (Mathf.Abs(cc.velocity.x) > 0)
        {
            ani.Play();
        }
        else
        {
            ani.Stop();
        }
        if (cc.velocity.y > 0)
        {

        }


        ////
        Vector2 mouse = Input.mousePosition;
        mouse -= new Vector2(Screen.width/2, Screen.height/2);
        mouse = mouse.normalized;
        if (Input.GetMouseButtonDown(0) && wh != null)
        {
            //Debug.Log(mouse);
            wh.Shot("Players", mouse);
        }

        pos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            GameObject.Find("StageManager").GetComponent<StageManager>().StageClear();
        }
        else if (other.tag == "Enermy")
        {
            GameObject.Find("StageManager").GetComponent<StageManager>().Dieing();
            GameObject.Destroy(other);
        }
        else if (other.tag == "Item")
        {
            if (wh != null)
            {
                Destroy(transform.Find("Weapon").gameObject);
            }

            GameObject obj = Instantiate(other.GetComponentInParent<ItemHandle>().Weapon, transform);
            obj.name = "Weapon";
            wh = obj.GetComponent<WeaponHandle>();
            GameObject.Destroy(other.transform.parent.gameObject);
        }
        Debug.Log(other.tag);
    }
}
