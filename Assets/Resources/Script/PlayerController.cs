using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameDirector GameDirector;
    public string playerID;

    /*****************************************************************
     * Awake
     *****************************************************************/
    void Awake()
    {
        
    }
    /*******************************************************************
    // Start is called before the first frame update
     *******************************************************************/
    void Start()
    {

    }

    /*******************************************************************
    // Update is called once per frame
     *******************************************************************/
    void Update()
    {
        switch (GameDirector.Game_Scene_T)
        {
            case GameDirector.GAME_STATE_TYPE.PREPARATE:
                break;
            case GameDirector.GAME_STATE_TYPE.PRE_GAME:
                GameObject.Find("Chopsticks").GetComponent<ChopsticsController>().playerID = playerID;
                break;
            case GameDirector.GAME_STATE_TYPE.GAME:
                break;
            case GameDirector.GAME_STATE_TYPE.POST_GAME:
                break;
            default:
                break;
        }
    }
}
