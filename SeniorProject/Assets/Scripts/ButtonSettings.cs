using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettings : MonoBehaviour
{
    public void ButtonClickedEvent()
    {
        AudioManager.Instance.PlayButtonClick();
    }
}
