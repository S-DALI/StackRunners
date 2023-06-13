using Assets.ExtraAssets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CubeStack : MonoBehaviour
{
    private Stack<Transform> cubes = new Stack<Transform>();

    [SerializeField] Transform lowestPoint;
    [SerializeField] Transform cubeTrashCan;
    [SerializeField] private float cubeDestroyDuration = 1.5f;

    [Header("Player Settings")]
    [SerializeField] private PlayerMove player;

    public event Action addCube;
    public event Action defeated;
    public event Action removeCube;

    public void AddCube(Transform cubeToAdd)
    {
        transform.position += Vector3.up;
        lowestPoint.localPosition += Vector3.down;

        addCube?.Invoke();

        cubeToAdd.SetParent(transform);
        cubeToAdd.localPosition = new Vector3(lowestPoint.localPosition.x, lowestPoint.localPosition.y, lowestPoint.localPosition.z);

        cubes.Push(cubeToAdd);
    }

    public IEnumerator RemoveCube()
    {
        if (cubes.Count == 0 )
        {
            defeated?.Invoke();
            player.StopRun();

            yield return null;
        }
        else
        {
            Transform cubeToRemove = cubes.Pop();

            removeCube?.Invoke();

            cubeToRemove.SetParent(cubeTrashCan);
            lowestPoint.localPosition += Vector3.up;

            yield return new WaitForSeconds(cubeDestroyDuration);
                Destroy(cubeToRemove.gameObject);
        }
    }

}
