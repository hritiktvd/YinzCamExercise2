using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject MainCamera;

    public GameObject Environment;

    private Material[] EnvironmentMaterials;

    void Start()
    {
        EnvironmentMaterials = Environment.GetComponent<Renderer>().sharedMaterials;
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if(camPositionInPortalSpace.y < 0.5f)
        {
            //Disable Stencil Test
            for(int i = 0; i<EnvironmentMaterials.Length; ++i)
            {
                EnvironmentMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            Debug.Log("Disable Stencil Test");
        }

        else
        {
            //Enable Stencil Test
            for (int i = 0; i < EnvironmentMaterials.Length; ++i)
            {
                EnvironmentMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            Debug.Log("Enable Stencil Test");
        }
    }
}
