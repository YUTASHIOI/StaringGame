using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyShapeScript : MonoBehaviour
{


    public SkinnedMeshRenderer ref_MONKEY_DEF;
    public float ratio_1 = 0.0f;    //変形度合い（0.0 ～ 100.0）
    public float ratio_2 = 0.0f;    //変形度合い（0.0 ～ 100.0）
    public float ratio_3 = 0.0f;    //変形度合い（0.0 ～ 100.0）
    public float ratio_4 = 0.0f;    //変形度合い（0.0 ～ 100.0）
    public float ratio_5 = 0.0f;    //変形度合い（0.0 ～ 100.0）

    [SerializeField]
    GameObject pMonkey;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gMonkey = Instantiate(pMonkey) as GameObject;
        ref_MONKEY_DEF = gMonkey.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        KeyInput();
        ShapeChange();
    }

    void ShapeChange()
    {
        ref_MONKEY_DEF.SetBlendShapeWeight(0, ratio_1);
        //ref_MONKEY_DEF.SetBlendShapeWeight(1, ratio_2);
        //ref_MONKEY_DEF.SetBlendShapeWeight(2, ratio_3);
        //ref_MONKEY_DEF.SetBlendShapeWeight(3, ratio_4);
        //ref_MONKEY_DEF.SetBlendShapeWeight(4, ratio_5);
    }

    void KeyInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ratio_1 = RatioUp(ratio_1);
        }
        else
        {
            ratio_1 = RatioDown(ratio_1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            ratio_2 = RatioUp(ratio_2);
        }
        else
        {
            ratio_2 = RatioDown(ratio_2);
        }

        if (Input.GetKey(KeyCode.O))
        {
            ratio_3 = RatioUp(ratio_3);
        }
        else
        {
            ratio_3 = RatioDown(ratio_3);
        }

        if (Input.GetKey(KeyCode.P))
        {
            ratio_4 = RatioUp(ratio_4);
        }
        else
        {
            ratio_4 = RatioDown(ratio_4);
        }

        if (Input.GetKey(KeyCode.A))
        {
            ratio_5 = RatioUp(ratio_5);
        }
        else
        {
            ratio_5 = RatioDown(ratio_5);
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
