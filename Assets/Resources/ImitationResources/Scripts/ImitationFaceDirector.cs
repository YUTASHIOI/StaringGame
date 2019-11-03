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
        Instantiate(pFace,new Vector3(-15.0f,0.0f,0.0f), Quaternion.AngleAxis(-29.0f,Vector3.up));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
