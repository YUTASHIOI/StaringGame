using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    [SerializeField]
    Vector3 init_pos = new Vector3(-11f, -33f, -30f);
    [SerializeField]
    Quaternion init_rot = Quaternion.Euler(0f, 0f, 0f);
    [SerializeField]
    GameObject chopsticks;

    private bool on_right = false;
    private bool on_left = false;

    /*------------------------------------------------------------------*
     * ◆箸がモノに触れたとき
     *------------------------------------------------------------------*/
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitt");
        if(other.gameObject.name == "CSRight_Child") on_right = true;
        if (other.gameObject.name == "CSLeft_Child") on_left = true;
        if (on_right && on_left)
        {
            Debug.Log("きたああ");
            this.gameObject.transform.parent = GameObject.FindWithTag("chopsticks").gameObject.transform;
        }
    }
    /*------------------------------------------------------------------*
     * ◆箸がモノから離れたとき
     *------------------------------------------------------------------*/
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CSRight_Child") on_right = false;
        if (other.gameObject.name == "CSLeft_Child") on_left = false;
        if (!on_right || !on_left)
        {
            Debug.Log("落ちたあ");
            this.gameObject.transform.parent = null;
        }
    }

    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        //初期Transform
        this.transform.localPosition = init_pos;
        this.transform.localRotation = init_rot;
        //箸に触れているかどうかの判定
        on_right = false;
        on_left = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
