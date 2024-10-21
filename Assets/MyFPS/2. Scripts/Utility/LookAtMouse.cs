using UnityEngine;

namespace MyFPS
{
    public class LookAtMouse : MonoBehaviour
    {
        #region Variables
        private Vector3 mousePosition;
        private Vector3 worldPosition;
        #endregion

        private void Update()
        {
            worldPosition = ScreenToWorld();
            transform.LookAt(worldPosition);
        }

        Vector3 ScreenToWorld()
        {
            Vector2 vector2 = Input.mousePosition;
            mousePosition = vector2;
            mousePosition.z = 1;

            // 마우스 포인터의 위치를 월드 좌표로 변환
            Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);

            return position;
        }
    }
}