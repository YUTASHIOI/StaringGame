using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDirector : MonoBehaviour
{
    [SerializeField]
    GameObject pSeed, Eye_R, Eye_L;

    [SerializeField]
    float Seed_Pos_def;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 ER_Pos = Eye_R.transform.position;
        Vector3 EL_Pos = Eye_L.transform.position;
        if (Random.Range(-1.0f, 1.0f) < -1.0)
        {
            Instantiate(pSeed, new Vector3(ER_Pos.x, ER_Pos.y, ER_Pos.z - Seed_Pos_def), Quaternion.identity);
        }
        else
        {
            Instantiate(pSeed, new Vector3(ER_Pos.x, EL_Pos.y, ER_Pos.z - Seed_Pos_def), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
