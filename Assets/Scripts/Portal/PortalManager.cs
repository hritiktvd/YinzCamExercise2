using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class GameObjectMaterial
{
    public GameObject EnvironmentObject;
    public Material[] EnvironmentObjectMat;
}

public class PortalManager : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Environment;

    [NonReorderable]
    public List<GameObjectMaterial> PortalObject;

    private void OnEnable()
    {
        EventsManager.onPortalSpawn += showEnvironment;
    }

    private void OnDisable()
    {
        EventsManager.onPortalSpawn -= showEnvironment;
    }

    void Start()
    {
        Environment.SetActive(false);
        foreach(var material in PortalObject)
        {
            material.EnvironmentObjectMat = material.EnvironmentObject.GetComponent<Renderer>().sharedMaterials;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if(camPositionInPortalSpace.y < 0.5f)
        {
            //Disable Stencil Test
            for(int i = 0; i<PortalObject.Count; ++i)
            {
                for (int f = 0; f < PortalObject[i].EnvironmentObjectMat.Length; ++f)
                {
                    PortalObject[i].EnvironmentObjectMat[f].SetInt("_StencilComp", (int)CompareFunction.Always);
                }
            }

            EventsManager.PortalEntered();
            Debug.Log("Disable Stencil Test");
        }

        else
        {
            //Enable Stencil Test
            for (int i = 0; i < PortalObject.Count; ++i)
            {
                for (int f = 0; f < PortalObject[i].EnvironmentObjectMat.Length; ++f)
                {
                    PortalObject[i].EnvironmentObjectMat[f].SetInt("_StencilComp", (int)CompareFunction.Equal);
                }

            }
            EventsManager.PortalExited();
            Debug.Log("Enable Stencil Test");
        }
    }

    private void showEnvironment()
    {
        Environment.SetActive(true);
    }
}
