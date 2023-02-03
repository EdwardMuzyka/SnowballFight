using System.Collections.Generic;
using UnityEngine;

namespace SnowballFight
{
    public class ProjectilePool : MonoBehaviour
    {
        //[SerializeField] private GameObject _prefab = null;
        [SerializeField] private int _poolCount = 0;
        [SerializeField] private GameObject _projectile = null;

        private List<Projectile> _projectiles = new List<Projectile>();

        private void Awake()
        {
            Init();            
        }

        private void Init()
        {            
            for (int i = 0; i < _poolCount; i++)
            {
                GameObject obj = Instantiate(_projectile, transform, true);
                obj.SetActive(false);
                _projectiles.Add(obj.GetComponent<Projectile>());
            }
        }

        public Projectile GetProjectile(Transform pos)
        {
            for (int i = 0; i < _projectiles.Count; i++)
            {
                if (!_projectiles[i].gameObject.activeInHierarchy)
                {
                    _projectiles[i].transform.position = pos.position;
                    _projectiles[i].gameObject.SetActive(true);
                    return _projectiles[i];
                }
            }
            GameObject obj = Instantiate(_projectile, transform, true);
            _projectiles.Add(obj.GetComponent<Projectile>());
            return obj.GetComponent<Projectile>();
        }       

        public void DisableProjectiles()
        {
            for (int i = 0; i < _projectiles.Count; i++)
            {
                Destroy(_projectiles[i].gameObject);
                //_projectiles[i].gameObject.SetActive(false);                
            }
        }
    }
}