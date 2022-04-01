using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public class BasePanel : Window
{
    //属性
    protected string packageName;
    protected Transition _transition;
    protected Controller _controller;
    protected GComponent panelMask;
    protected UIPanelType currentUIPanelType;
    protected UIManager _uiManager;

    public BasePanel(string packageName, UIPanelType uiPanelType, UIManager uiManager)
    {
        this.packageName = packageName;
        currentUIPanelType = uiPanelType;
        this._uiManager = uiManager;
        UIPackage.AddPackage("UI/" + packageName);
    }

    protected override void OnInit()
    {
        //执行共有部分
        contentPane = UIPackage.CreateObject(packageName, "Main").asCom;
        panelMask = this.contentPane.GetChild("PanelMask").asCom;
        //执行特有部分
        OnInitPanel();
    }

    protected virtual void OnInitPanel()
    {
    }

    //进入页面
    public void EnterPanel()
    {
        Transition t = panelMask.GetTransition("MaskShow");
        t.Play();
    }

    //进入其他页面
    protected void ToOtherPanel(UIPanelType otherType)
    {
      ExitPanel(() =>
      {
          ChangePanelCallBack(otherType);
      });
    }

    //退出页面
    protected void ExitPanel(PlayCompleteCallback playCompleteCallback)
    {
        Transition t = panelMask.GetTransition("MaskHide");
        t.Play(playCompleteCallback);
    }

    protected void ChangePanelCallBack(UIPanelType otherPanel)
    {
        _uiManager.uiPanelDict[currentUIPanelType].Hide();
        
        _uiManager.uiPanelDict[otherPanel].Show();
        _uiManager.uiPanelDict[otherPanel].EnterPanel();
    }
}