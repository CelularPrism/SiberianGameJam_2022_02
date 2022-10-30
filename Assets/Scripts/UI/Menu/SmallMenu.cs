using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class SmallMenu : MonoBehaviour
    {
        [Header("Game objects")]
        [Header("Small Menu panel")]
        [SerializeField] private GameObject smallMenu;

        [Header("Settings panel")]
        [SerializeField] private GameObject settings;


        private bool _isActive = false;
        
        private MenuInput _inputActions;
        private PanelManager _panelManager;
        private GameObject[] _panels;

        void Start()
        {
            _panelManager = new PanelManager();
            _panels = new GameObject[2] { smallMenu, settings };

            _inputActions = new MenuInput();
            _inputActions.Menu.OpenCloseMenu.performed += perf => OpenCloseMenu();
            _inputActions.Enable();
        }

        private void OpenCloseMenu()
        {
            if (_isActive)
            {
                _panelManager.ClosePanels(_panels);
            } else
            {
                _panelManager.OpenPanel(smallMenu);
            }
            _isActive = !_isActive;
        }

        private void Exit()
        {
            Debug.Log("Load scene - Main menu");
            //SceneManager.LoadScene(); // ¬вести номер сцены меню
        }

        public void SetActive(bool active)
        {
            _isActive = active;
        }
    }
}
