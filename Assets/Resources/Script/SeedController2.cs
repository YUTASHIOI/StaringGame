using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController2 : MonoBehaviour
{
    [SerializeField]
    GameObject pSeed, Eye_R, Eye_L;

    [SerializeField]
    float Seed_Pos_def;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 ER_Pos = Eye_R.transform.position;
        Instantiate(pSeed, new Vector3(0.0f, 0.0f, -2.0f), Quaternion.identity);
        //Instantiate(pSeed, new Vector3(ER_Pos.x, ER_Pos.y, ER_Pos.z - Seed_Pos_def), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
