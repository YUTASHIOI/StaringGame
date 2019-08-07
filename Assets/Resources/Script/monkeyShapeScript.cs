using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyShapeScript : MonoBehaviour
{


    public SkinnedMeshRenderer faceMotion;
    //変形度合い（0.0 ～ 100.0）
    public float key_Q, key_W, key_E, key_R, key_T, key_Y, key_U, key_I, key_O, key_P;
    public float key_A, key_S, key_D, key_F, key_G, key_H, key_J, key_K, key_L;
    public float key_Z, key_X, key_C, key_V, key_B, key_N, key_M;

    [SerializeField]
    GameObject pMonkey;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gMonkey = Instantiate(pMonkey) as GameObject;
        faceMotion = gMonkey.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        KeyInput();
        ShapeChange();
    }

    void ShapeChange()
    {
        faceMotion.SetBlendShapeWeight( 0, key_Q);
        //faceMotion.SetBlendShapeWeight( 1, key_W);
        //faceMotion.SetBlendShapeWeight( 2, key_E);
        //faceMotion.SetBlendShapeWeight( 3, key_R);
        //faceMotion.SetBlendShapeWeight( 4, key_T);
        //faceMotion.SetBlendShapeWeight( 5, key_Y);
        //faceMotion.SetBlendShapeWeight( 6, key_U);
        //faceMotion.SetBlendShapeWeight( 7, key_I);
        //faceMotion.SetBlendShapeWeight( 8, key_O);
        //faceMotion.SetBlendShapeWeight( 9, key_P);
        //faceMotion.SetBlendShapeWeight(10, key_A);
        //faceMotion.SetBlendShapeWeight(11, key_S);
        //faceMotion.SetBlendShapeWeight(12, key_D);
        //faceMotion.SetBlendShapeWeight(13, key_F);
        //faceMotion.SetBlendShapeWeight(14, key_G);
        //faceMotion.SetBlendShapeWeight(15, key_H);
        //faceMotion.SetBlendShapeWeight(16, key_J);
        //faceMotion.SetBlendShapeWeight(17, key_K);
        //faceMotion.SetBlendShapeWeight(18, key_L);
        //faceMotion.SetBlendShapeWeight(19, key_Z);
        //faceMotion.SetBlendShapeWeight(20, key_X);
        //faceMotion.SetBlendShapeWeight(21, key_C);
        //faceMotion.SetBlendShapeWeight(22, key_V);
        //faceMotion.SetBlendShapeWeight(23, key_B);
        //faceMotion.SetBlendShapeWeight(24, key_N);
        //faceMotion.SetBlendShapeWeight(25, key_M);
    }

    void KeyInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            key_Q = RatioUp(key_Q);
        }
        else
        {
            key_Q = RatioDown(key_Q);
        }

        if (Input.GetKey(KeyCode.W))
        {
            key_W = RatioUp(key_W);
        }
        else
        {
            key_W = RatioDown(key_W);
        }

        if (Input.GetKey(KeyCode.O))
        {
            key_O = RatioUp(key_O);
        }
        else
        {
            key_O = RatioDown(key_O);
        }

        if (Input.GetKey(KeyCode.P))
        {
            key_P = RatioUp(key_P);
        }
        else
        {
            key_P = RatioDown(key_P);
        }

        if (Input.GetKey(KeyCode.A))
        {
            key_A = RatioUp(key_A);
        }
        else
        {
            key_A = RatioDown(key_A);
        }
    }

    float RatioUp(float ratio)
    {
        ratio += 5.0f;
        if (ratio > 100.0f)
        {
            ratio = 100.0f;
        }
        return ratio;
    }

    float RatioDown(float ratio)
    {
        ratio -= 10.0f;
        if (ratio < 0.0f)
        {
            ratio = 0.0f;
        }
        return ratio;
    }
}
