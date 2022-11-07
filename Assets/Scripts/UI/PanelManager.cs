using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PanelManager : MonoBehaviour
    {
        public void OpenPanel(GameObject panel)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            panel.SetActive(true);
        }

        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
        }

        public void ClosePanelSmallMenu(GameObject panel)
        {
            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            panel.SetActive(false);
        }

        public void OpenPanels(GameObject[] panels)
        {
            foreach (GameObject go in panels)
            {
                go.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void ClosePanels(GameObject[] panels)
        {
            foreach (GameObject go in panels)
            {
                go.SetActive(false);
            }

            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
