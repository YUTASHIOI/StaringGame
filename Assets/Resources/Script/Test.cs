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
            Debug.Log("intel“ü‚Á‚Ä‚éH");
            Debug.Log(intel);

            if (intel) Debug.Log("‚Í‚¢‚Á‚Ä‚È‚¢‚ñ‚©`‚¢");
            else Debug.Log("‚Æ‚è‚„‚³‚µ‚Ü`‚·");

            intel = false;
            
            if(!intel) Debug.Log("intelæ‚èo‚µ‚Ü‚µ‚½`");
            Debug.Log("intelæ‚èo‚¹‚Ä‚È‚­‚È‚¢!?");
            // ‡
        }
    }
}
