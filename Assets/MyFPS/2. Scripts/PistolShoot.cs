using System.Collections;
using UnityEngine;

namespace MyFPS
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        // 연사 딜레이
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;

        public Transform firePoint;
        [SerializeField] private float attackDamage = 5f;

        private Animator animator;
        public AudioSource pistolShot;
        public ParticleSystem muzzle;
        #endregion

        void Start()
        {
            // 컴포넌트 초기화
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            // 격발
            if (Input.GetButtonDown("Fire") && !isFire)
                StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            try
            {
                isFire = true;
                float maxDistance = 100f;

                if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out RaycastHit hit, maxDistance))
                {
                    //적에게 대미지
                    IDamagable robot = hit.transform.GetComponent<IDamagable>();
                    if (robot != null)
                    {
                        robot.TakeDamage(attackDamage);
                    }
                }
            }

            catch
            {
                Debug.Log("타겟이 없어");
            }

            animator.SetTrigger("ShootTrigger");

            yield return null;

            pistolShot.Play();
            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);

            muzzle.Stop();

            isFire = false;

            yield break;
        }

        // Gizmo 그리기 : 카메라 위치에서 앞의 충돌체까지 레이저를 쏘는 선 그리기
        private void OnDrawGizmos()
        {
            float distance;
            float maxDistance = 100f;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out RaycastHit hit, maxDistance);

            Gizmos.color = Color.red;

            switch (isHit)
            {
                case true:
                    distance = hit.distance;
                    break;

                case false:
                    distance = maxDistance;
                    break;
            }

            Gizmos.DrawRay(firePoint.position, firePoint.forward * distance);
        }
    }
}