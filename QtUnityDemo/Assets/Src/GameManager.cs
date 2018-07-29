using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	// Use this for initialization
	void Start () {
        InitializeServices();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeServices() {
        MetadataLoader.Instance.Initialize();
    }
}
