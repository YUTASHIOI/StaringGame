using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CSRightRootController : MonoBehaviour
{
    [SerializeField]
    float Z_Range = 15f;            //Z軸に対する箸の可動域


    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        this.transform.localPosition = new Vector3(0f, 5f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("R2（デジタル）"))
        {
            this.transform.localRotation = Quaternion.Euler(
                0f, 
                0f, 
                Z_Range * ((Input.GetAxis("R2（アナログ）") + 1f)/2f)
                );
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }
}
