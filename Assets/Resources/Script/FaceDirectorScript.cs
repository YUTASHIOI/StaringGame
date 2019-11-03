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
        GameObject Seed = Instantiate(pFace) as GameObject;
        //プレハブ名の変更
        Seed.name = "Face_Root";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
