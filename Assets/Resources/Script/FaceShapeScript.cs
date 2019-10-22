using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceShapeScript : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        faceMotion = Face.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        JoypadInputSwitch();
        ShapeChange();
    }
    //変形が戻っている最中にはキー入力が終わっているので同時変形はまだ発生する。キーの入力可否ではなく、変形の可否で入力制限を入れるように変更が必要
    void ShapeChange()
    {
        if (button_L1 == 0) {
            faceMotion.SetBlendShapeWeight(0, (float)button_L2);               //右目閉じる
        }
        if (button_L2 == 0)
        {
            faceMotion.SetBlendShapeWeight(12, (float)button_L1);               //右目大開き
        }

        if (button_R1 == 0)
        {
            faceMotion.SetBlendShapeWeight(1, (float)button_R2);               //左目閉じる
        }
        if (button_R2 == 0)
        {
            faceMotion.SetBlendShapeWeight(13, (float)button_R1);               //左目大開き
        }

        if (button_Cursor_Right == 0 && button_Cursor_Up == 0)
        {
            faceMotion.SetBlendShapeWeight(2, (float)button_Share);            //右眉上げる
        }
        if (button_Share == 0 && button_Cursor_Up == 0)
        {
            faceMotion.SetBlendShapeWeight(8, (float)button_Cursor_Right);     //右眉困り顔
        }
        if (button_Share == 0 && button_Cursor_Right == 0)
        {
            faceMotion.SetBlendShapeWeight(10, (float)button_Cursor_Up);        //右眉怒り顔
        }

        if (button_Square == 0 && button_Triangle == 0)
        {
            faceMotion.SetBlendShapeWeight(3, (float)button_Option);           //左眉上げる
        }
        if (button_Option == 0 && button_Triangle == 0)
        {
            faceMotion.SetBlendShapeWeight(9, (float)button_Square);           //左眉困り顔
        }
        if (button_Option == 0 && button_Square == 0)
        {
            faceMotion.SetBlendShapeWeight(11, (float)button_Triangle);         //左眉怒り顔
        }

        if (button_Cursor_Left == 0)
        {
            faceMotion.SetBlendShapeWeight(4, (float)button_Cursor_Down);      //右口角上げる
        }
        if (button_Cursor_Down == 0)
        {
            faceMotion.SetBlendShapeWeight(6, (float)button_Cursor_Left);      //右口角下げる
        }

        if (button_Cirle == 0)
        {
            faceMotion.SetBlendShapeWeight(5, (float)button_Cross);            //左口角上げる
        }
        if (button_Cross == 0)
        {
            faceMotion.SetBlendShapeWeight(7, (float)button_Cirle);            //左口角下げる
        }

        if (button_Cursor_Down == 0 && button_Cursor_Left == 0 && button_Cross == 0 && button_Cirle == 0)
        {
            faceMotion.SetBlendShapeWeight(15, (float)button_PS);               //口尖らす
        }

        faceMotion.SetBlendShapeWeight(14, (float)button_TrackPad);         //鼻開く

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
            button_Cirle = RatioUp(button_Cirle);
        }
        else
        {
            button_Cirle = RatioDown(button_Cirle);
        }
        
        if (Input.GetButton("×ボタン"))
        {
            button_Cross = RatioUp(button_Cross);
        }
        else
        {
            button_Cross = RatioDown(button_Cross);
        }

        if (Input.GetButton("△ボタン"))
        {
            button_Triangle = RatioUp(button_Triangle);
        }
        else
        {
            button_Triangle = RatioDown(button_Triangle);
        }

        if (Input.GetButton("□ボタン"))
        {
            button_Square = RatioUp(button_Square);
        }
        else
        {
            button_Square = RatioDown(button_Square);
        }

        if (Input.GetButton("L1ボタン"))
        {
            button_L1 = RatioUp(button_L1);
        }
        else
        {
            button_L1 = RatioDown(button_L1);
        }

        if (Input.GetButton("R1ボタン"))
        {
            button_R1 = RatioUp(button_R1);
        }
        else
        {
            button_R1 = RatioDown(button_R1);
        }

        if (Input.GetButton("Shareボタン"))
        {
            button_Share = RatioUp(button_Share);
        }
        else
        {
            button_Share = RatioDown(button_Share);
        }

        if (Input.GetButton("Option"))
        {
            button_Option = RatioUp(button_Option);
        }
        else
        {
            button_Option = RatioDown(button_Option);
        }

        if (Input.GetButton("PSボタン"))
        {
            button_PS = RatioUp(button_PS);
        }
        else
        {
            button_PS = RatioDown(button_PS);
        }

        if (Input.GetButton("トラックパッド押し込み"))
        {
            button_TrackPad = RatioUp(button_TrackPad);
        }
        else
        {
            button_TrackPad = RatioDown(button_TrackPad);
        }
        //if (Input.GetButton("L2（デジタル）"))
        //{
        //    key_U_Switch = UpOrDownSwitch(key_U, key_U_Switch);
        //    key_U = UpDown(key_U, key_U_Switch);
        //}
        //
        //if (Input.GetButton("R2（デジタル）"))
        //{
        //    button_Cirle_Switch = UpOrDownSwitch(button_Cirle, button_Cirle_Switch);
        //    button_Cirle = UpDown(button_Cirle, button_Cirle_Switch);
        //}

        if (Input.GetAxis("十字キー左右") >= 0.5)
        {
            button_Cursor_Right = RatioUp(button_Cursor_Right);
        }
        else
        {
            button_Cursor_Right = RatioDown(button_Cursor_Right);
        }

        if (Input.GetAxis("十字キー左右") <= -0.5)
        {
            button_Cursor_Left = RatioUp(button_Cursor_Left);
        }
        else
        {
            button_Cursor_Left = RatioDown(button_Cursor_Left);
        }

        if (Input.GetAxis("十字キー上下") >= 0.5)
        {
            button_Cursor_Up = RatioUp(button_Cursor_Up);
        }
        else
        {
            button_Cursor_Up = RatioDown(button_Cursor_Up);
        }

        if (Input.GetAxis("十字キー上下") <= -0.5)
        {
            button_Cursor_Down = RatioUp(button_Cursor_Down);
        }
        else
        {
            button_Cursor_Down = RatioDown(button_Cursor_Down);
        }
        button_L2 = (int)(Input.GetAxis("L2（アナログ）") * 50.0f) + 50;
        button_R2 = (int)(Input.GetAxis("R2（アナログ）") * 50.0f) + 50;
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
