using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSLeftRootController : MonoBehaviour
{
    [SerializeField, TooltipAttribute("デバッグ用")] MouseController mouseController;
    [SerializeField] CSChildController CSChildController;
    float pinch_stop;
    float pinch_speed;

    //アニメーションカーブで実装する


    /*------------------------------------------------------------------*
     * ◆箸のステータス更新
     *------------------------------------------------------------------*/
     void UpdateState()
    {
        //Lボタンを押しているとき
        if (mouseController.left_button )
        {
            transform.Rotate(0.0f, 0.0f, pinch_speed, Space.Self);
            //330度になったら停止する
            if (transform.localRotation.z >= pinch_stop)
            {
                transform.localRotation = Quaternion.Euler(0.0f, 0.0f, pinch_stop);
            }

        }
        //Lボタンを離したとき
        /*else
        {
            //transform.Rotate(0.0f, 0.0f, -pinch_speed, Space.Self);
            //0度になったら停止する
            if (transform.localRotation.z <= 0.0f)
            {
                transform.localRotation = Quaternion.identity;
            }
        }
        */

    }

    /*------------------------------------------------------------------*
     * ◆初期化
     *------------------------------------------------------------------*/
    void Init()
    {
        //箸の位置の初期化
        transform.localPosition = new Vector3(0.0f, -5.0f, 0.0f);
        //箸の移動速度
        pinch_speed = -3.0f;
        pinch_stop = 330.0f;
    }


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        //ステータスの更新
        UpdateState();
    }
}
