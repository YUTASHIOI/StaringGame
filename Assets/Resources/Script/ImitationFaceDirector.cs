using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitationFaceDirector : MonoBehaviour
{
    [SerializeField]
    GameObject pFace;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pFace,new Vector3(-15.0f,0.0f,0.0f), new Quaternion(0.0f, -12.0f, 0.0f,0.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
