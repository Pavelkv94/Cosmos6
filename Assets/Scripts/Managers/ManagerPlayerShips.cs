using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IG
{

    public class ManagerPlayerShips : MonoBehaviour
    {
        public int CurrentShipId;//текущий корабль ID
        public Transform ShipVisuals;//контейнер с нашими кораблями ShipVisuals
        public GameObject CurrentShip; //обьект текущего корабля
        [SerializeField] private List<GameObject> shipsPrefabs = new List<GameObject>();//массив кораблей
        void Update()
        {
            if(Input.GetButtonDown("ShipChange")) {
                ChangeShipToNext();
            }
        }


        void ChangeShipToNext()
        {
            CurrentShipId++; //добавляем 1 к айдишнику корабля(меняем корабль)

            //Если дошли до конца то выбираем первый корабль
            if(CurrentShipId == shipsPrefabs.Count) { 
                CurrentShipId = 0;
            }
        }
        void ChangeShip(int id)
        {
            Destroy(CurrentShip);//удаляем текущий корабль

            CurrentShip = Instantiate(shipsPrefabs[CurrentShipId], ShipVisuals);//меняем на новый
        }
    }

}