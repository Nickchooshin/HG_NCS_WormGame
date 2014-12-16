using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {

	public Texture2D health1, health2, health3 ;
	public static int LIVES = 3 ;

	void Update () {
		switch (LIVES) {
		case 3 :
			guiTexture.texture = health3 ;
			break ;
			
		case 2 :
			guiTexture.texture = health2 ;
			break ;

		case 1 :
			guiTexture.texture = health1 ;
			break ;
			
		case 0 :
            Application.LoadLevel(2);
			break ;
		}
	}
}
