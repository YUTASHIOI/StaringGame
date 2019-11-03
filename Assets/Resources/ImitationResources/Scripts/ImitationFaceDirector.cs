using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitationFaceDirector : MonoBehaviour
{
    [SerializeField]
    GameObject ImitationFace;
    [SerializeField]
    GameObject ImitationAutoFace;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ImitationAutoFace, new Vector3(-15.0f,0.0f,0.0f), Quaternion.AngleAxis(-29.0f,Vector3.up));
        Instantiate(ImitationFace, new Vector3(15.0f, 0.0f, 0.0f), Quaternion.AngleAxis(21.0f, Vector3.up));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
