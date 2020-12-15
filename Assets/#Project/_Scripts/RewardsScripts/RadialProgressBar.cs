using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressBar : MonoBehaviour {

    public Image imageBackground;

    [Range(0, 100)]
    public float amount = 0;

    private Text pieCircleText;


    private void Start()
    {
        pieCircleText = GetComponentInChildren<Text>();
    }
}
