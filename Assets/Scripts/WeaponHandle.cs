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

    public void Shot(string tag, Vector2 dir)
    {
        if (timer > 0)
            return;

        Vector3 bpos = new Vector3(0, 0.5f, 0);

        GameObject obj = Instantiate(bullet, transform.position + bpos, Quaternion.identity);
        obj.GetComponent<bulletMove>().Init(dir * speed);
        obj.tag = tag;
        timer = cooltime;

        GameObject.Destroy(obj, 10);//10초 뒤 총알 삭제
    }
    public void Shot(string tag)
    {
        Shot(tag, Vector2.right);
    }
}
