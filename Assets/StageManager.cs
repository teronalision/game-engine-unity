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


    // Start is called before the first frame update
    private void Awake()
    {

    }

    void Start()
    {
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
        

    }

    public void StageClear()
    {
        canvas.transform.Find("ClearText").gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoving>().enabled = false;
        Debug.Log("clear");
    }
    public void Dieing()
    {
        GameObject.Destroy(player);
        SetField();
    }
}
