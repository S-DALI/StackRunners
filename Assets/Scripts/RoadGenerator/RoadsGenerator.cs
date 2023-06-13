using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ExtraAssets.Scripts
{
    public class RoadsGenerator : MonoBehaviour
    {
        [SerializeField] private Road roads;
        [SerializeField] private Transform player;
        [SerializeField] private int ñurrentRoadCount;
        [SerializeField] private EnvironmetsData environments; 

        private List<Road> roadsList = new List<Road>();
        private int amountCubes = 3;
        void Start()
        {
            for (int i = 0; i < ñurrentRoadCount; i++)
            {
                SpawnRoad();
            }
        }

        void Update()
        {
            if (player.position.z > roadsList[1].endRoad.position.z) 
            {
                SpawnRoad();
            }
        }
        private void SpawnRoad()
        {
            Road newRoad = Instantiate(roads);

            if (roadsList.Count != 0)
                newRoad.transform.position = roadsList[roadsList.Count - 1].endRoad.position - newRoad.beginRoad.localPosition;
            else newRoad.transform.position = new Vector3(0, 0, 0);

            newRoad.CreateObstacle(environments.obstacles[Random.Range(0, environments.obstacles.Length-1)]);
            newRoad.CreateCube(-2, 2, amountCubes, environments.cube);

            roadsList.Add(newRoad);

            if(roadsList.Count > ñurrentRoadCount)
                DeleteRoad();
        }

        private void DeleteRoad()
        {
            Destroy(roadsList[0].gameObject);
            roadsList.RemoveAt(0);
        }
    }
}