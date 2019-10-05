using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopsticsController : MonoBehaviour
{
    [SerializeField, TooltipAttribute("カメラの描画範囲")]
    CameraController CameraController;
    [SerializeField, TooltipAttribute("箸モデルの大きさ")]
    public Vector3 chopstick;
    [SerializeField, TooltipAttribute("初期位置")]
    private Vector2 init_pos;
    [SerializeField, TooltipAttribute("移動速度")]
    float move_speed;
    [SerializeField, TooltipAttribute("移動量がnoize以下なら削除")]
    float noize;


    private Vector3 CS_Right_Root;//箸本体の座標
    private Vector3 CS_Left_Root;//箸本体の座標
    private Vector3 tmp_pos;    //移動量の仮置き

    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        //箸の初期位置設定
        tmp_pos.x = init_pos.x;
        tmp_pos.y = init_pos.y;
        tmp_pos.z = CameraController.z;
        this.transform.localPosition = tmp_pos;
        //箸本体の座標取得
        CS_Right_Root = gameObject.transform.Find("CSRight_Root").gameObject.transform.localPosition;
        CS_Left_Root = gameObject.transform.Find("CSLeft_Root").gameObject.transform.localPosition;
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
            // 倒した角度によって移動を加速させたい

            //X軸
            tmp_pos.x += Input.GetAxis("L_Horizontal") * move_speed;
            if (tmp_pos.x > CameraController.right - chopstick.x) tmp_pos.x = CameraController.right - chopstick.x;
            else if (tmp_pos.x < CameraController.left) tmp_pos.x = CameraController.left;

            //Y軸
            tmp_pos.y += Input.GetAxis("L_Vertical") * -move_speed;
            if (tmp_pos.y > CameraController.top - CS_Right_Root.y) tmp_pos.y = CameraController.top - CS_Right_Root.y;
            else if (tmp_pos.y < CameraController.bottom - CS_Left_Root.y) tmp_pos.y = CameraController.bottom - CS_Left_Root.y;
            
            //Z軸
            tmp_pos.z = CameraController.z;


            //コントローラーの値を代入する
            this.transform.localPosition = tmp_pos;
        }
        else
        {
            //箸の初期位置設定
            tmp_pos.x = init_pos.x;
            tmp_pos.y = init_pos.y;
            tmp_pos.z = CameraController.z;
            this.transform.localPosition = tmp_pos;
        }
    }
}
