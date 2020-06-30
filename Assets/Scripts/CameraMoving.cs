using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,3,-7);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.position;
        p.x = player.position.x;
        transform.position = Vector3.Slerp(transform.position, p, 0.1f);
    }
}
