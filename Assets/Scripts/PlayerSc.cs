using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSc : MonoBehaviour {

	public static PlayerSc instance;

	public Dictionary<KeyCode, GameObject> keyPos =  new Dictionary<KeyCode, GameObject>();
	public KeyCode playerInput;
	public Sprite[] poses = new Sprite[5];
	public SpriteRenderer playerSprite;
	KeyCode lastKey;

	// Use this for initialization
	void Start () {

		instance = this;
	


		keyPos.Add (KeyCode.Q, GameObject.Find("Q"));
		keyPos.Add (KeyCode.W, GameObject.Find("W"));
		keyPos.Add (KeyCode.E, GameObject.Find("E"));
		keyPos.Add (KeyCode.R, GameObject.Find("R"));
		keyPos.Add (KeyCode.T, GameObject.Find("T"));
		keyPos.Add (KeyCode.Y, GameObject.Find("Y"));
		keyPos.Add (KeyCode.U, GameObject.Find("U"));
		keyPos.Add (KeyCode.I, GameObject.Find("I"));
		keyPos.Add (KeyCode.O, GameObject.Find("O"));
		keyPos.Add (KeyCode.P, GameObject.Find("P"));
		keyPos.Add (KeyCode.A, GameObject.Find("A"));
		keyPos.Add (KeyCode.S, GameObject.Find("S"));
		keyPos.Add (KeyCode.D, GameObject.Find("D"));
		keyPos.Add (KeyCode.F, GameObject.Find("F"));
		keyPos.Add (KeyCode.G, GameObject.Find("G"));
		keyPos.Add (KeyCode.H, GameObject.Find("H"));
		keyPos.Add (KeyCode.J, GameObject.Find("J"));
		keyPos.Add (KeyCode.K, GameObject.Find("K"));
		keyPos.Add (KeyCode.L, GameObject.Find("L"));
		keyPos.Add (KeyCode.Z, GameObject.Find("Z"));
		keyPos.Add (KeyCode.X, GameObject.Find("X"));
		keyPos.Add (KeyCode.C, GameObject.Find("C"));
		keyPos.Add (KeyCode.V, GameObject.Find("V"));
		keyPos.Add (KeyCode.B, GameObject.Find("B"));
		keyPos.Add (KeyCode.N, GameObject.Find("N"));
		keyPos.Add (KeyCode.M, GameObject.Find("M"));
	}
		

	void Update()
	{
		
	}

	public void OnGUI ()
	{
		Event e = Event.current;
		if (e.isKey && keyPos.ContainsKey(e.keyCode))
		{
			transform.position = keyPos [e.keyCode].transform.position;
			SongManager.instance.timeLastPressed = Time.time;
			if (SongManager.instance.songPosInBeats >= 24)
			{
				SongManager.instance.startCountdown = true;

			}

			if (e.keyCode != lastKey)
			{
				playerSprite.sprite = poses [Random.Range (0, 4)];
			}

			lastKey = e.keyCode;

			if (SongManager.instance.indicatorParent.ContainsKey(keyPos[e.keyCode])) // keyPos [e.keyCode] = SongManager.instance.currentButton && keyPos [e.keyCode].GetComponentsInChildren<Transform>() != null
			{
				GameObject key = keyPos [e.keyCode];
				if (SongManager.instance.indicatorParent [key].gameObject.GetComponent<SpriteRenderer>().color == SongManager.instance.indicatorGold)
				{
					SongManager.instance.score += 10;
				}
				Destroy (SongManager.instance.indicatorParent [key].gameObject);
				SongManager.instance.indicatorParent.Remove(key);
				float timeHit = (float) AudioSettings.dspTime;
				SongManager.instance.score += 10;


			}
		}
	}


}
