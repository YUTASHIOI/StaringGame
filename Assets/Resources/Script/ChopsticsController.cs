using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopsticsController : MonoBehaviour
{
    [SerializeField]
    float MoveRange = 30f;         //Z軸に対する箸の可動域
    [SerializeField]
    float noize = 0.3f;           //移動量がnoize以下なら削除
    [SerializeField]
    private Vector3 init_pos = new Vector3(8f, -35f, -30f);     //初期位置
    private Vector3 pos;
    // Start is called before the first frame update

    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        this.transform.localPosition = init_pos;
    }
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
            pos.x = Input.GetAxis("L_Horizontal") * MoveRange + init_pos.x;
            pos.y = Input.GetAxis("L_Vertical") * -MoveRange + init_pos.y;
            pos.z = init_pos.z;
            this.transform.localPosition = pos;
        }
        else
        {
            this.transform.localPosition = init_pos;
        }
    }
}
