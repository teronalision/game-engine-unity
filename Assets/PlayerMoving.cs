using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 1f;

    private CharacterController cc;

    Vector3 keyinput;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        keyinput = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        keyinput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        keyinput *= speed;
        if (cc.isGrounded) {

            if (Input.GetButton("Jump"))
            {
                keyinput.y = jumpPower;
            }
        }

        keyinput.y -= 10f * Time.deltaTime;


        cc.Move(keyinput * Time.deltaTime);
    }
}
