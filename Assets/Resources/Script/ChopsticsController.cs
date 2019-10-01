﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopsticsController : MonoBehaviour
{
    [SerializeField, TooltipAttribute("箸モデルの大きさ")]
    public Vector3 chopstick;
    [SerializeField, TooltipAttribute("初期位置")]
    private Vector3 init_pos;
    [SerializeField, TooltipAttribute("箸の可動域")]
    Vector2 move_range;
    [SerializeField, TooltipAttribute("移動速度")]
    float move_speed;
    [SerializeField, TooltipAttribute("移動量がnoize以下なら削除")]
    float noize;


    private Vector3 tmp_pos;    //移動量の仮置き

    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        this.transform.localPosition = init_pos;
        tmp_pos = init_pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Abs(Input.GetAxis("L_Vertical"))+ Mathf.Abs(Input.GetAxis("L_Vertical")));

        if (Mathf.Abs(Input.GetAxis("L_Vertical")) + Mathf.Abs(Input.GetAxis("L_Vertical")) > noize)
        {
            //X軸
            tmp_pos.x += Input.GetAxis("L_Horizontal") * move_speed;
            if (tmp_pos.x > move_range.x - chopstick.x) tmp_pos.x = move_range.x - chopstick.x;
            else if (tmp_pos.x < -move_range.x) tmp_pos.x = -move_range.x;
            //Y軸
            tmp_pos.y += Input.GetAxis("L_Vertical") * -move_speed;
            if (tmp_pos.y > move_range.y + 2f) tmp_pos.y = move_range.y + 2f;
            else if (tmp_pos.y < -move_range.y) tmp_pos.y = -move_range.y;
            //Z軸
            tmp_pos.z = init_pos.z;

            //コントローラーの値を代入する
            this.transform.localPosition = tmp_pos;
        }
        else
        {
            this.transform.localPosition = init_pos;
        }
    }
}
