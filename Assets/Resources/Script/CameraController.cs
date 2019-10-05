using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public  float left;
    public  float right;
    public  float top;
    public  float bottom;
    public  float z;

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
        // 線の幅
        renderer.SetWidth(0.5f, 0.5f);
        // 頂点の数
        renderer.SetVertexCount(5);
        // 頂点を設定
        renderer.SetPosition(0, new Vector3(left, top, z));
        renderer.SetPosition(1, new Vector3(right, top, z));
        renderer.SetPosition(2, new Vector3(right, bottom, z));
        renderer.SetPosition(3, new Vector3(left, bottom, z));
        renderer.SetPosition(4, new Vector3(left, top, z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
