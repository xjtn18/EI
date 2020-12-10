using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	void Awake(){
		GameObject[] objs = GameObject.FindGameObjectsWithTag("audio");
		if (objs.Length > 2){
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}

}

