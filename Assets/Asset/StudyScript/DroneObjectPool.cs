using UnityEngine;
using UnityEngine.Pool;


namespace ObjectPool
{
    //ObjectPool을 관리하는 클래스
    public class DroneObjectPool : MonoBehaviour
    {
        public int maxPoolSize = 10;
        public int stackDefaultCapacity = 10;

        //오브젝트 풀을 초기화한다.
        public IObjectPool<Drone> pool
        {
            get
            {
                if(_pool == null)
                {
                    //Object Pool의 생성자의 인자로, Call-back들을 전달함.
                    _pool = new ObjectPool<Drone>(
                                CreatedPoolItem,
                                OnTakeFromPool,
                                OnReturnedToPool,
                                OnDestroyPoolObject,
                                true,
                                stackDefaultCapacity,
                                maxPoolSize);
                }
                return _pool;
            }
        }

        private IObjectPool<Drone> _pool;

        //Pool의 아이템을 만들어주는 Call-back;
        //Drone 인스턴스를 만들어준다. 프리팹을 로드하는게 좋다.
        private Drone CreatedPoolItem()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Drone drone = go.AddComponent<Drone>();

            go.name = "Drone";
            //드론이 스스로 풀로 돌아가기 위해, Object Pool을 알고있는다.
            drone.pool = pool;

            return drone;
        }

        private void OnReturnedToPool(Drone drone)
        {
            drone.gameObject.SetActive(false);
        }

        private void OnTakeFromPool(Drone drone)
        {
            drone.gameObject.SetActive(true);
        }

        private void OnDestroyPoolObject(Drone drone)
        {
            Destroy(drone);
        }

        //클라이언트가 오브젝트를 요청했을때, 풀에서 오브젝트를 꺼내 무작위 위치에 배치한다.
        public void Spawn()
        {
            var amount = Random.Range(1, 10);

            for(int i = 0; i < amount; ++i)
            {
                var drone = pool.Get();

                //게임 오브젝트에 붙어있는 컴포넌트로 조작이 가능하구나
                drone.transform.position = Random.insideUnitSphere * 10;
            }
        }
    }
}