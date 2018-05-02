using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;

public class SongManager : MonoBehaviour {

	public static SongManager instance;

	public GameObject[] keyboard = new GameObject[26];
	public GameObject indicator;
	public Dictionary <GameObject, GameObject> indicatorParent = new Dictionary<GameObject,GameObject> ();


	//the current position of the song (in seconds)
	float songPosition;

	//the current position of the song (in beats)
	public float songPosInBeats;

	//the duration of a beat
	//float secPerBeat = 0.384615f;
	float secPerBeat;

	//how much time (in seconds) has passed since the song started
	float dsptimesong;

	public float bpm;

	//keep all the position-in-beats of notes in the song
	public float[] notes;

	//the index of the next note to be spawned
	int nextIndex = 0;

	//the button that needs to be pressed
	public GameObject currentButton;

	public int beatsShownInAdvance = 2;

	public Text beatsPrint;
	public Text scorePrint;

	public int score = 0;

	public float timeGenerated;

	// Use this for initialization
	void Start () {

		instance = this;

		notes = new float[50];
		notes [0] = 1f;
		notes [1] = 4f;
		notes [2] = 8f;
		notes [3] = 16f;
		notes [4] = 17f;
		notes [5] = 18f;
		notes [6] = 20f;
		notes [7] = 22f;
		notes [8] = 25f;
		notes [9] = 27f;
		notes [10] = 28f;
		for (int i = 10; i < notes.Length; i++)
		{
			notes [i] = 28 + i + 7;
		}
	

		

		keyboard[0] = GameObject.Find("Q");
		keyboard[1] = GameObject.Find("W");
		keyboard[2] = GameObject.Find("E");
		keyboard[3] = GameObject.Find("R");
		keyboard[4] = GameObject.Find("T");
		keyboard[5] = GameObject.Find("Y");
		keyboard[6] = GameObject.Find("U");
		keyboard[7] = GameObject.Find("I");
		keyboard[8] = GameObject.Find("O");
		keyboard[9] = GameObject.Find("P");
		keyboard[10] = GameObject.Find("A");
		keyboard[11] = GameObject.Find("S");
		keyboard[12] = GameObject.Find("D");
		keyboard[13] = GameObject.Find("F");
		keyboard[14] = GameObject.Find("G");
		keyboard[15] = GameObject.Find("H");
		keyboard[16] = GameObject.Find("J");
		keyboard[17] = GameObject.Find("K");
		keyboard[18] = GameObject.Find("L");
		keyboard[19] = GameObject.Find("Z");
		keyboard[20] = GameObject.Find("X");
		keyboard[21] = GameObject.Find("C");
		keyboard[22] = GameObject.Find("V");
		keyboard[23] = GameObject.Find("B");
		keyboard[24] = GameObject.Find("N");
		keyboard[25] = GameObject.Find("M");

		//calculate how many seconds is one beat
		secPerBeat = 60f / bpm;


		//record the time when the song starts
		dsptimesong = (float) AudioSettings.dspTime;

		//start the song
		GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("dspTime: " + AudioSettings.dspTime);
		Debug.Log ("secPerBeat: " + secPerBeat);

		//calculate the position in seconds
		songPosition = (float)(AudioSettings.dspTime - dsptimesong);
		Debug.Log ("songpos: " + songPosition);

		//calculate the position in beats
		songPosInBeats = songPosition / secPerBeat;
		Debug.Log ("beats: " + songPosInBeats);



		if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats) //+beatsshowninadvance
		{
			
			CreateStep ();

			//initialize the fields of the music note

			nextIndex++;
		}


		beatsPrint.text = songPosInBeats.ToString ();

		scorePrint.text = "Score: " + score;

	}
		

	public void CreateStep()
	{
		int currentKey = Random.Range (0, 25);
		currentButton = keyboard [currentKey];
		if (!indicatorParent.ContainsKey(currentButton))
		{
			GameObject newIndicator = Instantiate (indicator,keyboard[currentKey].transform.position,Quaternion.identity, keyboard[currentKey].transform);
			indicatorParent.Add (currentButton.gameObject,newIndicator);
		}

	}
}
