using System;
using ThemeChange;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleTheme : MonoBehaviour
    {
        public Toggle vToggle;

        private void Awake()
        {
            vToggle = GetComponent<Toggle>();
        }

        private void OnEnable()
        {
            vToggle.onValueChanged.AddListener(OnToggleChanged);
        }

        private void OnDisable()
        {
            vToggle.onValueChanged.RemoveListener(OnToggleChanged);
        }

        void OnToggleChanged(bool isOn)
        {
            Debug.Log("Toggled");
            ThemeManager.Instance.SetTheme(isOn ? ThemeMode.Dark : ThemeMode.Light);
        }
    }
}