using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{

    public float speed = 3f;
    public float jumpPower = 1f;

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
        jumpGage = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        keyinput = new Vector3(Input.GetAxis("Horizontal") * speed, -10, 0);

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
        if (Input.GetAxis("Fire1") > 0)
        {
            wh.Shot("Players");
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
        }
    }
}
