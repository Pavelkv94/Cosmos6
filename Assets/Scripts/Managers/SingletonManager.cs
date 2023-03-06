using UnityEngine;

namespace IG
{
    public class SingletonManager<T> : MonoBehaviour where T : Component
    {
        //Благодаря Синглтрону мы можем прописывать переменные котоыре будут доступны везде, 
        //например переменную Debugging которая если ТРУ то можем в любом скрипте дебажить код
        // if (Debugging) Debug.Log('Message')
        public bool Debugging;
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}