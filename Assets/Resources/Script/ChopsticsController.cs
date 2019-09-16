using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopsticsController : MonoBehaviour
{
    [SerializeField]
    float MoveRange = 30f;            //Z軸に対する箸の可動域
    [SerializeField]
    float Z_pos = -30f;            //Z軸に対する箸の可動域

    private Vector3 pos;
    // Start is called before the first frame update

    /*----------------------------------------------------*
     * ◆初期化関数
     *----------------------------------------------------*/
    void Init()
    {
        pos = new Vector3(0, 0, Z_pos);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("L_Vertical")+":"+Input.GetAxis("L_Vertical"));

        pos.x = Input.GetAxis("L_Horizontal") * MoveRange;
        pos.y = Input.GetAxis("L_Vertical")   *-MoveRange;
        pos.z = Z_pos;
        this.transform.localPosition = pos;
    }
}
