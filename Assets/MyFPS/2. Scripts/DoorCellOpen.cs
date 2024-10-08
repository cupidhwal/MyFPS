using UnityEngine;
using TMPro;

namespace MyFPS
{
    // 문의 개폐를 전담하는 클래스
    public class DoorCellOpen : MonoBehaviour
    {
        // 필드
        #region Variables
        private float theDistance;

        public GameObject extraCross;
        public GameObject doorActionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Open the Door";

        // Action: 문 열기
        private Animator animator;
        public AudioSource audioSource;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        private void Start()
        {
            animator = GetComponentInParent<Animator>();
        }

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        #endregion

        // 메서드
        #region Methods
        private void SwitchActionUI(bool flag)
        {
            extraCross.SetActive(flag);
            doorActionUI.SetActive(flag);
        }
        #endregion

        // 이벤트 메서드
        #region Event Methods
        // 마우스를 가져다 대면 액션 UI를 보여준다
        private void OnMouseOver()
        {
            // 거리가 2이하 일때
            if (theDistance <= 2)
            {
                if (animator.GetBool("isOpen")) return;

                SwitchActionUI(true);
                actionText.text = action;

                if (Input.GetButtonDown("Action"))
                {
                    // 문이 열린다
                    animator.SetBool("isOpen", true);
                    audioSource.Play();
                }
            }

            else
            {
                SwitchActionUI(false);
            }
        }

        // 마우스를 가져다 대면 액션 UI를 보여준다
        private void OnMouseExit()
        {
            SwitchActionUI(false);
        }
        #endregion
    }
}