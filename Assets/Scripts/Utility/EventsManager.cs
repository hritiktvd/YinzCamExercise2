using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public delegate void SpawnPortal();
    public static event SpawnPortal onPortalSpawn;

    public delegate void EnterPortal();
    public static event EnterPortal onPortalEnter;

    public delegate void ExitPortal();
    public static event ExitPortal onPortalExit;

    public static void PortalSpawned() { onPortalSpawn?.Invoke(); }
    public static void PortalEntered() { onPortalEnter?.Invoke(); }
    public static void PortalExited() { onPortalExit?.Invoke(); }
}
