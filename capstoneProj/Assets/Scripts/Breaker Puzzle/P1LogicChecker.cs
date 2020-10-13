﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P1LogicChecker : MonoBehaviour
{
    [SerializeField]
    public GameObject disableOnWin;
    public List<Toggle> onToggles;
    public List<Toggle> offToggles;
    public AudioManager tockSound;

    public bool checkWin()
    {
        foreach (Toggle toggle in onToggles)
        {
            if(!toggle.isOn)
            {
                return false;
            }
        }
        foreach (Toggle toggle in offToggles)
        {
            if (toggle.isOn)
            {
                return false;
            }
        }
        disableOnWin.SetActive(false);
        tockSound.backgroundSource.Stop();
        return true;
    }
}
