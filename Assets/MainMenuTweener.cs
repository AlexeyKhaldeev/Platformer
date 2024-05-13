using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class MainMenuTweener : MonoBehaviour
{
   public UnityAction DefaultButtonClicked;
   public UnityAction NoMusicButtonClicked;
   public UnityAction MuteButtonClicked;
   
   private void OnMuteClick()
   {
      MuteButtonClicked.Invoke();
   }

   private void OnNoMusicClick()
   {
      NoMusicButtonClicked.Invoke();
   }

   private void OnDefaultClicked()
   {
      DefaultButtonClicked.Invoke();
   }





}
