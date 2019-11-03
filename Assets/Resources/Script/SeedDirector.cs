using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDirector : MonoBehaviour, IController
{
    GameDirector GameDirector;

    [SerializeField]
    GameObject pSeed, Eye_R, Eye_L;

    [SerializeField]
    float Seed_Pos_def;

    /// <summary>
    /// 生み出された種の数
    /// </summary>
    [SerializeField]
    int m_num;

    // Start is called before the first frame update
    void Start()
    {
        GameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        GameDirector.Controllers.Add(this);
        m_num = 0;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void ControllerInitialize()
    {
        InstanceSeed();
    }
    
    /// <summary>
    /// 更新
    /// </summary>
    public void ControllerUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            InstanceSeed();
        }
    }

    /// <summary>
    /// 終了処理
    /// </summary>
    public void ControllerFinalize()
    {
    }

    /// <summary>
    /// タネダス
    /// </summary>
    public void InstanceSeed()
    {
        Vector3 ER_Pos = Eye_R.transform.position;
        Vector3 EL_Pos = Eye_L.transform.position;

        //種の数更新
        m_num++;

        if (Random.Range(-1.0f, 1.0f) < 0.0f)
        {
            GameObject Seed = Instantiate(pSeed, new Vector3(ER_Pos.x, ER_Pos.y, -11), Quaternion.identity) as GameObject;
            //プレハブ名の変更
            Seed.name = "Seed_" + (m_num).ToString();
        }
        else
        {
            GameObject Seed = Instantiate(pSeed, new Vector3(EL_Pos.x, EL_Pos.y, -11), Quaternion.identity) as GameObject;
            //プレハブ名の変更
            Seed.name = "Seed_" + (m_num).ToString();
        }
    }
}
