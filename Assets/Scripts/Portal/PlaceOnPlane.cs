using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{

    UnityEvent placementUpdate;

    [SerializeField]
    GameObject visualObject;

    [SerializeField]
    GameObject PortalEnvironment;

    [SerializeField]
    GameObject ARCamera;

    public GameObject spawnedObject;

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();

        if (placementUpdate == null)
            placementUpdate = new UnityEvent();

        placementUpdate.AddListener(DisableVisual);
        PortalEnvironment.SetActive(false);
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    [ContextMenu("Spawn Env")]
    public void SpawnPortal()
    {
        PortalEnvironment.transform.position = ARCamera.transform.position + ARCamera.transform.forward * 1.5f + new Vector3(0f, 1f,0f);
        PortalEnvironment.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, ARCamera.transform.rotation.eulerAngles.y));
        PortalEnvironment.SetActive(true);
        visualObject.SetActive(false);
        //spawnedObject = Instantiate(PortalEnvironment, ARCamera.transform.position, Quaternion.Euler(new Vector3(-90f, 0f, -90f)));
        //spawnedObject.SetActive(true);
        EventsManager.PortalSpawned();
    }

    public void DisableVisual()
    {
        visualObject.SetActive(false);
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;
}
