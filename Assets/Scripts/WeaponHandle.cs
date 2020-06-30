using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandle : MonoBehaviour
{
    public float cooltime;
    public float speed;
    public GameObject bullet;


    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Shot()
    {
        if (timer > 0)
            return;

        GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);
        obj.GetComponent<bulletMove>().Init(new Vector3(speed,0,0));
        timer = cooltime;
    }
}
