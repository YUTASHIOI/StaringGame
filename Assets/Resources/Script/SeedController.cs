using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    [SerializeField]
    GameObject chopsticks;

    private bool on_right = false;
    private bool on_left = false;

    /*------------------------------------------------------------------*
     * ◆箸がモノに触れたとき
     *------------------------------------------------------------------*/
    void OnCollisionEnter(Collision collision)
    {
        //どの箸に衝突したかフラグの更新
        if(collision.gameObject.name == "CSRight_Child") on_right = true;
        if (collision.gameObject.name == "CSLeft_Child") on_left = true;

        //箸に衝突したら種を動かす
        Vector3 force = Vector3.zero;
        foreach (ContactPoint point in collision.contacts)
        {
            //箸の先に加速度取得用の空のオブジェクトを設置する
            //箸の先からぶつかった位置が遠くなるほど、箸本来の移動速度に柄づいていく
            force = (transform.position - point.point).normalized * 10f;
        }
        // 力を加える
        //ForceMode.VelocityChange:質量を無視して一回だけ力を加える
        this.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

        if (on_right && on_left)
        {
            Debug.Log("きたああ");
            this.gameObject.transform.parent = GameObject.FindWithTag("chopsticks").gameObject.transform;
        } 

    }
    /*------------------------------------------------------------------*
     * ◆箸がモノから離れたとき
     *------------------------------------------------------------------*/
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "CSRight_Child") on_right = false;
        if (collision.gameObject.name == "CSLeft_Child") on_left = false;
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
