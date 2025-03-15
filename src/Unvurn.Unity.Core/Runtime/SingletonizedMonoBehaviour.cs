using System;
using UnityEngine;

namespace Unvurn.Unity
{
    // 継承したMonoBehaviourをシングルトンとして扱い、アプリケーション起動中の唯一インスタンスとしての動作を保証する。
    public class SingletonizedMonoBehaviour<T> : MonoBehaviour
        where T : SingletonizedMonoBehaviour<T>
    {
        public virtual void Awake()
        {
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(this);
            }

            if (_instance != null)
            {
                DestroyImmediate(gameObject);
            }
        }

        protected bool Initialized;

        protected virtual void Initialize() { }

        #region static fields and methods
        public static T Instance
        {
            get
            {
                CreateInstance();
                if (_instance == null)
                {
                    throw new NullReferenceException("Instance is null");
                }
                return _instance;
            }
        }

        private static void CreateInstance()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = FindFirstObjectByType<T>();
            if (_instance == null)
            {
                _instance = new GameObject(typeof(T).Name).AddComponent<T>();
            }

            if (!_instance.Initialized)
            {
                _instance.Initialize();
                _instance.Initialized = true;
            }
        }

        private static T? _instance;
        #endregion
    }
}
