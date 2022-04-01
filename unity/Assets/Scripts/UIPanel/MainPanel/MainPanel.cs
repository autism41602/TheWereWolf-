using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public class MainPanel : BasePanel
{
    public MainPanel(string packageName, UIPanelType uiPanelType, UIManager uiManager) : base(packageName, uiPanelType,
        uiManager)
    {
    }

    protected override void OnInitPanel()
    {
        _transition = contentPane.GetTransition("WhiteMaskAnim");
        _transition.Play();
        Transition t = panelMask.GetTransition("MaskShow");
        t.Play();
        contentPane.GetChild("Btn_StartGame").onClick.Set(() =>
        {
            ToOtherPanel(UIPanelType.GamePanel);
            GameManager.Instance.audioSourceManager.ChangeBGM(1);
        });
        contentPane.GetChild("Btn_Help").onClick.Set(() => { ToOtherPanel(UIPanelType.HelpPanel); });
        contentPane.GetChild("Btn_Setting").onClick.Set(() => { ToOtherPanel(UIPanelType.SetPanel); });
        contentPane.GetChild("Btn_ExitGame").onClick.Set(() => { Application.Quit(); });
    }
}