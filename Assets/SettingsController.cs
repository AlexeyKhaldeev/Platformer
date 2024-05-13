using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private MainMenuTweener _mainMenu;
    
    private const string PrefsSnapshotKeyName = "SnapshotKeyName";
    private const string NoMusicSnapshotName = "NoMusic";
    private const string DefaultSnapshotName = "Default";
    private const string MuteSnapshotName = "Mute";
    
    void Start()
    {
        _mainMenu.DefaultButtonClicked += OnDefaultButtonClicked;
        _mainMenu.NoMusicButtonClicked += OnNoMusicButtonClicked;
        _mainMenu.MuteButtonClicked += OnMuteButtonClicked;
        
        if (PlayerPrefs.HasKey(PrefsSnapshotKeyName))
        {
            _mixer.FindSnapshot(PlayerPrefs.GetString(PrefsSnapshotKeyName)).TransitionTo(0.0f);
        }
        
    }

    private void OnDestroy()
    {
        _mainMenu.DefaultButtonClicked -= OnDefaultButtonClicked;
        _mainMenu.NoMusicButtonClicked -= OnNoMusicButtonClicked;
        _mainMenu.MuteButtonClicked -= OnMuteButtonClicked;
    }

    private void OnMuteButtonClicked()
    {
        _mixer.FindSnapshot(MuteSnapshotName).TransitionTo(0.0f);
        PlayerPrefs.GetString(PrefsSnapshotKeyName, MuteSnapshotName);
        PlayerPrefs.Save();
    }

    private void OnNoMusicButtonClicked()
    {
        _mixer.FindSnapshot(NoMusicSnapshotName).TransitionTo(0.0f);
        PlayerPrefs.GetString(PrefsSnapshotKeyName, NoMusicSnapshotName);
        PlayerPrefs.Save();
    }

    private void OnDefaultButtonClicked()
    {
        _mixer.FindSnapshot(DefaultSnapshotName).TransitionTo(0.0f);
        PlayerPrefs.GetString(PrefsSnapshotKeyName, DefaultSnapshotName);
        PlayerPrefs.Save();
    }
    
}
