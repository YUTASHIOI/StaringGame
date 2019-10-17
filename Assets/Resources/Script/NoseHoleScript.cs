using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseHoleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 当たったのが豆なら、Destroy して 再 Instance
    private void OnTriggerEnter(Collider other)
    {
        SeedDirector SeedDirector;
        SeedDirector = GameObject.Find("EYES_root").GetComponent<SeedDirector>();
        if (other.tag == "seed")
        {
            Destroy(other.gameObject);
            SeedDirector.InstanceSeed();
        }
    }
}
