using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CSRightRootController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hitt");
        //this.transform.DOMove(endValue: new Vector3(5.0f, 0.5f, 0), duration: 2.0f);
        // 1秒かけて90度まで回転
        this.transform.DORotate(
            new Vector3(0f, 0f, 30f), // 終了時点のRotation
            10.0f                    // アニメーション時間
        );
    }
}
