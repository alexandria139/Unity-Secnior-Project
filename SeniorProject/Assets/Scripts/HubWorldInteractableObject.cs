using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HubWorldInteractableObject : MonoBehaviour
{

    public int sceneIndex;
    PlayerControlls inputActions;

    private bool playerWithinBounds = false;
    private bool playerCanInteract = false;
    private GameObject interactText;
    public GameObject arrowIndicator;



    private void Awake()
    {
        inputActions = new PlayerControlls();
        inputActions.Enable();
        inputActions.Default.Interact.performed += PlayerInteracted;

        interactText = GameObject.Find("Interact Text");

        arrowIndicator.SetActive(false);
    }

    private void Start()
    {
        interactText.SetActive(false);
    }

    private void PlayerInteracted(InputAction.CallbackContext obj)
    {
        if (!playerWithinBounds || !playerCanInteract) return;

        SceneManager.LoadScene(sceneIndex);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }


    public void ChangeInteractionAbility(bool newState)
    {
        playerCanInteract = newState;

    }


    public void SetAsNextStep()
    {

        arrowIndicator.gameObject.SetActive(true) ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerCanInteract) return;
        interactText.SetActive(true);
        playerWithinBounds = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!playerCanInteract) return;
        interactText.SetActive(false);
        playerWithinBounds = false;
    }
}
