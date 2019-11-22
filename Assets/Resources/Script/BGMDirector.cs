using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDirector : MonoBehaviour
{
    [SerializeField, TooltipAttribute("BGM1")]
    AudioClip bgm_01;

    // Start is called before the first frame update
    void Start()
    {
        //BGM再生
        this.GetComponent<AudioSource>().PlayOneShot(bgm_01);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
