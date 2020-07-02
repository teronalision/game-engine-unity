using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMoving : MonoBehaviour
{
    private CharacterController cc;
    private WeaponHandle wh;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        wh = GetComponentInChildren<WeaponHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            wh.Shot("Enermy");
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Players")
        {
            GameObject.Destroy(gameObject);
            GameObject.Destroy(other);
        }
    }
}
