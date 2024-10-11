using System.Collections;
using UnityEngine;

namespace MyFPS
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;
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

            yield return null;
        }
    }
}