using System.Collections;
using UnityEngine;

namespace Assets.ExtraAssets.Scripts
{
    public class Road : MonoBehaviour
    {
        public Transform beginRoad;
        public Transform endRoad;
        public Transform pointObstacle;

        public void CreateObstacle(GameObject obstacle)
        {
            Instantiate(obstacle, pointObstacle);
        }

        public void CreateCube(float minX, float maxX, int amount,GameObject cube)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(cube, new Vector3(Random.Range(minX, maxX), pointObstacle.position.y, Random.Range(beginRoad.transform.position.z, pointObstacle.position.z-2f)), Quaternion.identity);
            }

        }
    }
}