using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private PlayerControlls _playerControlls;

    public GameObject PauseMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _playerControlls = new PlayerControlls();
        _playerControlls.Default.Enable();
        _playerControlls.Default.Pause.performed += OpenClosePauseMenu;
    }

    private void OpenClosePauseMenu(InputAction.CallbackContext obj)
    {
       OpenClosePauseMenu();
    }
    

    private void OnDestroy()
    {
        if(_playerControlls != null)
        {
            _playerControlls.Default.Pause.performed -= OpenClosePauseMenu;
        }

    }

    public void OpenClosePauseMenu()
    {
        PauseMenuCanvas.SetActive(!PauseMenuCanvas.activeInHierarchy);

        if (PauseMenuCanvas.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
