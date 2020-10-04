using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperInfo : MonoBehaviour
{
    public TitleUI titleUI;

    public void OnClickExitBtn()
    {
        titleUI.OpenMainMenu();
    }
}
