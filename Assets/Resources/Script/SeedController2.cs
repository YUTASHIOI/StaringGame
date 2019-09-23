using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController2 : MonoBehaviour
{
    [SerializeField]
    GameObject pSeed, Eye_R, Eye_L;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 ER_Pos = Eye_R.transform.position;
        GameObject gMonkey = Instantiate(pSeed, new Vector3(ER_Pos.x, ER_Pos.y, ER_Pos.z), Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
