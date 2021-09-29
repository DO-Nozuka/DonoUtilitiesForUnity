using UnityEngine;

namespace Dono.UtilitiesForUnity.Components
{
    [ExecuteInEditMode]
    public class CameraFixedAspectRatio : MonoBehaviour
    {
        private Camera Camera;
        public float baseWidth = 16.0f;
        public float baseHeight = 9.0f;

        public float CurrentAspect;

        // Start is called before the first frame update
        void Start()
        {
        }

        void Awake()
        {
            Camera = GetComponent<Camera>();

            UpdateAspect();
        }

        void UpdateAspect()
        {
            // アスペクト比固定
            var scale = Mathf.Min(Screen.height / baseHeight, Screen.width / baseWidth);
            var width = (baseWidth * scale) / Screen.width;
            var height = (baseHeight * scale) / Screen.height;
            Camera.rect = new Rect((1.0f - width) * 0.5f, (1.0f - height) * 0.5f, width, height);

            /*
            float TargetAspect = baseWidth / baseHeight;
            float ScreenAspect = (float)Screen.width / Screen.height;

            //画面が縦長の場合(上下に黒が入る)
            if (TargetAspect > ScreenAspect)
            {
                Camera.rect = new Rect(0, 0.5f - (TargetAspect / ScreenAspect) / 2, 1, (TargetAspect / ScreenAspect));
            }
            else//画面が横長の場合(左右に黒が入る)
            {
                Camera.rect = new Rect(0.5f - ((TargetAspect / ScreenAspect) / 2), 0, (TargetAspect / ScreenAspect), 1);
            }
            */


            CurrentAspect = Camera.aspect;

            Canvas.ForceUpdateCanvases();
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