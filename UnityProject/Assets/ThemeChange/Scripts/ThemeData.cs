using UnityEngine;

namespace ThemeChange
{
    [CreateAssetMenu(fileName = "ThemeData", menuName = "ThemeData", order = 1)]
    public class ThemeData : ScriptableObject
    {
        // 기본 컬러
        public Color BackgroundColor;
        public Color TextColor;
        
        // 버튼 컬러
        public Color ButtonColorNormal;
        public Color ButtonColorHover;
        public Color ButtonColorPressed;
        public Color ButtonColorSelected;
    }
}