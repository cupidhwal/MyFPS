using System.Collections;
using UnityEngine;

namespace MyFPS
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;      // 문
        public AudioSource doorBang;    // 문 열기 사운드

        public AudioSource jumpScare;   // 적 등장 사운드
        public GameObject theRobot;     // 적
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        // 트리거 작동 시 플레이
        IEnumerator PlaySequence()
        {
            theDoor.GetComponent<Animator>().SetBool("isOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            // 문 사운드
            doorBang.Play();

            // Enemy 활성화
            theRobot.SetActive(true);

            yield return new WaitForSeconds(1);

            // 적 등장 사운드
            jumpScare.Play();

            Destroy(gameObject);

            yield break;
        }
    }
}