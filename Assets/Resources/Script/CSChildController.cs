using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSChildController : MonoBehaviour
{
    [SerializeField]
    Vector3 pos = Vector3.zero;
    [SerializeField]
    Quaternion rot = Quaternion.Euler(0f, 0f, 0f);

    public bool on_trigger;//モノに触れたかどうか
    public bool on_collision;//モノに触れたかどうか
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
    /*------------------------------------------------------------------*
     * ◆箸がモノに触れたとき
     *------------------------------------------------------------------*/
    void OnCollisionEnter(Collision collision)
    {
        on_collision = true;
        Init();
    }
    /*------------------------------------------------------------------*
     * ◆箸がモノから離れたとき
     *------------------------------------------------------------------*/
    void OnCollisionExit(Collision collision)
    {
        on_collision = false;
    }

    void Init()
    {
        this.transform.localPosition = pos;
        this.transform.localRotation = rot;
    }

    // Start is called before the first frame update
    void Start()
    {
        on_trigger = false;
        on_collision = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Init();
    }
}
