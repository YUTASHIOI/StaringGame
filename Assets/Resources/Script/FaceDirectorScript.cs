using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaceDirectorScript : MonoBehaviour
{
    [SerializeField]
    GameObject pFace;

    // Start is called before the first frame update
    void Start()
    {
        pFace = Instantiate(pFace, new Vector3(0, 0, -2.5f), Quaternion.identity) as GameObject; ;
        //プレハブ名の変更
        pFace.name = "Face_Root";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
