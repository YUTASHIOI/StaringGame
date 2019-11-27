using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    [SerializeField, TooltipAttribute("種が破裂したときの音")]
    AudioClip se_explosion;

    [SerializeField, TooltipAttribute("カメラの描画範囲")]
    CameraController CameraController;

    Vector3 down = new Vector3(0.0f, -0.8f, 0.0f);

    private float UNIVERSAL_GRAVITATION = 6.67E-5f;

    public GameObject sun;
    public float initVelocityY;
    private float f;    //万有引力
    private float m;    //惑星の質量
    private float M;    //太陽の質量
    private float r;    //太陽と惑星の距離
    private float G = 6.67E-5f;    //万有引力定数(通常の1000000倍)
    public bool gravitySwitch = false;

    Vector3 Center_Pos;
    Vector3 side1;
    Vector3 side2;
    int gravityTimer = 0;

    Vector3 tmp_pos;


    private bool on_right = false;
    private bool on_left = false;
    private bool particle_flag = false;
    private Vector3 pre_velocity;                  //箸の移動量

    

    /*------------------------------------------------------------------*
     * ◆種が割れる処理
     *------------------------------------------------------------------*/
    private IEnumerator SeedExplosion()
    {
        //種破裂フラグON
        particle_flag = true;
        //モデルとコリジョンを非表示にする
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;
        //SE再生
        this.GetComponent<AudioSource>().PlayOneShot(se_explosion);
        //パーティクルの再生
        this.transform.GetComponentInChildren<ParticleSystem>().Play();
        //パーティクル再生終了まで待つ
        yield return new WaitForSeconds(transform.GetComponentInChildren<ParticleSystem>().main.duration);
        //種オブジェクトを非表示にする
        this.gameObject.SetActive(false);
    }


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
            force = -pre_velocity;
            //箸の先に加速度取得用の空のオブジェクトを設置する
            //箸の先からぶつかった位置が遠くなるほど、箸本来の移動速度に柄づいていく
            //【注意】いろいろ怪しそう
            force += (transform.position - point.point).normalized
                * collision.gameObject.GetComponent<CSChildController>().speed;
        }
        // 力を加える
        //ForceMode.VelocityChange:質量を無視して一回だけ力を加える
        this.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

        //箸で掴まれたら親要素にくっつける
        if (on_right && on_left)
        {
            Debug.Log("きたああ");
            this.gameObject.transform.parent = GameObject.FindWithTag("chopsticks").gameObject.transform;

            //重力を gravityTimer だけ無効化
            gravitySwitch = false;
            gravityTimer = -1000;
        }
    }
    /*------------------------------------------------------------------*
     * ◆箸に触れている間中
     *------------------------------------------------------------------*/
    void OnCollisionStay(Collision collision)
    {
        //種爆発処理
        if (!particle_flag)
        {
            foreach (ContactPoint point in collision.contacts)
            {
                if ((transform.position - point.point).magnitude <= 0.3f)
                {
                    //種破裂
                    StartCoroutine("SeedExplosion");
                }
            }
        }
    }
    /*------------------------------------------------------------------*
     * ◆箸から離れたとき
     *------------------------------------------------------------------*/
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "CSRight_Child") on_right = false;
        if (collision.gameObject.name == "CSLeft_Child") on_left = false;
        if (!on_right || !on_left)
        {
            //Debug.Log("落ちたあ");
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
        //種をつぶす
        particle_flag = false;
        //種の移動量
        pre_velocity = Vector3.zero;
    }

    void Gravity_Init()
    {
        sun = GameObject.Find("SUN");
        CameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
        Center_Pos = sun.GetComponent<Transform>().position;
        //惑星に初速を与える
        Vector3 initVelocity = new Vector3(0f, -initVelocityY, 0f); ;
        GetComponent<Rigidbody>().velocity = initVelocity;
        //惑星と太陽の質量を取得しておく
        m = GetComponent<Rigidbody>().mass;
        M = sun.GetComponent<Rigidbody>().mass;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Gravity_Init();
    }


    /*----------------------------------------------------*
     * ◆アップデート関数
     *----------------------------------------------------*/
    //一定のルートで周回
    void KeepDistance(float dis, Vector3 direction)
    {
        if (dis < 4.0f)
        {
            GetComponent<Rigidbody>().AddForce(-f * (4.0f / dis) * direction, ForceMode.Force);
            //G = (UNIVERSAL_GRAVITATION / 1000) * dis * 200;
        }
        else if (dis > 13.0f)
        {
            GetComponent<Rigidbody>().AddForce((dis / 13) * f * direction, ForceMode.Force);
            //G = UNIVERSAL_GRAVITATION * dis/10;
        }
        else
        {
            G = UNIVERSAL_GRAVITATION;
        }
    }

    //重力発生
    void GravityUpdate()
    {
        //最初の力
        //if (GetComponent<Transform>().position.y < -2.7f && gravitySwitch == false)
        if (gravityTimer > 20 && gravitySwitch == false)
        {
            gravitySwitch = true;
            side1 = Center_Pos - this.transform.position;
            side2 = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f) - this.transform.position;
            Vector3 initVelocity = Vector3.Cross(side1, side2).normalized * initVelocityY;
            GetComponent<Rigidbody>().velocity = initVelocity;
        }
        else
        {
            gravityTimer++;
        }

        //重力ON
        if (gravitySwitch)
        {
            //惑星から太陽に向かうベクトルを計算
            Vector3 direction = sun.transform.position - GetComponent<Transform>().position;
            //太陽と惑星の距離rを計算
            r = direction.magnitude;
            //単位ベクトルに変換（後で万有引力の方向として使う）
            direction.Normalize();
            //万有引力を計算
            f = G * m * M / (r * r);

            KeepDistance(r, direction);

            //万有引力を与える
            GetComponent<Rigidbody>().AddForce(f * direction, ForceMode.Force);
        }
    }

    //タネが画面外に行かないように塞ぐ壁
    void Wall()
    {
        tmp_pos.x = this.transform.position.x;
        tmp_pos.y = this.transform.position.y;
        tmp_pos.z = this.transform.position.z;
        //X軸
        if (tmp_pos.x > CameraController.right) tmp_pos.x = CameraController.right;
        else if (tmp_pos.x < CameraController.left) tmp_pos.x = CameraController.left;

        //Y軸
        if (tmp_pos.y > CameraController.top) tmp_pos.y = CameraController.top;
        else if (tmp_pos.y < CameraController.bottom) tmp_pos.y = CameraController.bottom;

        this.transform.position = tmp_pos;
    }

    // Update is called once per frame
    void Update()
    {
        GravityUpdate();

        pre_velocity = GetComponent<Rigidbody>().velocity;
        //Debug.Log(GetComponent<Rigidbody>().velocity);
    }
}
