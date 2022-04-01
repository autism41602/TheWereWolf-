using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public bool isGameUIManager;
    public Dictionary<UIPanelType, BasePanel> uiPanelDict;
    public UIPanelType currentGamePanel;

    public UIManager()
    {
        uiPanelDict = new Dictionary<UIPanelType, BasePanel>();
    }

    public void ClearDict()
    {
        foreach (var item in uiPanelDict)
        {
            item.Value?.Dispose();
        }

        uiPanelDict.Clear();
    }

    public void GameUIManager()
    {
    }

    public void MainUIManager()
    {
        isGameUIManager = false;
        if (uiPanelDict.Count != 0)
        {
            ClearDict();
        }

        uiPanelDict.Add(UIPanelType.MainPanel, new MainPanel("Panel_Main", UIPanelType.MainPanel, this));
        uiPanelDict.Add(UIPanelType.GamePanel, new GamePanel("Panel_Game", UIPanelType.GamePanel, this));
        uiPanelDict.Add(UIPanelType.HelpPanel, new HelpPanel("Panel_Help", UIPanelType.HelpPanel, this));
        uiPanelDict.Add(UIPanelType.SetPanel, new SettingPanel("Panel_Set", UIPanelType.SetPanel, this));
        uiPanelDict[UIPanelType.MainPanel].Show();
    }
}