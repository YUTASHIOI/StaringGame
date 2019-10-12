using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSChildController : MonoBehaviour
{
    [SerializeField]
    ChopsticsController ChopsticksController;
    public bool on_trigger;         //モノに触れたかどうか
    public bool on_collision;       //モノに触れたかどうか
    public float speed;           //箸の移動量
    [SerializeField, TooltipAttribute("種とぶつかったときの音")]
    AudioClip se_hit_seed;

    private Vector3 local_pos;      //箸オブジェクトの位置
    private Vector3 pre_world_pos;  //ひとつ前のふれーむの座標

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
        
        if (collision.gameObject.tag == "seed")
        {
            //SE再生
            this.GetComponent<AudioSource>().PlayOneShot(se_hit_seed);
        }
    }
    /*------------------------------------------------------------------*
     * ◆箸がモノから離れたとき
     *------------------------------------------------------------------*/
    void OnCollisionExit(Collision collision)
    {
        on_collision = false;
    }
    /*------------------------------------------------------------------*
     * ◆pos, rotの初期化
     *------------------------------------------------------------------*/
    void InitPosRot()
    {
        this.transform.localPosition = local_pos;
        this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
    /*------------------------------------------------------------------*
     * ◆初期化
     *------------------------------------------------------------------*/
    void Init()
    {
        //----ワールド座標系
        pre_world_pos =  this.transform.position;

        //----ローカル座標系
        //箸の初期位置を設定
        local_pos.x = 0f;
        //local_pos.y = 2f;
        local_pos.y = Mathf.Abs(gameObject.transform.parent.gameObject.transform.localPosition.y)
            - (ChopsticksController.chopstick.y / 2f);
        local_pos.z = 0f;

        //Pos, Rot
        InitPosRot();
        //Scale
        this.transform.localScale = ChopsticksController.chopstick;

        on_trigger = false;
        on_collision = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

        //【危険】
        //----ローカル座標系
        //CS_Right_ChildのPosとRotの値がおかしくなるので、ここで制限をかけておく
        InitPosRot();

        //箸の移動量を計算
        speed　= ((this.transform.position - pre_world_pos) / Time.deltaTime).magnitude;

        //Debug.Log(speed.magnitude);

        //----ワールド座標系
        pre_world_pos = this.transform.position;

    }
}
