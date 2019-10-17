using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDirector : MonoBehaviour
{
    GameDirector GameDirector;

    [SerializeField]
    GameObject pSeed, Eye_R, Eye_L;

    [SerializeField]
    float Seed_Pos_def;

    // Start is called before the first frame update
    void Start()
    {
        GameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameDirector.Game_Scene_T)
        {
            case GameDirector.GAME_STATE_TYPE.PREPARATE:
                break;
            case GameDirector.GAME_STATE_TYPE.PRE_GAME:
                InstanceSeed();
                break;
            default:
                break;
        }
    }

    //豆出す
    public void InstanceSeed()
    {
        Vector3 ER_Pos = Eye_R.transform.position;
        Vector3 EL_Pos = Eye_L.transform.position;
        if (Random.Range(-1.0f, 1.0f) < 0.0f)
        {
            Instantiate(pSeed, new Vector3(ER_Pos.x, ER_Pos.y, -11), Quaternion.identity);
        }
        else
        {
            Instantiate(pSeed, new Vector3(EL_Pos.x, EL_Pos.y, -11), Quaternion.identity);
        }
    }
}
