using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Cosmos6
{
    //Класс который представляет собой подсистему вооружения

    public class ShipWeapons : MonoBehaviour
    {
        public Spaceship _Spaceship;

        //список оружия
        public List<IWeapon> Weapons = new List<IWeapon>();

        public float MaxDistanceToTarget = 250f;
        //Awake срабатывает перед Start
        private void Awake()
        {
            if (_Spaceship == null)
                _Spaceship = GetComponentInParent<Spaceship>();
            Weapons = GetComponentsInChildren<IWeapon>().ToList();
        }

        // Update is called once per frame
        void Update()
        {
            //По нажатию кнопки мыши
            if (Input.GetMouseButtonDown(0))
                FireWeapons();
        }

        public void FireWeapons()
        {
            //стрельба в центр экрана всегда
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out hit, MaxDistanceToTarget))
            {

                foreach (var weapon in Weapons)
                {
                    weapon.FireWeapon(hit.point);
                    // weapon.FireWeapon(transform.position + transform.forward * MaxDistanceToTarget); //стреляем из нашей позиции + вперед * максимальная дистанция
                }
            }
            else
            { //если не попали
                foreach (var weapon in Weapons)
                {
                    weapon.FireWeapon(ray.origin + ray.direction * MaxDistanceToTarget);
                    // weapon.FireWeapon(transform.position + transform.forward * MaxDistanceToTarget); //стреляем из нашей позиции + вперед * максимальная дистанция
                }
            }


        }
    }
}