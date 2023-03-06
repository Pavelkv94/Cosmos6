using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos6
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour, IWeapon
    {
        public bool CanFire;
        public float MaxDistance = 100f;
        public float DamageAmount = 5f;

        public Coroutine _coroutineFiring;
        private WaitForSeconds _waitForFiring;
        [SerializeField] private float _waitTimeFiring = 0.1f;

        [Header("Links")]
        [SerializeField] private LineRenderer _lineRenderer;
        private ShipWeapons _ShipWeapons;
        private List<IDamagedable> TargetsHit = new List<IDamagedable>();

        //Awake срабатывает перед Start
        private void Awake()
        {
            if (_ShipWeapons == null)
                _ShipWeapons = GetComponentInParent<ShipWeapons>();

            //Если оружия  нет  на старте то получаем компонент
            if (_lineRenderer == null)
                _lineRenderer = GetComponent<LineRenderer>();
        }

        void Start()
        {
            _waitForFiring = new WaitForSeconds(_waitTimeFiring);
            //Изначально оружие выключено
            _lineRenderer.enabled = false;
            //включаем возможность стрелять
            CanFire = true;
        }

        public Vector3 FireWeapon(Vector3 targetPosition)
        {

            RaycastHit hitInfo;
            var direction = targetPosition - transform.position; //вектор атаки

            //стреляем в точку но если там нчиего нету то стреляем на максимальную дистанцию
            VisualFireWeapon(transform.position + direction.normalized * MaxDistance);

            if (Physics.Raycast(transform.position, direction, out hitInfo, MaxDistance))
            { //out записывает информацию об обьекте в переменную, в который мы попали

                var targetHit = hitInfo.transform; //Если попали в обьект у которого есть коллайдер, то он попадает в targetHit
                //если попали то получаем позицию цели
                if (targetHit != null)
                {
                    Debug.Log($"FireWeapon target hit: {targetHit.name}");
                    var damagedableHit = targetHit.GetComponent<IDamagedable>();
                    if (damagedableHit != null)
                    {
                        TargetsHit.Add(damagedableHit);
                        Damage(DamageAmount, targetHit.position, _ShipWeapons._Spaceship.ShipAgent);
                    }

                    VisualFireWeapon(targetHit.position);

                    return targetHit.position;
                }
            }

            //Если не попадаем ни в кого
            return targetPosition;

        }

        public void Damage(float DamageAmount, Vector3 targetHitPosition, GameAgent sender)
        {
            foreach (var targetHit in TargetsHit)
            {
                targetHit.ReceiveDamage(DamageAmount, targetHitPosition, sender);
            }
            TargetsHit.Clear(); //очищаем список целей чтобы после уничтожения их не дергать

        }

        public void VisualFireWeapon(Vector3 targetPosition)
        {
            if (CanFire)
            {
                _lineRenderer.enabled = true;
                //определяем точки между которыми строится линия лазера
                _lineRenderer.SetPosition(0, transform.position);//точка начала выстрела
                _lineRenderer.SetPosition(1, targetPosition);//точка цели

                //выключаем пушку после выстрела
                CanFire = false;

                _coroutineFiring = StartCoroutine(FiringCor());
            }
        }


        private IEnumerator FiringCor()
        {
            yield return _waitForFiring;

            CanFire = true;
            _lineRenderer.enabled = false;
        }
    }
}


