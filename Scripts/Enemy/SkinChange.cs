using Spine.Unity;
using UnityEngine;

namespace SnowballFight
{
    public class SkinChange : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation = null;
        [SerializeField] private string[] _skins = null;

        public void ChangeSkin()
        {
            int index = Random.Range(0, _skins.Length);
            _skeletonAnimation.skeleton.SetSkin(_skins[index]);
        }
    }
}