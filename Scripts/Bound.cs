using UnityEngine;

namespace SnowballFight
{
    public class Bound : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}