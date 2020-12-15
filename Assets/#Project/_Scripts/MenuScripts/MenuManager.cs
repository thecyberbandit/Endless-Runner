using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public static MenuManager Instance { get; private set; }

    public Menu menuPrefab;

    private Stack<Menu> menuStack = new Stack<Menu>();


    void Awake()
    {
        Instance = this;    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && menuStack.Count >0)
        {
            menuStack.Peek().OnBackPressed();
        }
    }

    public void OpenMenu()
    {
        //instantiate the menu prefab
        var temp = Instantiate(menuPrefab, transform);

        //deactivate the top menu in the stack
        if(menuStack.Count > 0)
        {
            menuStack.Peek().gameObject.SetActive(false);
        }

        menuStack.Push(temp);
    }

    public void CloseMenu()
    {
        //destroy the menu prefab
        var temp = menuStack.Pop();
        Destroy(temp.gameObject);

        //reactivate the top menu
        if (menuStack.Count > 0)
        {
            menuStack.Peek().gameObject.SetActive(true);
        }
    }

    void OnDestroy()
    {
        Instance = null;    
    }
}
