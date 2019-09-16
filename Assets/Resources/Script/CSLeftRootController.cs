using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSLeftRootController : MonoBehaviour
{
    [SerializeField]
    float Z_Range = -10f;            //Z軸に対する箸の可動域


    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        this.transform.localPosition = new Vector3(0f, -5f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("L2（デジタル）"))
        {
            this.transform.localRotation = Quaternion.Euler(0f, 0f, Z_Range * ((Input.GetAxis("L2（アナログ）") + 1f) / 2f));
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
