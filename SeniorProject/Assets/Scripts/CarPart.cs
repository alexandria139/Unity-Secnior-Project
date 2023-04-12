using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarPart : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public CarPartTest CarPartTest;
    public Material outline;
    private bool shaderEnabled = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        CarPartTest.PlayerClickedOnPart(this);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!CarPartTest.questionProcessing)
        {
            EnableShader();
        }
   
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!CarPartTest.questionProcessing)
        {
            DisableShader();
        }
    }

    private void EnableShader()
    {
        foreach (MeshRenderer mesh in this.GetComponentsInChildren<MeshRenderer>())
        {
            var temp = new Material[mesh.materials.Length + 1];

            for(int i = 0; i < mesh.materials.Length; i++)
            {
                temp[i] = mesh.materials[i];
            }
            temp[temp.Length - 1] = outline;
            mesh.materials = temp;
        }

        shaderEnabled = true;
    }

    public void DisableShader()
    {
        if (!shaderEnabled) return;
        foreach (MeshRenderer mesh in this.GetComponentsInChildren<MeshRenderer>())
        {
            var temp = new Material[mesh.materials.Length];
            for (int i = 0; i < mesh.materials.Length - 1; i++)
            {
                temp[i] = mesh.materials[i];
            }
            mesh.materials = temp;
        }

        shaderEnabled = false;
    }
}
