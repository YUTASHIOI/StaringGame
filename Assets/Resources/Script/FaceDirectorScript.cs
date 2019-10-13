using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirectorScript : MonoBehaviour
{
    [SerializeField]
    GameObject pFace;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pFace); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
