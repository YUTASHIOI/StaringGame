using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    //-------------------------------------------------ゲームの状態遷移
    public enum GAME_STATE_TYPE
    {
        PREPARATE,  //ゲーム前
        PRE_GAME,   //ゲーム開始最初の1F
        GAME,       //ゲーム終了
        POST_GAME,  //ゲーム終了後最初の1F
    }
    //---------------------------------------------インスペクタービュー
    [SerializeField, TooltipAttribute("ゲームの進行状況を管理する")]
    public GAME_STATE_TYPE Game_Scene_T;
    [SerializeField, TooltipAttribute("デバイス接続数")]
    public int device_num;
    [SerializeField, TooltipAttribute("16:9の場合")]
    public float aspect = 1.777777f;

    [SerializeField, TooltipAttribute("プレイヤーPrefab")]
    private GameObject player;

    private bool device_flag;       //デバイスの認識が完了したかどうか

    /*------------------------------------------------------------------*
     * ◆Playerの生成＆デバイス認識
     *------------------------------------------------------------------*/
    private IEnumerator CreatePlayer()
    {
        //デバイス数のリセット
        device_num = 0;

        //詠み込みまでの待ち時間
        yield return new WaitForSeconds(0.1f);

        var controllerNames = Input.GetJoystickNames();

        //認識できるデバイス
        Debug.Log("----接続開始----");
        if (controllerNames[0] == "")
        {
            //【注意】デバイス接続できているのに、なぜか０になることがある
            Debug.Log("Error:デバイスが接続されていません");
        }
        else
        {
            Debug.Log("接続検知数：" + controllerNames.Length);
            for (int i = 0; controllerNames.Length > i; i++)
            {
                if(controllerNames[i] != "")
                {
                    Debug.Log("デバイス[" + i + "]：" + controllerNames[i]);
                    //デバイス数の更新
                    device_num++;
                    //プレイヤーの生成
                    GameObject player_prefab = Instantiate(player) as GameObject;
                    //プレハブ名の変更
                    player_prefab.name = "Player" + (i + 1).ToString();
                    //IDの入力
                    player_prefab.GetComponent<PlayerController>().GameDirector = GetComponent<GameDirector>();
                    //IDの入力
                    player_prefab.GetComponent<PlayerController>().playerID = "P" + (i+1).ToString() +"_";
                }
            }
        }
        Debug.Log("接続デバイス数：" + device_num + "\n----接続完了----");
        device_flag = true;
    }

    /*****************************************************************
     * Awake
     *****************************************************************/
    void Awake()
    {
        //ゲームの状態を管理する
        Game_Scene_T = GAME_STATE_TYPE.PREPARATE;
        //デバイスの認識が完了したかどうか
        device_flag = false;

        //接続されているデバイスを取得
        StartCoroutine("CreatePlayer");
               
    }
    /*******************************************************
     * **********
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
        //GAME_STATE_TYPEの更新
        switch (Game_Scene_T)
        {
            case GameDirector.GAME_STATE_TYPE.PREPARATE:
                //全ての事前準備が終わったら
                if (device_flag)
                {
                    Game_Scene_T = GAME_STATE_TYPE.PRE_GAME;
                }
                break;
            case GameDirector.GAME_STATE_TYPE.PRE_GAME:
                //ゲーム開始直前の1Fだけ
                Game_Scene_T = GAME_STATE_TYPE.GAME;
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
