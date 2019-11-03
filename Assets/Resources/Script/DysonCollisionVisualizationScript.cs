using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DysonCollisionVisualizationScript : MonoBehaviour
{
    DysonNoseScript DysonNoseScript;
    float pow;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの色をRGBA値を用いて変更する
        GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 64);
        while (DysonNoseScript == null)
        {
            DysonNoseScript = GameObject.Find("NoseDyson_R").GetComponent<DysonNoseScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        pow = DysonNoseScript.dyson_power;
        byte p = (byte)(pow * 255.0f);
        GetComponent<Renderer>().material.color = new Color32(255, p, 255, 64);
    }
}
