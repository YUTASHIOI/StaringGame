using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public bool right_button;
    public bool middle_button;
    public bool left_button;


    // Start is called before the first frame update
    void Start()
    {
        right_button = false;
        middle_button = false;
        left_button = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) left_button = true;
        if (Input.GetMouseButtonDown(1)) right_button = true;
        if (Input.GetMouseButtonDown(2)) middle_button = true;
        if (Input.GetMouseButtonUp(0))   left_button = false;
        if (Input.GetMouseButtonUp(1))   right_button = false;
        if (Input.GetMouseButtonUp(2))   middle_button = false;

        Debug.Log(left_button + ":" + middle_button + ":" + right_button);

    }
}
