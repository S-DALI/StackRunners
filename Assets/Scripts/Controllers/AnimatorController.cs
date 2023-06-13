using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ExtraAssets.Scripts
{
    public class AnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private CubeStack cubeStack;
        void Start()
        {
            cubeStack=GetComponent<CubeStack>();
            cubeStack.addCube += Jump;
            cubeStack.defeated += Defeat;
        }

        private void Jump()
        {
            animator.SetTrigger("Jump");
        }
        private void Defeat()
        {
            animator.SetTrigger("Defeated");
        }
    }
}
