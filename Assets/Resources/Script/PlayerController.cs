using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController
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
        GameDirector.Controllers.Add(this);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void ControllerInitialize()
    {
        GameObject.Find("Chopsticks").GetComponent<ChopsticsController>().playerID = playerID;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ControllerUpdate()
    {
    }

    /// <summary>
    /// 終了処理
    /// </summary>
    public void ControllerFinalize()
    {
    }
}
