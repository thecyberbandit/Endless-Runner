using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : Menu<OptionsMenu> {

    public override void OnBackPressed()
    {
        MenuManager.Instance.CloseMenu();
    }
}
