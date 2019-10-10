using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EyeRotateScript : MonoBehaviour
{
    int ROTATE_DEF = -90;
    int ROTATE_STV_H = 30;
    int ROTATE_STV_V = 40;

    [SerializeField]
    GameObject pEye_R, pEye_L;

    GameObject Eye_R;
    GameObject Eye_L;

    // Start is called before the first frame update
    void Start()
    {
        Eye_R = Instantiate(pEye_R) as GameObject;
        Eye_L = Instantiate(pEye_L) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        EyeRotate();
    }

    void EyeRotate()
    {
        Eye_L.transform.rotation 
            = Quaternion.Euler(0
                           , -Input.GetAxis("R_Horizontal") * ROTATE_STV_H + ROTATE_DEF
                           , Input.GetAxis("R_Vertical") * ROTATE_STV_V);
        Eye_R.transform.rotation
            = Quaternion.Euler(0
                           , -Input.GetAxis("L_Horizontal") * ROTATE_STV_H + ROTATE_DEF
                           , Input.GetAxis("L_Vertical") * ROTATE_STV_V);
    }
}
