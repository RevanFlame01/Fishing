using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
   public GameObject MenuPanel;
   public GameObject SettingPanel;
   public Animator AN;
   public trapper TP;

   public void CloseMenuPanelOpenSetting()
   {
      MenuPanel.SetActive(false);
      SettingPanel.SetActive(true);
   }

   public void CloseMenuCanvas()
   {
      gameObject.SetActive(false);
   }

   public void ExitSettingButton()
   {
      AN.Play("CloseSetting");
   }

   public void ExitSettingMethod_for_Anim()
   {
      // AN.Play("OpenMenu");
      MenuPanel.SetActive(true);
      SettingPanel.SetActive(false);
   }

   public void ExitMenuOpenSettingButton()
   {
      AN.Play("CloseMenu");
   }

   public void ExitMenuOpenSettingMethod()
   {
     // AN.Play("OpenSetting");
      MenuPanel.SetActive(false);
      SettingPanel.SetActive(true);
   }

   public void ExitMethod()
   {
      Application.Quit();
   }

   public void TutorialExit()
   {
      TP.tutorialNum = 1;
      PlayerPrefs.SetInt("Tutorial",TP.tutorialNum);
   }

   public void Chapter1Close()
   {
      AN.Play("TutorialChapter1Exit");
   }
}
