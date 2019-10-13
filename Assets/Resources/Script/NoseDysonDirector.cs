using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseDysonDirector : MonoBehaviour
{
    [SerializeField]
    GameObject pNoseHole_R, pNoseHole_L, pNoseDyson_R, pNoseDyson_L;

    GameObject NoseHole_R;
    GameObject NoseHole_L;
    GameObject NoseDyson_R;
    GameObject NoseDyson_L;

    // Start is called before the first frame update
    void Start()
    {
        NoseHole_R = Instantiate(pNoseHole_R) as GameObject;
        NoseHole_L = Instantiate(pNoseHole_L) as GameObject;
        NoseDyson_R = Instantiate(pNoseDyson_R) as GameObject;
        NoseDyson_L = Instantiate(pNoseDyson_L) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
