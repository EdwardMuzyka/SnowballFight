using Spine.Unity;
using UnityEngine;

namespace SnowballFight
{
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation = null;
        [SerializeField] private string _runAnimation = null;
        [SerializeField] private string _idleAnimation = null;
        [SerializeField] private string _throwAnimation = null;

        public void Run()
        {
            _skeletonAnimation.state.SetAnimation(0, _runAnimation, true);            
        }

        public void Idle()
        {
            _skeletonAnimation.state.SetAnimation(0, _idleAnimation, true);
        }

        public void ThrowSnowball()
        {
            _skeletonAnimation.state.SetAnimation(0, _throwAnimation, false);
        }

        public void SetAnimationName(string animationName, bool isLooped)
        {
            _skeletonAnimation.state.SetAnimation(0, animationName, isLooped);
        }        
    }
}