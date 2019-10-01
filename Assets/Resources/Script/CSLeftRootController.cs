using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSLeftRootController : MonoBehaviour
{
    [SerializeField, TooltipAttribute("初期位置")]
    private Vector3 init_pos;   //初期位置
    [SerializeField, TooltipAttribute("箸の回転角度")]
    float Z_Range;                //Z軸に対する箸の可動域
    private Quaternion pre_pos;

    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        this.transform.localPosition = init_pos;
        pre_pos = Quaternion.Euler(0f, 0f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    // Update is called once per frame
    void Update()
    {
        pre_pos = this.transform.localRotation;

        if (Input.GetButton("L2（デジタル）"))
        {
            this.transform.localRotation = Quaternion.Euler(
            0f,
            0f,
            Z_Range * ((Input.GetAxis("L2（アナログ）") + 1f) / 2f)
            );
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
