using UnityEngine;

namespace Dono.UtilitiesForUnity.Components
{
    public class OneShotObjectWithDisplay : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        [SerializeField] private float elapsedTime = 0;
        private float _elapsedTime;

        public void Update()
        {
            _elapsedTime += Time.deltaTime;
            elapsedTime = _elapsedTime;
            if (_elapsedTime > lifeTime)
                Destroy(gameObject);
        }
    }
}