using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class PickUpPistol : Interactive
    {
        // 필드
        #region Variables
        // Action
        public GameObject arrow;
        public GameObject realPistol;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        private void Start()
        {
            action = "Pickup the Pistol";
        }
        #endregion

        // 메서드
        #region Methods
        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }
        #endregion
    }
}