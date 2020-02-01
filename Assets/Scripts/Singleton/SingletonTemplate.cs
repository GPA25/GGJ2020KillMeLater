using UnityEngine;
using System.Collections;


/// <summary>
/// Inherit from this base class to create a SingletonTemplate.
/// e.g. public class MyClassName : SingletonTemplate<MyClassName> {}
/// </summary>
public class SingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
{
    // Check to see if we're about to be destroyed.
    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();
    private static T instance;
 
    /// <summary>
    /// Access SingletonTemplate instance through this propriety.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (m_ShuttingDown)
            {
                Debug.LogWarning("[SingletonTemplate] Instance '" + typeof(T) +
                    "' already destroyed. Returning null.");
                return null;
            }
 
            lock (m_Lock)
            {
                if (instance == null)
                {
                    // Search for existing instance.
                    instance = (T)FindObjectOfType(typeof(T));
 
                    // Create new instance if one doesn't already exist.
                    if (instance == null)
                    {
                        // Need to create a new GameObject to attach the SingletonTemplate to.
                        var SingletonTemplateObject = new GameObject();
                        instance = SingletonTemplateObject.AddComponent<T>();
                        SingletonTemplateObject.name = typeof(T).ToString() + " (SingletonTemplate)";
 
                        // Make instance persistent.
                        DontDestroyOnLoad(SingletonTemplateObject);
                    }
                }
 
                return instance;
            }
        }
    }
 
 
    private void OnApplicationQuit()
    {
        m_ShuttingDown = true;
    }
 
 
    private void OnDestroy()
    {
        m_ShuttingDown = true;
    }
}