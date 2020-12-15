using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    [HideInInspector]
    public float moveHorizontal;
    [HideInInspector]
    public float moveVertical;

    void FixedUpdate ()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }
}
