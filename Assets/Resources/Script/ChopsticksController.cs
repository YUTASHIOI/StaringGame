using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopsticksController : MonoBehaviour
{
    [SerializeField] MouseController mouseController;
    [SerializeField] Transform upper_root;
    [SerializeField] Transform lower_root;
    [SerializeField] ChopstickController chopstick_upper;
    [SerializeField] ChopstickController chopstick_lower;
    [SerializeField]　float pinch_speed;//つまむときのスピード

    int upper_state;//-1：元の位置に移動, 0:停止, 1,挟む方向に移動, 2:モノに触れた場合
    int lower_state;//-1：元の位置に移動, 0:停止, 1,挟む方向に移動, 2:モノに触れた場合

    /*------------------------------------------------------------------*
     * ◆箸でつまむ
     *------------------------------------------------------------------*/
    void pinchChopstick()
    {
        //Statusの更新
        if (mouseController.left_button)
        {
            upper_state = 1;
        }
        if (!mouseController.left_button)
        {
            upper_state = -1;
            //元の位置まで戻ったら停止する
            if(upper_root.localRotation.z <= 0.0f)
            {
                upper_root.localRotation = Quaternion.identity;
                upper_state = 0;
            }
        }
        //箸を動かす
        if (upper_state != 0)
        {
            upper_root.Rotate(0.0f, 0.0f, upper_state * pinch_speed, Space.Self);
        }

        //モノに触れていた場合、元の位置まで戻る
        if (chopstick_upper.on_trigger)
        {
            upper_root.Rotate(0.0f, 0.0f, -upper_state * pinch_speed, Space.Self);
            upper_state = 2;
        }
    }
    /*------------------------------------------------------------------*
     * ◆箸がモノに触れたとき
     *------------------------------------------------------------------*/
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitttt");
    }


    /*------------------------------------------------------------------*
     * ◆初期化関数
     *------------------------------------------------------------------*/
    void Init()
    {
        //参照系
        upper_root = gameObject.transform.Find("upper_root").transform;
        lower_root = gameObject.transform.Find("lower_root").transform;

        //値の初期化
        upper_state = 0;
        lower_state = 0;
        pinch_speed = 3.0f;

        //箸の位置の初期化
        upper_root.localPosition = new Vector3(0.0f,  5.0f, 0.0f);
        lower_root.localPosition = new Vector3(0.0f, -5.0f, 0.0f);
    }

    /*------------------------------------------------------------------*/
    // Start is called before the first frame update
    /*------------------------------------------------------------------*/
    void Start()
    {
        Init();
    }

    /*------------------------------------------------------------------*/
    // Update is called once per frame
    /*------------------------------------------------------------------*/
    void Update()
    {
        //箸でつまむ
        pinchChopstick();
    }
}
