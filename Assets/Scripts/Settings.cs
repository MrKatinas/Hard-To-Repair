using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings.asset", menuName = "CreateSettings")]
public class Settings : ScriptableObject
{
    #region Singleton

    private const string settingsPath = "Settings";

    private static Settings _settings;
    public static Settings Get
    {
        get
        {
            if (_settings != null) return _settings;

            _settings = Resources.Load<Settings>(settingsPath);
            
            return _settings;
        }
    }

    #endregion

    public string GameSceneName;

}