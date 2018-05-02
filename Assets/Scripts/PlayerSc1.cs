using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSc1 : MonoBehaviour {

	public Dictionary<KeyCode, Vector2> keyPos =  new Dictionary<KeyCode, Vector2>();
	public KeyCode playerInput;

	// Use this for initialization
	void Start () {

		keyPos.Add (KeyCode.Q, GameObject.Find("Q").gameObject.transform.position);
		keyPos.Add (KeyCode.W, GameObject.Find("W").gameObject.transform.position);
		keyPos.Add (KeyCode.E, GameObject.Find("E").gameObject.transform.position);
		keyPos.Add (KeyCode.R, GameObject.Find("R").gameObject.transform.position);
		keyPos.Add (KeyCode.T, GameObject.Find("T").gameObject.transform.position);
		keyPos.Add (KeyCode.Y, GameObject.Find("Y").gameObject.transform.position);
		keyPos.Add (KeyCode.U, GameObject.Find("U").gameObject.transform.position);
		keyPos.Add (KeyCode.I, GameObject.Find("I").gameObject.transform.position);
		keyPos.Add (KeyCode.O, GameObject.Find("O").gameObject.transform.position);
		keyPos.Add (KeyCode.P, GameObject.Find("P").gameObject.transform.position);
		keyPos.Add (KeyCode.A, GameObject.Find("A").gameObject.transform.position);
		keyPos.Add (KeyCode.S, GameObject.Find("S").gameObject.transform.position);
		keyPos.Add (KeyCode.D, GameObject.Find("D").gameObject.transform.position);
		keyPos.Add (KeyCode.F, GameObject.Find("F").gameObject.transform.position);
		keyPos.Add (KeyCode.G, GameObject.Find("G").gameObject.transform.position);
		keyPos.Add (KeyCode.H, GameObject.Find("H").gameObject.transform.position);
		keyPos.Add (KeyCode.J, GameObject.Find("J").gameObject.transform.position);
		keyPos.Add (KeyCode.K, GameObject.Find("K").gameObject.transform.position);
		keyPos.Add (KeyCode.L, GameObject.Find("L").gameObject.transform.position);
		keyPos.Add (KeyCode.Z, GameObject.Find("Z").gameObject.transform.position);
		keyPos.Add (KeyCode.X, GameObject.Find("X").gameObject.transform.position);
		keyPos.Add (KeyCode.C, GameObject.Find("C").gameObject.transform.position);
		keyPos.Add (KeyCode.V, GameObject.Find("V").gameObject.transform.position);
		keyPos.Add (KeyCode.B, GameObject.Find("B").gameObject.transform.position);
		keyPos.Add (KeyCode.N, GameObject.Find("N").gameObject.transform.position);
		keyPos.Add (KeyCode.M, GameObject.Find("M").gameObject.transform.position);
	}
		
	void OnGUI ()
	{
		Event e = Event.current;
		if (e.isKey)
		{
			transform.position = keyPos [e.keyCode];
		}
	}
}
