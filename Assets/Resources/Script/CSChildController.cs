using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSChildController : MonoBehaviour
{
    public bool on_trigger;//モノに触れたかどうか
    /*------------------------------------------------------------------*
     * ◆箸がモノに触れたとき
     *------------------------------------------------------------------*/
    void OnTriggerEnter(Collider other)
    {
        on_trigger = true;
    }
    /*------------------------------------------------------------------*
     * ◆箸がモノから離れたとき
     *------------------------------------------------------------------*/
    void OnTriggerExit(Collider other)
    {
        on_trigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        on_trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
