using System;
using UnityEngine;

public enum ThemeMode
{
    Light,
    Dark,
    Custom
}
    
namespace ThemeChange
{
    public class ThemeManager : MonoBehaviour
    {
        public static ThemeManager Instance { get; private set; }

        [Header("Theme Assets")]
        public ThemeData LightTheme;
        public ThemeData DarkTheme;
        
        public ThemeMode CurrentMode { get; private set; }
        public ThemeData CurrentTheme { get; private set; }
        
        public Action<ThemeData> OnThemeChanged;
        
        private void Awake()
        {
            // 싱글톤 오브젝트가 존재하면 파괴
            if (Instance != null && Instance != this)
                DestroyImmediate(gameObject);
            
            // 싱글톤 지정
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SetTheme(ThemeMode.Light, false);
        }
        
        public void SetTheme(ThemeMode mode, bool isChange = true)
        {
            CurrentMode = mode;

            CurrentTheme = (CurrentMode == ThemeMode.Light) ? LightTheme : DarkTheme; 
            
            if (isChange)
            {
                if(OnThemeChanged != null)
                    OnThemeChanged.Invoke(CurrentTheme);
            } 
        }
    }
}