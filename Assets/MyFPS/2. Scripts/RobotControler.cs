using UnityEngine;

namespace MyFPS
{
    // 로봇 상태
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }

    public class RobotControler : MonoBehaviour
    {
        #region Variables
        // 복합 변수
        private RobotState currentState;    // 로봇 상태 (enum)
        private RobotState beforeState;

        // 컴포넌트
        private Animator animator;
        #endregion

        #region Life Cycle
        private void Start()
        {
            // 컴포넌트 초기화
            animator = GetComponent<Animator>();

            SetState(RobotState.R_Idle);
        }

        // 로봇의 상태 변경
        private void SetState(RobotState newState)
        {
            // 현재 상태 체크
            if (currentState == newState) return;

            // 이전 상태 저장
            beforeState = currentState;

            // 상태 변경
            currentState = newState;

            animator.SetInteger("RobotState", (int)newState);
        }
        #endregion
    }
}