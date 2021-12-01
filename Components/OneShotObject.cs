using UnityEngine;

namespace Dono.UtilitiesForUnity.Components
{
    public class OneShotObject : MonoBehaviour
    {
        [SerializeField] private float lifeTime;

        public void Start()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}