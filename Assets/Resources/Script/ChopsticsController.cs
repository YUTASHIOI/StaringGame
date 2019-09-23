using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopsticsController : MonoBehaviour
{
    [SerializeField]
    Vector2 move_range;          //箸の可動域
    [SerializeField]
    private Vector3 init_pos;   //初期位置
    [SerializeField]
    float move_speed;           //移動量
    [SerializeField]
    float noize;                //移動量がnoize以下なら削除


    private Vector3 tmp_pos;    //移動量の仮置き

    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        this.transform.localPosition = init_pos;
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
            tmp_pos.x += Input.GetAxis("L_Horizontal") * move_speed;// + init_pos.x;
            tmp_pos.y += Input.GetAxis("L_Vertical") * -move_speed;// + init_pos.y;
            tmp_pos.z = init_pos.z;

            this.transform.localPosition = tmp_pos;
        }
        else
        {
            this.transform.localPosition = init_pos;
        }
    }
}
