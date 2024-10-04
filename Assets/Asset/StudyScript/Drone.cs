using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

//Pool에 넣을 엔티티 클래스
namespace ObjectPool
{
    public class Drone : MonoBehaviour
    {
        //자기를 엔티티로 가지는 풀을 자기 자신이 멤버로 가지고 있다.
        public IObjectPool<Drone> pool { get; set; }

        public float _currentHealth;

        [SerializeField]
        private float maxHealth = 100.0f;

        [SerializeField]
        private float timeToSelfDestruct = 3.0f;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        private void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        private void OnDisable()
        {
            ResetDrone();
        }

        private void ResetDrone()
        {
            _currentHealth = maxHealth;
        }

        private IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }

        private void ReturnToPool()
        {
            //풀로 다시 돌려보내기
            pool.Release(this);
        }

        private void AttackPlayer()
        {
            Debug.Log("Attack");
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0.0f)
                ReturnToPool();
        }
    }
}
