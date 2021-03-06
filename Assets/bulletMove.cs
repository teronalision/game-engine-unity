﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime;

        if (transform.position.y < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void Init(Vector3 to)
    {
        dir = to;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
