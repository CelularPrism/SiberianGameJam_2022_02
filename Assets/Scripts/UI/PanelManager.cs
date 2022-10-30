using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PanelManager : MonoBehaviour
    {
        public void OpenPanel(GameObject panel)
        {
            panel.SetActive(true);
        }

        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
        }

        public void OpenPanels(GameObject[] panels)
        {
            foreach (GameObject go in panels)
            {
                go.SetActive(true);
            }
        }

        public void ClosePanels(GameObject[] panels)
        {
            foreach (GameObject go in panels)
            {
                go.SetActive(false);
            }
        }
    }
}
