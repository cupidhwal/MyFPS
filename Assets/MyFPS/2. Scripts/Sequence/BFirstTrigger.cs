using System.Collections;
using UnityEngine;
using TMPro;

namespace MyFPS
{
    public class BFirstTrigger : MonoBehaviour
    {
        // 필드
        #region Variables
        public GameObject player;
        public GameObject arrow;

        // 시나리오 시퀀스 관련 필드
        [SerializeField] private string text = "Looks like a weapon on that table";
        public TextMeshProUGUI sequenceText;
        #endregion

        // 기타 유틸리티
        #region Utilities
        IEnumerator PlaySequence()
        {
            // 1. 플레이어 캐릭터 비활성화
            player.SetActive(false);

            // 2. 화면 하단에 시나리오 텍스트 출력 (3초)
            sequenceText.gameObject.SetActive(true);
            sequenceText.text = text;

            // 3. 1초 Delay
            yield return new WaitForSeconds(1);

            // 4. Arrow 오브젝트 활성화
            arrow.SetActive(true);

            // 5. 1초 Delay
            yield return new WaitForSeconds(1);

            // 6. 트리거 비활성화
            this.transform.gameObject.SetActive(false);

            // 7. 플레이어 캐릭터 활성화
            player.SetActive(true);

            // 8. 시퀀스 텍스트 제거
            sequenceText.gameObject.SetActive(false);
        }
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }
    }
}