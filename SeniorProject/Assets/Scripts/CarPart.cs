using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarPart : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public CarPartTest CarPartTest;
    public Material outline;
    private bool shaderEnabled = false;

    public bool useFirstPlace = false;
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

            if (useFirstPlace)
            {
                for (int i = 0; i < mesh.materials.Length; i++)
                {
                    temp[i + 1] = mesh.materials[i];
                }

                temp[0] = outline;
                mesh.materials = temp;
            }

            else
            {
                for (int i = 0; i < mesh.materials.Length; i++)
                {
                    temp[i] = mesh.materials[i];
                }


                temp[temp.Length - 1] = outline;
                mesh.materials = temp;
            }
     

        }

        shaderEnabled = true;
    }

    public void DisableShader()
    {
        if (!shaderEnabled) return;
        foreach (MeshRenderer mesh in this.GetComponentsInChildren<MeshRenderer>())
        {

            if (useFirstPlace)
            {
                var temp = new Material[mesh.materials.Length- 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = mesh.materials[i + 1];
                }
                mesh.materials = temp;
            }

            else
            {
                var temp = new Material[mesh.materials.Length - 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = mesh.materials[i];
                }
                mesh.materials = temp;
            }

        }

        shaderEnabled = false;
    }
}
