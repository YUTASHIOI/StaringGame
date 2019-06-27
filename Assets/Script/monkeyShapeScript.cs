using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyShapeScript : MonoBehaviour
{

    public SkinnedMeshRenderer ref_MONKEY_DEF;
    public float ratio_SMR_EYE = 85.0f;       //
    public float ratio_SMR_MTH = 85.0f;       //
    public float ratio_ANG_MTH = 0.0f;        //
    public float ratio_BIK_EYE = 0.0f;        //

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
        ref_MONKEY_DEF.SetBlendShapeWeight(0, ratio_SMR_EYE);
        ref_MONKEY_DEF.SetBlendShapeWeight(1, ratio_SMR_MTH);
        ref_MONKEY_DEF.SetBlendShapeWeight(2, ratio_ANG_MTH);
        ref_MONKEY_DEF.SetBlendShapeWeight(3, ratio_BIK_EYE);
    }

    void KeyInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ratio_SMR_EYE = RatioUp(ratio_SMR_EYE);
        }
        else
        {
            ratio_SMR_EYE = RatioDown(ratio_SMR_EYE);
        }

        if (Input.GetKey(KeyCode.W))
        {
            ratio_SMR_MTH = RatioUp(ratio_SMR_MTH);
        }
        else
        {
            ratio_SMR_MTH = RatioDown(ratio_SMR_MTH);
        }

        if (Input.GetKey(KeyCode.O))
        {
            ratio_ANG_MTH = RatioUp(ratio_ANG_MTH);
        }
        else
        {
            ratio_ANG_MTH = RatioDown(ratio_ANG_MTH);
        }

        if (Input.GetKey(KeyCode.P))
        {
            ratio_BIK_EYE = RatioUp(ratio_BIK_EYE);
        }
        else
        {
            ratio_BIK_EYE = RatioDown(ratio_BIK_EYE);
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
