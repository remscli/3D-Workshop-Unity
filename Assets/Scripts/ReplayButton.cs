﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour {

	public void ReplayGame(){
		SceneManager.LoadScene ("Scene 1");
	}
}
