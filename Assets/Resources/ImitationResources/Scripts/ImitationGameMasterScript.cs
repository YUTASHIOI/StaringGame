using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitationGameMasterScript : MonoBehaviour
{
    float timeOut = 3f;
    float timeElapsed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        //Debug.Log(timeElapsed);
        if(timeElapsed >= timeOut)
        {
            Debug.LogFormat("{0}秒経過", timeOut);
            timeElapsed = 0.0f;
        }
    }
}
