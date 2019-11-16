using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceShapeScript : MonoBehaviour
{
    /// <summary>
    /// 顔の動き
    /// </summary>
    public SkinnedMeshRenderer faceMotion;

    /*
    [SerializeField, Range(0, 100)]
    //変形度合い（0.0 ～ 100.0）
    public int button_L2, button_R2, button_L1, button_R1, button_Cursor_Down, button_Cross, button_Cursor_Left, button_Cirle, button_Cursor_Right, button_Square,
                button_Cursor_Up, button_Triangle, button_Share, button_Option, button_PS, button_TrackPad, key_J, key_K, key_L,
                key_Z, key_X, key_C, key_V, key_B, key_N, key_M;
    */


    [SerializeField, Range(0, 100)]
    //変形速度
    private int transSpeed;

    [SerializeField]
    private GameObject Face;

    private enum FACE_KEY
    {
        RIGHT_EYE_CLOSE = 0,
        LEFT_EYE_CLOSE = 1,

        RIGHT_BROW_UP = 2,
        LEFT_BROW_UP = 3,

        RIGHT_MOUTH_CORNER_UP = 4,
        LEFT_MOUTH_CORNER_UP = 5,

        RIGHT_MOUTH_CORNER_DOWN = 6,
        LEFT_MOUTH_CORNER_DOWN = 7,

        RIGHT_BROW_SAD = 8,
        LEFT_BROW_SAD = 9,
        RIGHT_BROW_ANGRY = 10,
        LEFT_BROW_ANGRY = 11,

        RIGHT_EYE_OPEN = 12,
        LEFT_EYE_OPEN = 13,

        OPEN_NOSE = 14,
        PUCKER_MOUTH = 15,

        COUNT,
    }

    [SerializeField, Range(0, 100)]
    public int[] faceRatio = new int[(int)FACE_KEY.COUNT];

    List<FACE_KEY>[] dependencyList = new List<FACE_KEY>[(int)FACE_KEY.COUNT];
    InputDirector.INPUT_TYPE[] faceInputKeyTable = new InputDirector.INPUT_TYPE[(int)FACE_KEY.COUNT];

    struct FaceInfo
    {
        public FACE_KEY faceKey;
        public List<FACE_KEY> dependencyList;
        public InputDirector.INPUT_TYPE inputType;
    }

    List<FaceInfo> analogFaceInfoList;
    List<FaceInfo> degitalFaceInfoList;


    // Start is called before the first frame update
    void Start()
    {
        faceMotion = Face.GetComponent<SkinnedMeshRenderer>();


        // アナログ
        analogFaceInfoList = new List<FaceInfo>
        {
            // 目
            new FaceInfo
            {
                faceKey = FACE_KEY.RIGHT_EYE_CLOSE,
                dependencyList = new List<FACE_KEY> { FACE_KEY.RIGHT_EYE_OPEN },
                inputType = InputDirector.INPUT_TYPE.L2,
            },

            new FaceInfo
            {
                faceKey = FACE_KEY.LEFT_EYE_CLOSE,
                dependencyList = new List<FACE_KEY> { FACE_KEY.LEFT_EYE_OPEN },
                inputType = InputDirector.INPUT_TYPE.R2,
            },
        };

        // デジタル
        degitalFaceInfoList = new List<FaceInfo>
        {
            // 目
            new FaceInfo
            {
                faceKey = FACE_KEY.RIGHT_EYE_OPEN,
                dependencyList = new List<FACE_KEY> { FACE_KEY.LEFT_EYE_CLOSE },
                inputType = InputDirector.INPUT_TYPE.L1,
            },

            new FaceInfo
            {
                faceKey = FACE_KEY.LEFT_EYE_OPEN,
                dependencyList = new List<FACE_KEY> { FACE_KEY.LEFT_EYE_CLOSE},
                inputType = InputDirector.INPUT_TYPE.R1,
            },

            // 口
            new FaceInfo
            {
                faceKey = FACE_KEY.RIGHT_MOUTH_CORNER_DOWN,
                dependencyList = new List<FACE_KEY> {  FACE_KEY.RIGHT_MOUTH_CORNER_UP, FACE_KEY.PUCKER_MOUTH },
                inputType = InputDirector.INPUT_TYPE.CURSOR_DOWN,
            },

            new FaceInfo
            {
                faceKey = FACE_KEY.RIGHT_MOUTH_CORNER_UP,
                dependencyList = new List<FACE_KEY> { FACE_KEY.RIGHT_MOUTH_CORNER_DOWN, FACE_KEY.PUCKER_MOUTH },
                inputType = InputDirector.INPUT_TYPE.CURSOR_LEFT,
            },

            new FaceInfo
            {
                faceKey = FACE_KEY.LEFT_MOUTH_CORNER_UP,
                dependencyList = new List<FACE_KEY> { FACE_KEY.LEFT_MOUTH_CORNER_DOWN, FACE_KEY.PUCKER_MOUTH },
                inputType = InputDirector.INPUT_TYPE.CIRCLE,
            },

            new FaceInfo
            {
                faceKey = FACE_KEY.LEFT_MOUTH_CORNER_DOWN,
                dependencyList = new List<FACE_KEY> { FACE_KEY.LEFT_MOUTH_CORNER_UP, FACE_KEY.PUCKER_MOUTH },
                inputType = InputDirector.INPUT_TYPE.CROSS,
            },

            new FaceInfo
            {
                faceKey = FACE_KEY.PUCKER_MOUTH,
                dependencyList = new List<FACE_KEY>{ FACE_KEY.RIGHT_MOUTH_CORNER_UP, FACE_KEY.RIGHT_MOUTH_CORNER_DOWN, FACE_KEY.LEFT_MOUTH_CORNER_DOWN, FACE_KEY.PUCKER_MOUTH },
                inputType = InputDirector.INPUT_TYPE.PS,
            },

            // 眉
            new FaceInfo
            {
                faceKey = FACE_KEY.RIGHT_BROW_UP,
                dependencyList = new List<FACE_KEY>{ FACE_KEY.RIGHT_BROW_ANGRY, FACE_KEY.RIGHT_BROW_SAD },
                inputType = InputDirector.INPUT_TYPE.SHARE,
            },
            new FaceInfo
            {
                faceKey = FACE_KEY.RIGHT_BROW_SAD,
                dependencyList = new List<FACE_KEY>{ FACE_KEY.RIGHT_BROW_ANGRY, FACE_KEY.RIGHT_BROW_UP },
                inputType = InputDirector.INPUT_TYPE.CURSOR_RIGHT,
            },
            new FaceInfo
            {
                faceKey = FACE_KEY.RIGHT_BROW_ANGRY,
                dependencyList = new List<FACE_KEY>{  FACE_KEY.RIGHT_BROW_UP, FACE_KEY.RIGHT_BROW_SAD },
                inputType = InputDirector.INPUT_TYPE.CURSOR_UP,
            },

            new FaceInfo
            {
                faceKey = FACE_KEY.LEFT_BROW_UP,
                dependencyList = new List<FACE_KEY>{ FACE_KEY.LEFT_BROW_ANGRY, FACE_KEY.LEFT_BROW_SAD },
                inputType = InputDirector.INPUT_TYPE.OPTION,
            },
            new FaceInfo
            {
                faceKey = FACE_KEY.LEFT_BROW_SAD,
                dependencyList = new List<FACE_KEY>{ FACE_KEY.LEFT_BROW_ANGRY, FACE_KEY.LEFT_BROW_UP },
                inputType = InputDirector.INPUT_TYPE.SQURE,
            },
            new FaceInfo
            {
                faceKey = FACE_KEY.LEFT_BROW_ANGRY,
                dependencyList = new List<FACE_KEY>{ FACE_KEY.LEFT_BROW_UP, FACE_KEY.LEFT_BROW_SAD },
                inputType = InputDirector.INPUT_TYPE.TRIANGLE,
            },

            // 鼻
            new FaceInfo
            {
                faceKey = FACE_KEY.OPEN_NOSE,
                dependencyList = new List<FACE_KEY>{ },
                inputType = InputDirector.INPUT_TYPE.TRACK_PAD,
            },
        };
    }

    void Update()
    {
        ShapeChange();
    }

    /// <summary>
    /// 変形してもよいかどうか
    /// </summary>
    /// <param name="faceKeyId">変形させたい顔ID</param>
    /// <returns>変形しても良いか</returns>
    private bool CanChangeShape(FaceInfo faceInfo)
    {
        foreach (var dependency in faceInfo.dependencyList)
        {
            if (faceRatio[(int)dependency] != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 変形
    /// </summary>
    void ShapeChange()
    {
        foreach(var faceInfo in analogFaceInfoList)
        {
            if (CanChangeShape(faceInfo))
            {
                faceRatio[(int)faceInfo.faceKey] = (int)(InputDirector.GetInput(faceInfo.inputType) * 50f) + 50;
                faceMotion.SetBlendShapeWeight((int)faceInfo.faceKey, faceRatio[(int)faceInfo.faceKey]);
            }
        }

        foreach(var faceInfo in degitalFaceInfoList)
        {
            if (CanChangeShape(faceInfo))
            {
                ChangeRatio(InputDirector.GetInput(faceInfo.inputType) >= 0.5f, ref faceRatio[(int)faceInfo.faceKey]);
                faceMotion.SetBlendShapeWeight((int)faceInfo.faceKey, faceRatio[(int)faceInfo.faceKey]);
            }
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

    /// <summary>
    /// 値の増減
    /// </summary>
    /// <param name="isUp">増加か減少か</param>
    /// <param name="ratio">変化させる値</param>
    private void ChangeRatio(bool isUp, ref int ratio)
    {
        int sign = isUp ? 1 : -1;
        ratio = Mathf.Clamp(ratio + sign * transSpeed, 0, 100);
    }
}
