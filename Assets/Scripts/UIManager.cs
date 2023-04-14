using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Cube;
    private bool isCubeON;
    // Start is called before the first frame update
    void Start()
    {
        isCubeON = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCube()
    {
        if (isCubeON)
        {
            Cube.SetActive(false);
            isCubeON = false;
        }

        else if (!isCubeON)
        {
            Cube.SetActive(true);
            isCubeON = true;
        }
    }
}
