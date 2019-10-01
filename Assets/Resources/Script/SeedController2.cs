using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController2 : MonoBehaviour
{
    Vector3 Center_Pos = new Vector3(0.0f, 0.0f, 0.0f);

    public Rigidbody rb;
    Vector3 down = new Vector3(0.0f, -0.8f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(down, ForceMode.Impulse);
    }

    Vector3 side1;
    Vector3 side2;

    // Update is called once per frame
    void Update()
    {
        //Vector3 distance = Center_Pos - this.transform.position;
        //float magni = distance.sqrMagnitude;
        //Debug.Log("magni:" + magni);
        side1 = Center_Pos - this.transform.position;
        side2 = new Vector3(Center_Pos.x, Center_Pos.y, this.transform.position.z) - this.transform.position;
        rb.AddForce(Vector3.Cross(side1, side2)/50, ForceMode.Force);
    }
}
