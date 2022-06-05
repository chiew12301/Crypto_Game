using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProgC
{
    public class MainMenuUIHandler : MonoBehaviour
    {
        public List<RectTransform> uiGroupList = new List<RectTransform>();
        
        public void UIState(bool state)
        {
            foreach(RectTransform rt in uiGroupList)
            {
                rt.gameObject.SetActive(state);
            }
        }
    }
}
