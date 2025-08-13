using System;
using ThemeChange;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Button))]
    public class UIButtonTheme : MonoBehaviour, ITheme
    {
        public Button vButton;
        public Text vText;
        
        private void Awake()
        {
            vButton = GetComponent<Button>();
            vText = GetComponentInChildren<Text>();
        }

        private void OnEnable()
        {
            ThemeManager.Instance.OnThemeChanged += Apply;
            Apply(ThemeManager.Instance.CurrentTheme);
        }

        private void OnDisable()
        {
            ThemeManager.Instance.OnThemeChanged -= Apply;
        }

        public void Apply(ThemeData theme)
        {
            ColorBlock colorBlock = vButton.colors;
            colorBlock.normalColor = theme.ButtonColorNormal;
            colorBlock.highlightedColor = theme.ButtonColorHover;
            colorBlock.pressedColor = theme.ButtonColorPressed;
            colorBlock.selectedColor = theme.ButtonColorSelected;
            vButton.colors = colorBlock;
            
            vText.color = theme.TextColor;
        }
    }
}