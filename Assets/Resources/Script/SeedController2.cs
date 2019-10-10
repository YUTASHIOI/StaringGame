using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController2 : MonoBehaviour
{
    //Vector3 Center_Pos = new Vector3(0.0f, 0.0f, 0.0f);
    //
    //public Rigidbody rb;
    Vector3 down = new Vector3(0.0f, -0.8f, 0.0f);
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    rb.AddForce(down, ForceMode.Impulse);
    //}

    //Vector3 side1;
    //Vector3 side2;
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    //Vector3 distance = Center_Pos - this.transform.position;
    //    //float magni = distance.sqrMagnitude;
    //    //Debug.Log("magni:" + magni);
    //    side1 = Center_Pos - this.transform.position;
    //    side2 = new Vector3(Center_Pos.x, Center_Pos.y, this.transform.position.z) - this.transform.position;
    //    rb.AddForce(Vector3.Cross(side1, side2)/50, ForceMode.Force);
    //}

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
        //Debug.Log("Y:"+initVelocity.y);
        if (GetComponent<Transform>().position.y < -2.7f && gravitySwitch == false)
        {
            gravitySwitch = true;
            side1 = Center_Pos - this.transform.position;
            side2 = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f) - this.transform.position;
            Vector3 initVelocity = Vector3.Cross(side1, side2).normalized * initVelocityY;
            Debug.Log("1:" + side1);
            Debug.Log("2:" + side2);
            GetComponent<Rigidbody>().velocity = initVelocity;
            Debug.Log("Y:" + initVelocity);
            //GetComponent<Rigidbody>().velocity = new Vector3(initVelocityY / 2f, -initVelocityY / 2f, 0f); ;
        }
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
            //万有引力を与える
            GetComponent<Rigidbody>().AddForce(f * direction, ForceMode.Force);
        }
    }
}
