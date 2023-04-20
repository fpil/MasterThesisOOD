using System.Collections.Generic;
using UnityEngine;

namespace OOD.Scripts.Enemies
{
    public class ThrowablePool : MonoBehaviour
    {
        private List<GameObject> throwablePool = new List<GameObject>(); 
        private List<GameObject> unavailableThrowablePool = new List<GameObject>();
        
        public void CreatePool(GameObject throwablePrefab, int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                var newThrowable = Instantiate(throwablePrefab, Vector3.zero, Quaternion.identity);
                newThrowable.SetActive(false);
                newThrowable.AddComponent<Throwable>();
                throwablePool.Add(newThrowable);
            }
        }
        public GameObject GetThrowableFromPool()
        {
            foreach (var throwable in throwablePool)
            {
                if (!throwable.activeInHierarchy)
                {
                    throwable.SetActive(true);
                    throwablePool.Remove(throwable);
                    unavailableThrowablePool.Add(throwable);
                    return throwable;
                }
            }
            return null;
        }
    
        public void ReturnThrowableToPool(GameObject throwable)
        {
            throwable.SetActive(false);
            throwablePool.Add(throwable);
            unavailableThrowablePool.Remove(throwable);
        }
        
        public void EmptyThrowableToPools()
        {
            foreach (var gameObject in throwablePool)
            {
                Destroy(gameObject);
            }
            throwablePool.Clear();
            foreach (var gameObject in unavailableThrowablePool)
            {
                Destroy(gameObject);
            }
            unavailableThrowablePool.Clear();
        }
    }
}
