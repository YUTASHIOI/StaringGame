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
            Debug.Log("intel�����Ă�H");
            Debug.Log(intel);

            if (intel) Debug.Log("�͂����ĂȂ��񂩁`��");
            else Debug.Log("�Ƃ肄�����܁`��");

            intel = false;
            
            if(!intel) Debug.Log("intel���o���܂����`");
            Debug.Log("intel���o���ĂȂ��Ȃ�!?");
            // ��
        }
    }
}
