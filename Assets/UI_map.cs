using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_map : MonoBehaviour
{
    public GameObject charic;
    private Slider mSlider;

    public float goal = 40;

    // Start is called before the first frame update
    void Start()
    {
        mSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        mSlider.value = Mathf.Clamp01(charic.transform.position.x / goal);
    }
}
