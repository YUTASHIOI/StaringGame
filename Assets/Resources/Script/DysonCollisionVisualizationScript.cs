using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DysonCollisionVisualizationScript : MonoBehaviour
{
    DysonNoseScript DysonNoseScript;

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
        float pow = DysonNoseScript.power;
        float pow_dyson = DysonNoseScript.dyson_power + pow;
        byte p = (byte)(pow_dyson/(pow*2) * 255.0f);
        GetComponent<Renderer>().material.color = new Color32(255, p, 255, 64);
    }
}
