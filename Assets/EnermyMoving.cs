using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMoving : MonoBehaviour
{
    private CharacterController cc;
    private WeaponHandle wh;

    float timer = 0;

    bool on = true;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        wh = GetComponentInChildren<WeaponHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(PlayerMoving.pos, transform.position) < 15)
        {
            on = true;
        }
        else
        {
            on = false;
            return;
        }

        timer += Random.RandomRange(0.01f, 0.1f);

        if (timer > 5)
        {
            wh.Shot("Enermy");
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Players" && on)
        {
            GameObject.Destroy(gameObject);
            GameObject.Destroy(other);
        }
    }
}
