using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;
    public GameObject canvas;
    public GameObject[] enermys;


    private AudioSource adso;
    public AudioClip bgm;
    public AudioClip over;

    // Start is called before the first frame update
    private void Awake()
    {

    }

    void Start()
    {
        adso = GetComponent<AudioSource>();
        Instantiate<GameObject>(goal, new Vector3(80, 0, 0), Quaternion.identity);
        SetField();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetField()
    {
        Instantiate<GameObject>(player, Vector3.zero, Quaternion.identity);

        var objs = GameObject.FindGameObjectsWithTag("Enermy");
        foreach (GameObject o in objs)
        {
            Destroy(o);
        }

        for (int i = 0; i<10; i++)
        {
            Instantiate<GameObject>(enermys[0], new Vector3(Random.RandomRange(7, 80),1,0), Quaternion.Euler(0,180,0));
        }

        adso.clip = bgm;
        adso.loop = true;
        adso.Play();
    }

    public void StageClear()
    {
        canvas.transform.Find("ClearText").gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoving>().enabled = false;
        Debug.Log("clear");
    }
    public void Dieing()
    {
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Player"));
        Invoke("SetField", 5);

        adso.Stop();
        adso.clip = over;
        adso.Play();
    }
}
