using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool isAttached = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isAttached) return;
        
        CubeStack playerCubeStack = collision.transform.GetComponentInParent<CubeStack>();

        if (playerCubeStack != null) AddCube(playerCubeStack);
    }

    private void AddCube(CubeStack playerCubeStack)
    {
        isAttached = true;
        playerCubeStack.AddCube(transform);
    }
}
