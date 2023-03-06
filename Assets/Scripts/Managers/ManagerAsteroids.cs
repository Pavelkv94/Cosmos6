using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAsteroids : MonoBehaviour
{
    public GameObject AsteroidPrefab;
    public int NumberOfAsteroindsOnAxisX = 10;    //количество астероидов на одну ось X
    public int NumberOfAsteroindsOnAxisY = 10;    //количество астероидов на одну ось Y
    public int NumberOfAsteroindsOnAxisZ = 10;    //количество астероидов на одну ось Z

    public int GridSpasing = 10;    //размер пространства между ними


    private void Start()
    {
        for (int i = 0; i < NumberOfAsteroindsOnAxisX; i++)
        {
            for (int j = 0; j < NumberOfAsteroindsOnAxisY; j++)
            {
                for (int k = 0; k < NumberOfAsteroindsOnAxisZ; k++)
                {
                    InstantiateAsteroids(i, j, k);
                }
            }
        }
    }

    // Update is called once per frame
    private void InstantiateAsteroids(int x, int y, int z)
    {
        Instantiate(AsteroidPrefab, new Vector3(
            transform.position.x + x * GridSpasing + OffsetAsteroid(),
            transform.position.y + y * GridSpasing + OffsetAsteroid(),
            transform.position.z + z * GridSpasing + OffsetAsteroid()), Quaternion.identity, transform);
    }

    private float OffsetAsteroid() {
        //метод для рандома размещения астероидов в поле. /4 это значит разбежка на четверть
        //разделитель минимум 2 чтобы астероиды не проникали вдруг в друга
        return Random.Range(-GridSpasing/4f, GridSpasing/4f);
    }
}
