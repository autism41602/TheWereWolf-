using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //单例
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    //UI
    [HideInInspector] public bool isInGame;
    private UIManager currentUIManager;

    //声音
    [HideInInspector] public AudioSourceManager audioSourceManager;
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    public AudioClip buttonSound;

    //信息
    [HideInInspector] public MessageManager messageManager;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;

        //加载资源包
        UIPackage.AddPackage("UI/Res_Main");
        UIPackage.AddPackage("UI/Res_Game");
        UIPackage.AddPackage("UI/Res_Component");
        UIConfig.defaultFont = "汉仪南宫体简";
        UIConfig.buttonSound = (NAudioClip) UIPackage.GetItemAssetByURL("ui://Res_Main/Crumple");
        GRoot.inst.SetContentScaleFactor(1600, 900, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
        if (currentUIManager == null)
        {
            currentUIManager = new UIManager();
            currentUIManager.MainUIManager();
        }

        if (audioSourceManager == null)
        {
            audioSourceManager = new AudioSourceManager(this);
        }

        if (messageManager == null)
        {
            messageManager = new MessageManager();
        }
    }
}