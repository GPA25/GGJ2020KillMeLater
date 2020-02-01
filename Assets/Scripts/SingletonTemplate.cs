using UnityEngine;
using System.Collections;

public class SingletonTemplate : MonoBehaviour {

	/// Static instance of Singleton Class which allows it to be accessed by any other script
	private static SingletonTemplate _instance = null;
	
	/// <summary>
	/// Gets the instance of the Singleton Class
	/// If there is not an instance, Singleton Class will generate a gameObject "MySingletonClass" in current scene.
	/// The instance game object will not be destroyed when load new scene.
	/// </summary>
	/// <value>The instance in the scene.</value>
	public static SingletonTemplate Instance {
		get {
			if (!_instance) {
				_instance = FindObjectOfType(typeof(SingletonTemplate)) as SingletonTemplate;
				
				if (!_instance) {
					var obj = new GameObject("SingletonTemplate");
					_instance = obj.AddComponent<SingletonTemplate>();
				} else {
					_instance.gameObject.name = "SingletonTemplate";
				}
			}
			return _instance;
		}
	}
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// Awake is used to initialize any variables or game state before the game starts.
	/// Awake is called only once during the lifetime of the script instance.
	/// </summary>
	void Awake() {
		if (_instance == null) {
			_instance = this;
			// Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(_instance.gameObject);
		} else if (_instance != this) {
			// If there's any other object exist of this type delete it
			// as it's breaking our singleton pattern
			Destroy(gameObject);
		}
	}
}