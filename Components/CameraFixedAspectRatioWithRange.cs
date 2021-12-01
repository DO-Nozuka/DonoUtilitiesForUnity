using UnityEngine;

namespace Dono.UtilitiesForUnity.Components
{
    /// <summary>
    /// アスペクト比を(AspectRatio - aspectRangeOffsetN) ～ (AspectRatio + aspectRangeOffsetP)の範囲内にする
    /// </summary>
    [ExecuteAlways]
    public class CameraFixedAspectRatioWithRange : MonoBehaviour
    {
        private Camera Camera;
        [SerializeField, Range(0, 1)] private float aspectRangeOffsetP = 0.2f;
        [SerializeField, Range(0, 1)] private float aspectRangeOffsetN = 0.2f;
        
        [SerializeField] private float baseWidth = 16.0f;
        [SerializeField] private float baseHeight = 9.0f;

        [SerializeField, Tooltip("for display only")] private float CurrentAspect = 1.777778f;

        private float baseAspect => baseWidth / baseHeight;
        private float aspectRangeMax => baseAspect + aspectRangeOffsetP;
        private float aspectRangeMin => baseAspect - aspectRangeOffsetN;

        // Start is called before the first frame update
        void Start()
        {
            Camera = GetComponent<Camera>();

            UpdateAspect();
        }

        void Awake()
        {
        }

        void UpdateAspect()
        {
            Vector2 target = GetTargetSize();

            SetAspect(target);
        }

        private void SetAspect(Vector2 target)
        {
            var scale = Mathf.Min(Screen.height / target.y, Screen.width / target.x);
            var projectionSize = target * scale;
            var projectionNormal = new Vector2(projectionSize.x / Screen.width, projectionSize.y / Screen.height);
            var origin = new Vector2(0.5f, 0.5f) - projectionNormal / 2.0f;

            Camera.rect = new Rect(origin.x, origin.y, projectionNormal.x, projectionNormal.y);

            CurrentAspect = Camera.aspect;

            Canvas.ForceUpdateCanvases();
        }

        private Vector2 GetTargetSize()
        {
            Vector2 target = new Vector2(baseWidth, baseHeight);

            if(Screen.width == 0 || Screen.height == 0)
            {
                target.x = baseWidth;
                target.y = baseHeight;
                return target;
            }

            float screenAspect = (float)Screen.width / (float)Screen.height;

            if (aspectRangeMin <= screenAspect && screenAspect <= aspectRangeMax)
            {
                target.x = Screen.width;
                target.y = Screen.height;
            }
            else if (screenAspect < aspectRangeMin)
            {
                target.y = Screen.height;
                target.x = Screen.height * aspectRangeMin;
            }
            else if (screenAspect > aspectRangeMax)
            {
                target.y = Screen.height;
                target.x = Screen.height * aspectRangeMax;
            }

            return target;
        }

        // Update is called once per frame
        void Update()
        {
            if (CurrentAspect != Camera.aspect)
            {
                UpdateAspect();
            }
        }
    }
}