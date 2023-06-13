using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ExtraAssets.Scripts
{
    public class EffectController : MonoBehaviour
    {

        [SerializeField] ParticleSystem cubeStackEffect;
        [SerializeField] ParticleSystem warpEffect;

        [SerializeField] CubeStack cubeStack;
        [SerializeField] MenuController menuController;

        private void Start()
        {
            cubeStack.addCube += AddCube;
            cubeStack.removeCube += Vibration;

            menuController.startGame+= StartGame;
            menuController.endGame+= EndGame;
        }

        private void AddCube()
        {
            cubeStackEffect.Play();
        }

        private void StartGame()
        {
            warpEffect.Play();
        }
    
        private void EndGame()
        {
            warpEffect.Stop();
        }

        private void Vibration()
        {
            Handheld.Vibrate();
        }
    }
}
