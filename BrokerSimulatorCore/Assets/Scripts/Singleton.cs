using UnityEngine;

namespace Assets.Scripts
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
       
        protected static T instance;
        public static T Instance {
            get {
                if (instance == null) {
                    instance = GameObject.FindObjectOfType (typeof (T)) as T;

                    if (instance == null) {
                        Debug.LogError ("instance of " + typeof (T) + " is needed in the scene.");
                    }
                }

                return Instance;
            }
        }
    }
}