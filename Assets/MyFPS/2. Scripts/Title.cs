using System.Collections;
using UnityEngine;

namespace MyFPS
{
    public class Title : MonoBehaviour
    {
        #region Variables
        private bool isKeyShow = false;
        public SceneFader fader;
        public GameObject anyKeyUI;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        private void Start()
        {
            fader.FadeFrom();
            StartCoroutine(TitleProcess());
        }

        private void Update()
        {
            if (Input.anyKey && isKeyShow)
            {
                GoToMenu();
            }
        }

        void GoToMenu()
        {
            fader.FadeTo(loadToScene);
            StopAllCoroutines();
        }

        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(3);
            anyKeyUI.SetActive(true);
            isKeyShow = true;
            yield return new WaitForSeconds(10);
            GoToMenu();
            yield break;
        }
    }
}