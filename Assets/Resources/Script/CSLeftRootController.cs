using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSLeftRootController : MonoBehaviour
{
    [SerializeField, TooltipAttribute("x:箸の横幅, y:回転軸の位置, z:箸先が花粉平面と同じになるように調整")]
    private Vector3 init_pos;   //初期位置
    [SerializeField, TooltipAttribute("init_pos.zと合わせて調整する")]
    private float init_rot_x;   //初期回転
    [SerializeField, TooltipAttribute("箸の回転角度")]
    float Z_Range;                //Z軸に対する箸の可動域

    /*---------------------------------------------------------------*
     * ◆初期化関数
     *---------------------------------------------------------------*/
    void Init()
    {
        this.transform.localPosition = new Vector3(init_pos.x, init_pos.y, init_pos.z);
        this.transform.localRotation = Quaternion.Euler(init_rot_x, 0f, 0f);
    }
    /*****************************************************************
     * Awake
     *****************************************************************/
    void Awake()
    {
        Init();
    }
    /*****************************************************************
    // Start is called before the first frame update
     *****************************************************************/
    void Start()
    {
    }

    /*****************************************************************
    // Update is called once per frame
     *****************************************************************/
    void Update()
    {
        if (Input.GetButton("L2（デジタル）"))
        {
            this.transform.localRotation = Quaternion.Euler(
            init_rot_x,
            0f,
            Z_Range * ((Input.GetAxis("L2（アナログ）") + 1f) / 2f)
            );
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(init_rot_x, 0f, 0f);
        }
    }
}
