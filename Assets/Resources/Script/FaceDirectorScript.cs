using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaceDirectorScript : MonoBehaviour
{
    [SerializeField]
    GameObject pFace;
    Vector3 FaceOriginPosition = new Vector3(0.0f, 0.0f, -2.5f);
    Quaternion FaceOriginQuaternion = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "ImitationGameScene")
        {
            FaceOriginPosition += new Vector3(10.0f,0.0f,0.0f);
            FaceOriginQuaternion = Quaternion.AngleAxis(14.0f, Vector3.up);
        }
        Instantiate(pFace,FaceOriginPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
