using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandle : MonoBehaviour
{
    public GameObject Weapon;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Vector3 p = transform.position;
        p.y = (Mathf.Sin(timer * Mathf.PI) + 1) * 0.5f;
        transform.position = p;


        transform.rotation = Quaternion.EulerAngles(0, timer, 0);
    }
}
