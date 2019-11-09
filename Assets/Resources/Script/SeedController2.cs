using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController2 : MonoBehaviour
{
    Vector3 down = new Vector3(0.0f, -0.8f, 0.0f);

    private float UNIVERSAL_GRAVITATION = 6.67E-5f;

    public GameObject sun;
    public float initVelocityY;
    private float f;    //万有引力
    private float m;    //惑星の質量
    private float M;    //太陽の質量
    private float r;    //太陽と惑星の距離
    private float G = 6.67E-5f;    //万有引力定数(通常の1000000倍)
    private bool gravitySwitch = false;

    Vector3 Center_Pos;
    Vector3 side1;
    Vector3 side2;
    int gravityTimer = 0;

    void Start()
    {
        sun = GameObject.Find("SUN");
        Center_Pos = sun.GetComponent<Transform>().position;
        //惑星に初速を与える
        Vector3 initVelocity = new Vector3(0f, -initVelocityY, 0f); ;
        GetComponent<Rigidbody>().velocity = initVelocity;
        //惑星と太陽の質量を取得しておく
        m = GetComponent<Rigidbody>().mass;
        M = sun.GetComponent<Rigidbody>().mass;
    }

    void FixedUpdate()
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

    private void OnCollisionEnter(Collision collision)
    {
        gravitySwitch = false;
        gravityTimer = -1000;
    }

    //一定のルートで周回
    void KeepDistance(float dis, Vector3 direction)
    {
        if (dis < 4.0f)
        {
            GetComponent<Rigidbody>().AddForce(-f * (4.0f/dis) * direction, ForceMode.Force);
            //G = (UNIVERSAL_GRAVITATION / 1000) * dis * 200;
        }
        else if(dis > 13.0f)
        {
            GetComponent<Rigidbody>().AddForce((dis/13) * f * direction, ForceMode.Force);
            //G = UNIVERSAL_GRAVITATION * dis/10;
        }
        else
        {
            G = UNIVERSAL_GRAVITATION;
        }
    }
}
