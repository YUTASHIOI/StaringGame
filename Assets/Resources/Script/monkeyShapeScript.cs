using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyShapeScript : MonoBehaviour
{


    public SkinnedMeshRenderer faceMotion;

    [SerializeField, Range(0, 100)]
    //変形度合い（0.0 ～ 100.0）
    private int key_Q, key_W, key_E, key_R, key_T, key_Y, key_U, key_I, key_O, key_P,
                key_A, key_S, key_D, key_F, key_G, key_H, key_J, key_K, key_L,
                key_Z, key_X, key_C, key_V, key_B, key_N, key_M;

    [SerializeField, Range(0, 100)]
    //変形速度
    private int transSpeed;

    [SerializeField]
    private GameObject pMonkey;

    [SerializeField]
    private bool key_Q_Switch, key_W_Switch, key_E_Switch, key_R_Switch, key_T_Switch, key_Y_Switch, key_U_Switch, key_I_Switch;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gMonkey = Instantiate(pMonkey) as GameObject;
        faceMotion = gMonkey.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        //KeyInput();
        KeyInputSwitch();
        ShapeChange();
    }

    void ShapeChange()
    {
        faceMotion.SetBlendShapeWeight( 0, key_Q);          //右目閉じる
        faceMotion.SetBlendShapeWeight( 1, key_W);
        faceMotion.SetBlendShapeWeight( 2, key_E);
        faceMotion.SetBlendShapeWeight( 3, key_R);
        faceMotion.SetBlendShapeWeight( 4, key_T);
        faceMotion.SetBlendShapeWeight( 5, key_Y);
        faceMotion.SetBlendShapeWeight( 6, key_U);
        faceMotion.SetBlendShapeWeight( 7, key_I);
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



    //押し放し＝増減
    void KeyInput()
    {
        //Qキー
        if (Input.GetKey(KeyCode.Q))
        {
            key_Q = RatioUp(key_Q);
        }
        else
        {
            key_Q = RatioDown(key_Q);
        }

        //Wキー
        if (Input.GetKey(KeyCode.W))
        {
            key_W = RatioUp(key_W);
        }
        else
        {
            key_W = RatioDown(key_W);
        }

        //Eキー
        if (Input.GetKey(KeyCode.E))
        {
            key_E = RatioUp(key_E);
        }
        else
        {
            key_E = RatioDown(key_E);
        }

        //Rキー
        if (Input.GetKey(KeyCode.R))
        {
            key_R = RatioUp(key_R);
        }
        else
        {
            key_R = RatioDown(key_R);
        }

        //Tキー
        if (Input.GetKey(KeyCode.T))
        {
            key_T = RatioUp(key_T);
        }
        else
        {
            key_T = RatioDown(key_T);
        }

        //Yキー
        if (Input.GetKey(KeyCode.Y))
        {
            key_Y = RatioUp(key_Y);
        }
        else
        {
            key_Y = RatioDown(key_Y);
        }

        //Uキー
        if (Input.GetKey(KeyCode.U))
        {
            key_U = RatioUp(key_U);
        }
        else
        {
            key_U = RatioDown(key_U);
        }

        //Iキー
        if (Input.GetKey(KeyCode.I))
        {
            key_I = RatioUp(key_I);
        }
        else
        {
            key_I = RatioDown(key_I);
        }

        //Oキー
        if (Input.GetKey(KeyCode.O))
        {
            key_O = RatioUp(key_O);
        }
        else
        {
            key_O = RatioDown(key_O);
        }

        //Pキー
        if (Input.GetKey(KeyCode.P))
        {
            key_P = RatioUp(key_P);
        }
        else
        {
            key_P = RatioDown(key_P);
        }

        //Aキー
        if (Input.GetKey(KeyCode.A))
        {
            key_A = RatioUp(key_A);
        }
        else
        {
            key_A = RatioDown(key_A);
        }
    }
    
    //押してる間変化------------------------
    void KeyInputSwitch()
    {
        //Qキー
        if (Input.GetKey(KeyCode.Q))
        {
            key_Q_Switch = UpOrDownSwitch(key_Q, key_Q_Switch);
            key_Q = UpDown(key_Q, key_Q_Switch);
        }

        //Wキー
        if (Input.GetKey(KeyCode.W))
        {
            key_W_Switch = UpOrDownSwitch(key_W, key_W_Switch);
            key_W = UpDown(key_W, key_W_Switch);
        }

        //Eキー
        if (Input.GetKey(KeyCode.E))
        {
            key_E_Switch = UpOrDownSwitch(key_E, key_E_Switch);
            key_E = UpDown(key_E, key_E_Switch);
        }

        //Rキー
        if (Input.GetKey(KeyCode.R))
        {
            key_R_Switch = UpOrDownSwitch(key_R, key_R_Switch);
            key_R = UpDown(key_R, key_R_Switch);
        }

        //Tキー
        if (Input.GetKey(KeyCode.T))
        {
            key_T_Switch = UpOrDownSwitch(key_T, key_T_Switch);
            key_T = UpDown(key_T, key_T_Switch);
        }

        //Yキー
        if (Input.GetKey(KeyCode.Y))
        {
            key_Y_Switch = UpOrDownSwitch(key_Y, key_Y_Switch);
            key_Y = UpDown(key_Y, key_Y_Switch);
        }

        //Uキー
        if (Input.GetKey(KeyCode.U))
        {
            key_U_Switch = UpOrDownSwitch(key_U, key_U_Switch);
            key_U = UpDown(key_U, key_U_Switch);
        }

        //Iキー
        if (Input.GetKey(KeyCode.I))
        {
            key_I_Switch = UpOrDownSwitch(key_I, key_I_Switch);
            key_I = UpDown(key_I, key_I_Switch);
        }
    }

    int UpDown(int key, bool Switch)
    {
        if (Switch)
        {
            key = RatioUp(key);
        }
        else
        {
            key = RatioDown(key);
        }
        return key;
    }

    bool UpOrDownSwitch(int key, bool Switch)
    {
        if (Switch)
        {
            if (key >= 100)
            {
                return false;
            }
        }
        else
        {
            if(key <= 0)
            {
                return true;
            }
        }
        return Switch;
    }

    //--------------------------------------


    //変形値増加
    int RatioUp(int ratio)
    {
        ratio += transSpeed;
        if (ratio > 100)
        {
            ratio = 100;
        }
        return ratio;
    }

    //変形値減少
    int RatioDown(int ratio)
    {
        ratio -= transSpeed;
        if (ratio < 0)
        {
            ratio = 0;
        }
        return ratio;
    }
}
