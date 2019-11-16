using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DysonNoseScript : MonoBehaviour
{
    [SerializeField]
    GameObject Nose_Hole;

    [SerializeField]
    public float power = 10;

    [SerializeField]
    public float dyson_power;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dyson_power = power * Mathf.Sin(Time.time);
    }

    // 豆が当たったら、鼻息に動かされる（吸い込み・吐き出し）
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "seed" && other.GetComponent<SeedController2>().gravitySwitch == false)
        {
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            Vector3 nlz_vector = (other.transform.position - Nose_Hole.transform.position).normalized;
            rigidbody.AddForce(nlz_vector * dyson_power);
        }
    }
}
