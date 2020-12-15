using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu<MainMenu> {

    public override void OnBackPressed()
    {
        Application.Quit();
    }
}
