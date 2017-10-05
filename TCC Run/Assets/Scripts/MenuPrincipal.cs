using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Iniciar(){
		SceneManager.LoadScene ("Main");
	}

	public void Sair(){
		Application.Quit ();
	}
}
