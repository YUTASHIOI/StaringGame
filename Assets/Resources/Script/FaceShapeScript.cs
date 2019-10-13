using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceShapeScript : MonoBehaviour
{


    public SkinnedMeshRenderer faceMotion;

    [SerializeField, Range(0, 100)]
    //変形度合い（0.0 ～ 100.0）
    public int key_Q, key_W, key_E, key_R, key_T, key_Y, key_U, key_I, key_O, key_P,
                key_A, key_S, key_D, key_F, key_G, key_H, key_J, key_K, key_L,
                key_Z, key_X, key_C, key_V, key_B, key_N, key_M;

    [SerializeField, Range(0, 100)]
    //変形速度
    private int transSpeed;

    [SerializeField]
    private GameObject pFace;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gFace = Instantiate(pFace) as GameObject;
        faceMotion = gFace.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        JoypadInputSwitch();
        ShapeChange();
    }

    void ShapeChange()
    {
        faceMotion.SetBlendShapeWeight( 0, (float)key_Q);          //右目閉じる
        faceMotion.SetBlendShapeWeight( 1, (float)key_W);          //左目閉じる
        faceMotion.SetBlendShapeWeight( 2, (float)key_E);          //右眉上げる
        faceMotion.SetBlendShapeWeight( 3, (float)key_R);          //左眉上げる
        faceMotion.SetBlendShapeWeight( 4, (float)key_T);          //右口角上げる
        faceMotion.SetBlendShapeWeight( 5, (float)key_Y);          //左口角上げる
        faceMotion.SetBlendShapeWeight( 6, (float)key_U);          //右口角下げる
        faceMotion.SetBlendShapeWeight( 7, (float)key_I);          //左口角下げる
        faceMotion.SetBlendShapeWeight( 8, (float)key_O);          //右眉困り顔
        faceMotion.SetBlendShapeWeight( 9, (float)key_P);          //左眉困り顔
        faceMotion.SetBlendShapeWeight(10, (float)key_A);          //右眉怒り顔
        faceMotion.SetBlendShapeWeight(11, (float)key_S);          //左眉怒り顔
        faceMotion.SetBlendShapeWeight(12, (float)key_D);          //右目大開き
        faceMotion.SetBlendShapeWeight(13, (float)key_F);          //左目大開き
        faceMotion.SetBlendShapeWeight(14, (float)key_G);          //鼻開く
        faceMotion.SetBlendShapeWeight(15, (float)key_H);          //口尖らす
        //faceMotion.SetBlendShapeWeight(16, (float)key_J);
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
    //ジョイパッドで操作
    void JoypadInputSwitch()
    {
        if (Input.GetButton("〇ボタン"))
        {
            key_I = RatioUp(key_I);
        }
        else
        {
            key_I = RatioDown(key_I);
        }
        
        if (Input.GetButton("×ボタン"))
        {
            key_Y = RatioUp(key_Y);
        }
        else
        {
            key_Y = RatioDown(key_Y);
        }

        if (Input.GetButton("△ボタン"))
        {
            key_S = RatioUp(key_S);
        }
        else
        {
            key_S = RatioDown(key_S);
        }

        if (Input.GetButton("□ボタン"))
        {
            key_P = RatioUp(key_P);
        }
        else
        {
            key_P = RatioDown(key_P);
        }

        if (Input.GetButton("L1ボタン"))
        {
            key_E = RatioUp(key_E);
        }
        else
        {
            key_E = RatioDown(key_E);
        }

        if (Input.GetButton("R1ボタン"))
        {
            key_R = RatioUp(key_R);
        }
        else
        {
            key_R = RatioDown(key_R);
        }

        if (Input.GetButton("Shareボタン"))
        {
            key_D = RatioUp(key_D);
        }
        else
        {
            key_D = RatioDown(key_D);
        }

        if (Input.GetButton("Option"))
        {
            key_F = RatioUp(key_F);
        }
        else
        {
            key_F = RatioDown(key_F);
        }

        if (Input.GetButton("PSボタン"))
        {
            key_G = RatioUp(key_G);
        }
        else
        {
            key_G = RatioDown(key_G);
        }

        if (Input.GetButton("トラックパッド押し込み"))
        {
            key_H = RatioUp(key_H);
        }
        else
        {
            key_H = RatioDown(key_H);
        }
        //if (Input.GetButton("L2（デジタル）"))
        //{
        //    key_U_Switch = UpOrDownSwitch(key_U, key_U_Switch);
        //    key_U = UpDown(key_U, key_U_Switch);
        //}
        //
        //if (Input.GetButton("R2（デジタル）"))
        //{
        //    key_I_Switch = UpOrDownSwitch(key_I, key_I_Switch);
        //    key_I = UpDown(key_I, key_I_Switch);
        //}

        if (Input.GetAxis("十字キー左右") >= 0.5)
        {
            key_O = RatioUp(key_O);
        }
        else
        {
            key_O = RatioDown(key_O);
        }

        if (Input.GetAxis("十字キー左右") <= -0.5)
        {
            key_U = RatioUp(key_U);
        }
        else
        {
            key_U = RatioDown(key_U);
        }

        if (Input.GetAxis("十字キー上下") >= 0.5)
        {
            key_A = RatioUp(key_A);
        }
        else
        {
            key_A = RatioDown(key_A);
        }

        if (Input.GetAxis("十字キー上下") <= -0.5)
        {
            key_T = RatioUp(key_T);
        }
        else
        {
            key_T = RatioDown(key_T);
        }

        Debug.Log(Input.GetAxis("十字キー上下"));

        key_Q = (int)(Input.GetAxis("L2（アナログ）") * 50.0f) + 50;
        key_W = (int)(Input.GetAxis("R2（アナログ）") * 50.0f) + 50;
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
