using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DysonNoseScript : MonoBehaviour
{
    [SerializeField]
    GameObject Nose_Hole;

    [SerializeField]
    float power;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "seed")
        {
            float dyson_power = power * Mathf.Sin(Time.time);
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            Vector3 nlz_vector = (other.transform.position - Nose_Hole.transform.position).normalized;
            rigidbody.AddForce(nlz_vector * dyson_power);
        }
    }
}
