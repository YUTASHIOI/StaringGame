using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDirector: MonoBehaviour
{
    public enum INPUT_TYPE
    {
        L1,
        L2,
        R1,
        R2,
        SHARE,
        CURSOR_RIGHT,
        CURSOR_LEFT,
        CURSOR_UP,
        CURSOR_DOWN,
        OPTION,
        SQURE,
        TRIANGLE,
        CIRCLE,
        CROSS,
        PS,
        TRACK_PAD,
    }

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float GetInput(INPUT_TYPE inputType)
    {
        switch (inputType)
        {
            case INPUT_TYPE.L1:
                return GetButtonL1() ? 1f : 0f;
            case INPUT_TYPE.L2:
                return GetButtonL2();
            case INPUT_TYPE.R1:
                return GetButtonR1() ? 1f : 0f;
            case INPUT_TYPE.R2:
                return GetButtonR2();
            case INPUT_TYPE.SHARE:
                return GetButtonShare() ? 1f : 0f;

            case INPUT_TYPE.CURSOR_RIGHT:
                return GetButtonCursorHorizontal() == 1f ? 1f : 0;
            case INPUT_TYPE.CURSOR_LEFT:
                return GetButtonCursorHorizontal() == -1f ? 1f : 0;
            case INPUT_TYPE.CURSOR_UP:
                return GetButtonCursorVertical() == 1f ? 1f: 0;
            case INPUT_TYPE.CURSOR_DOWN:
                return GetButtonCursorVertical() == -1f ? 1f: 0;

            case INPUT_TYPE.OPTION:
                return GetButtonOption() ? 1f : 0f;
            case INPUT_TYPE.SQURE:
                return GetButtonSquare() ? 1f : 0f;
            case INPUT_TYPE.TRIANGLE:
                return GetButtonTriangle() ? 1f : 0f;
            case INPUT_TYPE.CIRCLE:
                return GetButtonCircle() ? 1f : 0f;
            case INPUT_TYPE.CROSS:
                return GetButtonCross() ? 1f : 0f;
            case INPUT_TYPE.PS:
                return GetButtonPS() ? 1f : 0f;
            case INPUT_TYPE.TRACK_PAD:
                return GetButtonTrackPad() ? 1f : 0f;
            default:
                return 0f;
        }
    }

    public static bool GetButtonL1()
    {
        return Input.GetButton("L1ボタン");
    }

    public static float GetButtonL2()
    {
        return Input.GetAxis("L2（アナログ）");
    }

    public static bool GetButtonR1()
    {
        return Input.GetButton("R1ボタン");
    }

    public static float GetButtonR2()
    {
        return Input.GetAxis("R2（アナログ）");
    }

    public static bool GetButtonShare()
    {
        return Input.GetButton("Shareボタン");
    }

    public static float GetButtonCursorHorizontal()
    {
        return Input.GetAxis("十字キー左右");
    }

    public static float GetButtonCursorVertical()
    {
        return Input.GetAxis("十字キー上下");
    }

    public static bool GetButtonOption()
    {
        return Input.GetButton("Option");
    }

    public static bool GetButtonSquare()
    {
        return Input.GetButton("□ボタン");
    }

    public static bool GetButtonTriangle()
    {
        return Input.GetButton("△ボタン");
    }

    public static bool GetButtonCross()
    {
        return Input.GetButton("×ボタン");
    }

    public static bool GetButtonCircle()
    {
        return Input.GetButton("〇ボタン");
    }

    public static bool GetButtonPS()
    {
        return Input.GetButton("PSボタン");
    }

    public static bool GetButtonTrackPad()
    {
        return Input.GetButton("トラックパッド押し込み");
    }
}
