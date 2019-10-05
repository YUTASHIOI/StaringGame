using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    //ゲームの状態遷移
    public enum GAME_STATE_TYPE
    {
        PINCH_POLLEN,
        PUT_IN_NOSE,
    }
    [SerializeField, TooltipAttribute("ゲームの進行状況を管理する")]
    public GAME_STATE_TYPE Game_Scene_T;

    /*****************************************************************
     * Awake
     *****************************************************************/
    void Awake()
    {
        Game_Scene_T = GAME_STATE_TYPE.PINCH_POLLEN;
    }
    /*****************************************************************
    // Start is called before the first frame update
     *****************************************************************/
    void Start()
    {
    }
    /*****************************************************************
    // Update is called once per frame
     *****************************************************************/
    void Update()
    {
        
    }
}
