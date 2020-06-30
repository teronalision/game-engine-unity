using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;
    public GameObject canvas;

    static public StageManager instance = null;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        instance = GetComponent<StageManager>();
    }

    void Start()
    {
        Instantiate<GameObject>(player,Vector3.zero, Quaternion.identity);
        Instantiate<GameObject>(goal,new Vector3(80,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageClear()
    {
        canvas.transform.Find("Text").gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoving>().enabled = false;
        Debug.Log("clear");
    }
}
