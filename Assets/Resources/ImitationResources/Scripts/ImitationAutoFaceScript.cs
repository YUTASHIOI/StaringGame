using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitationAutoFaceScript : MonoBehaviour
{
    public SkinnedMeshRenderer faceMotion;

    [SerializeField, Range(0, 100)]
    //変形度合い（0.0 ～ 100.0）
    public int button_L2, button_R2, button_L1, button_R1, button_Cursor_Down, button_Cross, button_Cursor_Left, button_Cirle, button_Cursor_Right, button_Square,
                button_Cursor_Up, button_Triangle, button_Share, button_Option, button_PS, button_TrackPad, key_J, key_K, key_L,
                key_Z, key_X, key_C, key_V, key_B, key_N, key_M;

    [SerializeField, Range(0, 100)]
    //変形速度
    private int transSpeed;

    [SerializeField]
    private GameObject Face;

    float timeOut = 10f;
    float timeElapsed = 0f;
    //float random = 0f;

    // Start is called before the first frame update
    void Start()
    {
        faceMotion = Face.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        
        timeElapsed += Time.deltaTime;
        //Debug.Log(timeElapsed);
        if (timeElapsed >= timeOut)
        {
            Debug.LogFormat("{0}秒経過", timeOut);
            for (int i = 0; i < 16; i++)
            {
                faceMotion.SetBlendShapeWeight(i, 0);
            }
            ShapeChange();
            timeElapsed = 0.0f;
        }


    }

    void ShapeChange()
    {
        if (Random.value < 0.5f)
        {
            //Debug.Log(Random.value);
            faceMotion.SetBlendShapeWeight(12, 0);
            faceMotion.SetBlendShapeWeight(0, 100);               //右目閉じる
        }
        if (Random.value > 0.5f)
        {
            //Debug.Log(Random.value);
            faceMotion.SetBlendShapeWeight(0, 0);
            faceMotion.SetBlendShapeWeight(12,0);               //右目大開き
        }

        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(13, 0);
            faceMotion.SetBlendShapeWeight(1, 100);               //左目閉じる
        }
        if (Random.value > 0.5f)
        {
            faceMotion.SetBlendShapeWeight(1, 0);
            faceMotion.SetBlendShapeWeight(13, 100);               //左目大開き
        }

        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(8, 0);
            faceMotion.SetBlendShapeWeight(10, 0);
            faceMotion.SetBlendShapeWeight(2, 100);            //右眉上げる
        }
        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(2, 0);
            faceMotion.SetBlendShapeWeight(10, 0);
            faceMotion.SetBlendShapeWeight(8, 100);     //右眉困り顔
        }
        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(2, 0);
            faceMotion.SetBlendShapeWeight(8, 0);
            faceMotion.SetBlendShapeWeight(10, 100);        //右眉怒り顔
        }

        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(9, 0);
            faceMotion.SetBlendShapeWeight(11, 0);
            faceMotion.SetBlendShapeWeight(3, 100);           //左眉上げる
        }
        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(3, 0);
            faceMotion.SetBlendShapeWeight(11, 0);
            faceMotion.SetBlendShapeWeight(9, 100);           //左眉困り顔
        }
        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(3, 0);
            faceMotion.SetBlendShapeWeight(9, 0);
            faceMotion.SetBlendShapeWeight(11, 100);         //左眉怒り顔
        }

        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(6, 0);
            faceMotion.SetBlendShapeWeight(15, 0);
            faceMotion.SetBlendShapeWeight(4, 100);      //右口角上げる
        }
        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(4, 0);
            faceMotion.SetBlendShapeWeight(15, 0);
            faceMotion.SetBlendShapeWeight(6, 100);      //右口角下げる
        }

        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(7, 0);
            faceMotion.SetBlendShapeWeight(15, 0);
            faceMotion.SetBlendShapeWeight(5, 100);            //左口角上げる
        }
        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(5, 0);
            faceMotion.SetBlendShapeWeight(15, 0);
            faceMotion.SetBlendShapeWeight(7, 100);            //左口角下げる
        }

        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(4, 0);
            faceMotion.SetBlendShapeWeight(5, 0);
            faceMotion.SetBlendShapeWeight(6, 0);
            faceMotion.SetBlendShapeWeight(7, 0);
            faceMotion.SetBlendShapeWeight(15, 100);               //口尖らす
        }

        if (Random.value < 0.5f)
        {
            faceMotion.SetBlendShapeWeight(14, (float)button_TrackPad);         //鼻開く
        }

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
            if (key <= 0)
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
        return Mathf.Min(100, ratio + transSpeed);
    }

    //変形値減少
    int RatioDown(int ratio)
    {
        return Mathf.Max(0, ratio - transSpeed);
    }
}
