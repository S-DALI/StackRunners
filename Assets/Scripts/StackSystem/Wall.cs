using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool isAbleToStop = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isAbleToStop) return;
        CubeStack playerCubeStack = collision.transform.GetComponentInParent<CubeStack>();

        if (playerCubeStack != null) StopCube(playerCubeStack);
    }

    private void StopCube(CubeStack playerCubeStack)
    {
        isAbleToStop = false;
        StartCoroutine(playerCubeStack.RemoveCube());
    }
}
