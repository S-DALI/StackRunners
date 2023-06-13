using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ExtraAssets.Scripts 
{

    [CreateAssetMenu(fileName = "EnvironmetsData", menuName = "ScriptableObject/Roads/EnvironmetsData")]
    public class EnvironmetsData : ScriptableObject
    {
        [SerializeField] private GameObject cubePickup;
        [SerializeField] private GameObject[] obstaclePrefab;

        public GameObject cube { get=>cubePickup;}
        public GameObject[] obstacles { get=>obstaclePrefab;}

    }
}
