using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //test is test
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        bool intel = true;

        while(intel){
            Debug.Log("intel入ってる？");
            Debug.Log(intel);

            if (intel) Debug.Log("はいってないんか〜い");
            else Debug.Log("とりｄさしま〜す");

            intel = false;
            
            if(!intel) Debug.Log("intel取り出しました〜");
            Debug.Log("intel取り出せてなくない!?");
            // ∞
        }
    }
}
