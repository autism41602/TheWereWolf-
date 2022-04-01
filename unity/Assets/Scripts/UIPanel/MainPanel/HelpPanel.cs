using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public class HelpPanel : BasePanel
{
    private GList list;
    private GTextField idText; //身份显示文本
    private GTextField idIntroduction; //身份说明文本
    private int currentCardID = 3;

    public HelpPanel(string packageName, UIPanelType uiPanelType, UIManager uiManager) : base(packageName, uiPanelType,
        uiManager)
    {
    }

    protected override void OnInitPanel()
    {
        contentPane.GetChild("Btn_Back").onClick.Set(() => { ToOtherPanel(UIPanelType.MainPanel); });
        idText = contentPane.GetChild("Tex_ID").asTextField;
        idIntroduction = contentPane.GetChild("Tex_Introduce").asTextField;
        list = contentPane.GetChild("CardList").asList;
        list.SetVirtualAndLoop();
        list.itemRenderer = RenderListItem;
        list.numItems = 7;
        list.scrollPane.onScroll.Set(() => { DoSpecialEffect(); });
    }

    private void DoSpecialEffect()
    {
        float listCenter = list.scrollPane.posX + list.viewWidth / 2;

        //list.numChildren 显示在屏幕上的对象
        for (int i = 0; i < list.numChildren; i++)
        {
            GObject item = list.GetChildAt(i);
            float itemCenter = item.x + item.width / 2;
            float itemWidth = item.width;
            float distance = Math.Abs(listCenter - itemCenter);
            if (distance < itemWidth)
            {
                float distanceRange = 1 + (1 - distance / itemWidth) * 0.2f;
                item.SetScale(distanceRange, distanceRange);
            }
            else
            {
                item.SetScale(1, 1);
            }
        }
    }

    private void RenderListItem(int index, GObject gObject)
    {
        GButton button = gObject.asButton;
        button.SetPivot(0.5f, 0.5f);
        button.icon = UIPackage.GetItemURL("Res_Main", "ID" + (index + 1));
    }
}