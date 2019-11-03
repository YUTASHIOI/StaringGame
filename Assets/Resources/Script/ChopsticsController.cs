using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopsticsController : MonoBehaviour, IController
{
    [SerializeField, TooltipAttribute("ゲームステータスの取得")]
    GameDirector GameDirector;
    [SerializeField, TooltipAttribute("カメラの描画範囲")]
    CameraController CameraController;
    [SerializeField, TooltipAttribute("操作するプレイヤーID")]
    public string playerID;
    [SerializeField, TooltipAttribute("箸モデルの大きさ")]
    public Vector3 chopstick;
    [SerializeField, TooltipAttribute("移動速度")]
    float move_speed;
    [SerializeField, TooltipAttribute("移動量がnoize以下なら削除")]
    float noize;
    [SerializeField, TooltipAttribute("花粉を摘むときの初期位置")]
    private Vector2 pinch_pollen_pos;


    private Vector3 tmp_pos;    //移動量の仮置き
    private Vector2 tmp_L_stick;//アナログスティックの値を格納

    /*-----------------------------------------------------------------*
     * ◆初期化関数
     *-----------------------------------------------------------------*/
    void InitPinchPollen()
    {
        //箸の初期位置設定
        tmp_pos.x = pinch_pollen_pos.x;
        tmp_pos.y = pinch_pollen_pos.y;
        tmp_pos.z = CameraController.z;
        this.transform.localPosition = tmp_pos;
        //アナログスティックの値取得
        tmp_L_stick.x = Input.GetAxis("CSMove(Horizontal)");
        tmp_L_stick.y = Input.GetAxis("CSMove(Vertical)");
    }
    /*-----------------------------------------------------------------*
     * ◆花粉を摘む関数
     *-----------------------------------------------------------------*/
    void UpdatePinchPollen()
    {
        /*
         * ◆移動ロジック
         * 
         * if(Lスティックの移動量がnoize以下なら){
         *      Xの移動先 += sin(Lスティック（X軸方向の移動量）- tmp_L_stick.x) * move_Speed;
         *      Yの移動先 += sin(Lスティック（Y軸方向の移動量）- tmp_L_stick.y) * move_Speed;
         * }
         * 
         * 1. sin           :細かな動きと大きな動きを両立させるため
         * 2. -tmp_L_stick  :動き出しの移動量を０にするために、ひとつ前のフレームの移動量を引く
         * 3. move_speed    :最大移動量（※実際のの最大移動量は、noizeを引いているためmove_speedには達しない）
         * 
         */
        //Lスティックの移動量がnoize以上だったら,箸を移動させる

        if (Mathf.Abs(Input.GetAxis("CSMove(Horizontal)")) + Mathf.Abs(Input.GetAxis("CSMove(Vertical)")) > noize)
        {
            // 倒した角度によって移動を加速させたい
            //X軸
            tmp_pos.x += Mathf.Sin(Input.GetAxis("CSMove(Horizontal)") - tmp_L_stick.x) * move_speed;
            if (tmp_pos.x > CameraController.right) tmp_pos.x = CameraController.right;
            else if (tmp_pos.x < CameraController.left) tmp_pos.x = CameraController.left;

            //Y軸
            tmp_pos.y += Mathf.Sin(Input.GetAxis("CSMove(Vertical)") - tmp_L_stick.y) * -move_speed;
            if (tmp_pos.y > CameraController.top) tmp_pos.y = CameraController.top;
            else if (tmp_pos.y < CameraController.bottom) tmp_pos.y = CameraController.bottom;

            //Z軸
            tmp_pos.z = CameraController.z;

            //コントローラーの値を代入する
            this.transform.localPosition = tmp_pos;
        }
        else
        {
            //箸の初期位置設定
            //tmp_pos.x = pinch_pollen_pos.x;
            //tmp_pos.y = pinch_pollen_pos.y;
            //tmp_pos.z = CameraController.z;
            //this.transform.localPosition = tmp_pos;

            //アナログスティックの値取得
            tmp_L_stick.x = Input.GetAxis("CSMove(Horizontal)");
            tmp_L_stick.y = Input.GetAxis("CSMove(Vertical)");
        }
    }
    /*****************************************************************
     * Awake
     *****************************************************************/
    void Awake()
    {
        InitPinchPollen();
    }

    void Start()
    {
        GameDirector.Controllers.Add(this);
    }

    public void ControllerInitialize()
    {
        InitPinchPollen();
    }

    public void ControllerUpdate()
    {
        UpdatePinchPollen();
    }

    public void ControllerFinalize()
    {

    }
}
