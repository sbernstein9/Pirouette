using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour {

	public static SongManager instance;
	public AudioSource audioSource;

	public GameObject[] keyboard = new GameObject[26];
	public GameObject indicator;
	public Dictionary <GameObject, GameObject> indicatorParent = new Dictionary<GameObject,GameObject> ();

	public GameObject startButton;
	public GameObject canvas;
	public GameObject highScore;
	

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
	public Text activePrint;
	public bool startCountdown = false;

	public int score = 0;

	public float timeGenerated;

	SpriteRenderer spriteToFade;
	bool isFadingOut = false;
	bool isFadingIn = false;
	Color fadedColor = new Color(1,1,1,0);
	Color startColor = new Color(1,1,1,1);
	float fadeStartTime;

	public Color indicatorGold;

	bool gameStart = false;


	public float timeLastPressed;
	public float timeSincePressed = 0;
	public float activeCountdown = 5;

	// Use this for initialization
	void Start () {

		instance = this;

		audioSource = gameObject.GetComponent<AudioSource> ();
		//Sprite keyText = GameObject.Find ("KeyText").GetComponent<Spri;


		notes = new float[259];
		//First few beats get player used to tempo.

		//Part A1 Begins
		// 1 Note per Measure.
		notes [0] = 24f;
		notes [1] = 27f;
		notes [2] = 30f;
		notes [3] = 33f;
		notes [4] = 36f;
		notes [5] = 39f;
		notes [6] = 42f;
		notes [7] = 45f;
		notes [8] = 48f;
		notes [9] = 51f;
		notes[10] = 54f;
		notes[11] = 57f;
		notes[12] = 60f;
		notes[13] = 63f;
		notes[14] = 66f;
		notes[15] = 69f;
		notes[16] = 72f;
		notes[17] = 75f;
		notes[18] = 78f;
		notes[19] = 81f;
		notes[20] = 84f;
		notes[21] = 87f;
		notes[22] = 90f;
		notes[23] = 93f;
		notes[24] = 96f;
		notes[25] = 99f;
		notes[26] = 102f;
		notes[27] = 105f;
		notes[28] = 108f;
		notes[29] = 111f;
		notes[30] = 114f;
		notes[31] = 117f;

		// Part A2 Begins (First Chorus)'
		// 2 Notes Per Measure.
		notes[32] = 120f;
		notes[33] = 121f;
		notes[34] = 123f;
		notes[35] = 124f;
		notes[36] = 126f;
		notes[37] = 127f;
		notes[38] = 129f;
		notes[39] = 130f;
		notes[40] = 132f;
		notes[41] = 133f;
		notes[42] = 135f;
		notes[43] = 136f;
		notes[44] = 138f;
		notes[45] = 139f;
		notes[46] = 141f;
		notes[47] = 142f;
		notes[48] = 144f;
		notes[49] = 145f;
		notes[50] = 147f;
		notes[51] = 148f;
		notes[52] = 150f;
		notes[53] = 151f;
		notes[54] = 153f;
		notes[55] = 154f;
		notes[56] = 156f;
		notes[57] = 157f;
		notes[58] = 159f;
		notes[59] = 160f;
		notes[60] = 162f;
		notes[61] = 163f;
		notes[62] = 165f;
		notes[63] = 166f;
		notes[64] = 168f;
		notes[65] = 169f;
		notes[66] = 171f;
		notes[67] = 172f;
		notes[68] = 174f;
		notes[69] = 175f;
		notes[70] = 177f;
		notes[71] = 178f;
		notes[72] = 180f;
		notes[73] = 181f;
		notes[74] = 183f;
		notes[75] = 184f;
		notes[76] = 186f;
		notes[77] = 187f;
		notes[78] = 189f;
		notes[79] = 190f;
		notes[80] = 192f;
		notes[81] = 193f;
		notes[82] = 195f;
		notes[83] = 196f;
		notes[84] = 198f;
		notes[85] = 199f;
		notes[86] = 201f;
		notes[87] = 202f;
		notes[88] = 204f;
		notes[89] = 205f;
		notes[90] = 207f;
		notes[91] = 208f;
		notes[92] = 210f;
		notes[93] = 211f;
		notes[94] = 213f;
		notes[95] = 214f;

		// Part B1 Begins (Transition from Dance Studio to Stage Occurs)
		//Guides disappear for Keyboard. Reduce Notes so player can adjust.
		// 1 Note Per Measure.
		notes[96] = 216f;
		notes[97] = 219f;
		notes[98] = 222f;
		notes[99] = 225f;
		notes[100] = 228f;
		notes[101] = 231f;
		notes[102] = 234f;
		notes[103] = 237f;
		notes[104] = 240f;
		notes[105] = 243f;
		notes[106] = 246f;
		notes[107] = 249f;
		notes[108] = 252f;
		notes[109] = 255f;
		notes[110] = 258f;
		notes[111] = 261f;
		notes[112] = 264f;
		notes[113] = 267f;
		notes[114] = 270f;
		notes[115] = 275f;
		notes[116] = 278f;
		notes[117] = 291f;
		notes[118] = 294f;
		notes[119] = 297f;
		notes[120] = 300f;
		notes[121] = 303f;

		// Part B2 Begins
		// 2 Notes per Measure.
		notes[121] = 306f;
		notes[122] = 307f;
		notes[123] = 309f;
		notes[124] = 310f;
		notes[125] = 312f;
		notes[126] = 313f;
		notes[127] = 315f;
		notes[128] = 316f;
		notes[129] = 318f;
		notes[130] = 319f;
		notes[131] = 321f;
		notes[132] = 322f;
		notes[133] = 324f;
		notes[134] = 325f;
		notes[135] = 327f;
		notes[136] = 328f;
		notes[137] = 330f;
		notes[138] = 331f;
		notes[139] = 333f;
		notes[140] = 334f;
		notes[141] = 336f;
		notes[142] = 337f;
		notes[143] = 339f;
		notes[144] = 340f;
		notes[145] = 342f;
		notes[146] = 343f;
		notes[147] = 345f;
		notes[148] = 346f;
		notes[149] = 348f;
		notes[150] = 349f;
		notes[151] = 351f;
		notes[152] = 352f;
		notes[153] = 354f;
		notes[154] = 355f;
		notes[155] = 357f;
		notes[156] = 358f;
		notes[157] = 360f;
		notes[158] = 361f;
		notes[159] = 363f;
		notes[160] = 364f;
		notes[161] = 366f;
		notes[162] = 367f;
		notes[163] = 369f;
		notes[164] = 370f;
		notes[165] = 372f;
		notes[166] = 373f;
		notes[167] = 375f;
		notes[168] = 376f;

		//Part C1 Begins (Transition from Smaller Stage to Bigger Stage)
		// 2 Notes Per Measure.
		notes[169] = 378f;
		notes[170] = 379f;
		notes[171] = 381f;
		notes[172] = 382f;
		notes[173] = 384f;
		notes[174] = 385f;
		notes[175] = 387f;
		notes[176] = 388f;
		notes[177] = 390f;
		notes[178] = 391f;
		notes[179] = 393f;
		notes[180] = 394f;
		notes[181] = 396f;
		notes[182] = 397f;
		notes[182] = 399f;
		notes[183] = 400f;
		notes[184] = 402f;
		notes[185] = 403f;
		notes[186] = 405f;
		notes[187] = 406f;
		notes[188] = 408f;
		notes[189] = 409f;
		notes[190] = 411f;
		notes[191] = 412f;
		notes[192] = 414f;
		notes[193] = 415f;
		notes[194] = 417f;
		notes[195] = 418f;
		notes[196] = 420f;
		notes[197] = 421f;
		notes[198] = 423f;
		notes[199] = 424f;
		notes[200] = 426f;
		notes[201] = 427f;
		notes[202] = 429f;
		notes[203] = 430f;
		notes[204] = 432f;
		notes[205] = 433f;

		//Part C2 Begins
		// Finale
		// 3 Notes per Measure.
		notes[206] = 435f;
		notes[207] = 436f;
		notes[208] = 437f;
		notes[209] = 438f;
		notes[210] = 439f;
		notes[211] = 440f;
		notes[212] = 441f;
		notes[213] = 442f;
		notes[214] = 443f;
		notes[215] = 444f;
		notes[216] = 445f;
		notes[217] = 446f;
		notes[218] = 447f;
		notes[219] = 448f;
		notes[220] = 449f;
		notes[221] = 450f;
		notes[222] = 451f;
		notes[223] = 452f;
		notes[224] = 453f;
		notes[225] = 454f;
		notes[226] = 455f;
		notes[227] = 456f;
		notes[228] = 457f;
		notes[229] = 458f;
		notes[230] = 459f;
		notes[231] = 460f;
		notes[232] = 461f;
		notes[233] = 462f;
		notes[234] = 463f;
		notes[235] = 464f;
		notes[236] = 465f;
		notes[237] = 466f;
		notes[238] = 467f;
		notes[239] = 468f;
		notes[240] = 469f;
		notes[241] = 470f;
		notes[242] = 471f;
		notes[243] = 472f;
		notes[244] = 473f;
		notes[245] = 474f;
		notes[246] = 475f;
		notes[247] = 476f;
		notes[248] = 477f;
		notes[249] = 478f;
		notes[250] = 479f;
		notes[251] = 480f;
		notes[252] = 481f;
		notes[253] = 468f;
		notes[254] = 482f;
		notes[255] = 483f;
		notes[256] = 484f;
		notes[257] = 485f;
		notes[258] = 486f;
	

		

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
		//GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {


			
		//Debug.Log ("dspTime: " + AudioSettings.dspTime);
		//Debug.Log ("secPerBeat: " + secPerBeat);

		if (gameStart)
		{
			//calculate the position in seconds
			songPosition = (float)(AudioSettings.dspTime - dsptimesong);
			//Debug.Log ("songpos: " + songPosition);

			//calculate the position in beats
			songPosInBeats = songPosition / secPerBeat;
			//Debug.Log ("beats: " + songPosInBeats);
		}




		if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats + 2) //+beatsshowninadvance
		{
			
			CreateStep ();


			//initialize the fields of the music note

			nextIndex++;
		}
		if (songPosInBeats >= 16 && songPosInBeats <= 17)
		{
			scorePrint.enabled = true;
			activePrint.enabled = true;
		}
		if (songPosInBeats >= 22 && songPosInBeats <= 23)
		{
			//startCountdown = true;
		}
		if (songPosInBeats >= 80 && songPosInBeats <= 81)
		{
			
			FadeOut (GameObject.Find ("1Radio"));
		}
		else if (songPosInBeats >= 86 && songPosInBeats <= 87)
		{
			FadeOut (GameObject.Find ("1Bag"));
		}
		else if (songPosInBeats >= 93 && songPosInBeats <= 94)
		{
			FadeOut (GameObject.Find ("1Shoes"));
		}
		else if (songPosInBeats >= 100 && songPosInBeats <= 101)
		{
			FadeOut (GameObject.Find ("1Wall Bar"));
		}
		else if (songPosInBeats >= 107 && songPosInBeats <= 108)
		{
			FadeOut (GameObject.Find ("1Floor"));
		}
		else if (songPosInBeats >= 114 && songPosInBeats <= 115)
		{
			FadeOut (GameObject.Find ("KeyText"));
		}
		else if (songPosInBeats >= 121 && songPosInBeats <= 122)
		{
			FadeIn (GameObject.Find ("2LLight"));
		}
		else if (songPosInBeats >= 128 && songPosInBeats <= 129)
		{
			FadeIn (GameObject.Find ("2RLight"));
		}
		else if (songPosInBeats >= 135 && songPosInBeats <= 136)
		{
			FadeIn (GameObject.Find ("2Seats"));
		}
		else if (songPosInBeats >= 200 && songPosInBeats <= 201)
		{
			FadeOut (GameObject.Find ("2Seats"));
		}
		else if (songPosInBeats >= 207 && songPosInBeats <= 208)
		{
			FadeIn (GameObject.Find ("3Floor"));
		}
		else if (songPosInBeats >= 214 && songPosInBeats <= 215)
		{
			FadeIn (GameObject.Find ("3Seats"));
		}
		else if (songPosInBeats >= 221 && songPosInBeats <= 222)
		{
			FadeIn (GameObject.Find ("3Curtains"));
		}
		else if (songPosInBeats >= 500 && songPosInBeats <= 501)
		{
			audioSource.Stop ();
			if (gameStart)
			{
				FadeIn (GameObject.Find ("Title Screen"));
				highScore.GetComponent<Text> ().text = "High Score: " + score;
				scorePrint.enabled = false;
				startButton.SetActive (true);
				highScore.SetActive (true);
				songPosition = 0;
				foreach(KeyValuePair<GameObject,GameObject> indicatorP in indicatorParent)
				{
					Destroy (indicatorP.Value.gameObject);
					Destroy (indicatorP.Key.gameObject);

				}
				GameObject.Find ("1Radio").GetComponent<SpriteRenderer>().color = startColor;
				GameObject.Find ("1Bag").GetComponent<SpriteRenderer>().color = startColor;
				GameObject.Find ("1Shoes").GetComponent<SpriteRenderer>().color = startColor;
				GameObject.Find ("1Wall Bar").GetComponent<SpriteRenderer>().color = startColor;
				GameObject.Find ("1Floor").GetComponent<SpriteRenderer>().color = startColor;
				GameObject.Find ("KeyText").GetComponent<SpriteRenderer>().color = startColor;
				GameObject.Find ("2LLight").GetComponent<SpriteRenderer>().color = fadedColor;
				GameObject.Find ("2RLight").GetComponent<SpriteRenderer>().color = fadedColor;
				GameObject.Find ("2Seats").GetComponent<SpriteRenderer>().color = fadedColor;
				GameObject.Find ("2Seats").GetComponent<SpriteRenderer>().color = startColor;
				GameObject.Find ("3Floor").GetComponent<SpriteRenderer>().color = fadedColor;
				GameObject.Find ("3Seats").GetComponent<SpriteRenderer>().color = fadedColor;
				GameObject.Find ("3Curtains").GetComponent<SpriteRenderer>().color = fadedColor;
				gameStart = false;
			}
		}


		if (isFadingOut)
		{
			float distCovered = Time.time - fadeStartTime;
			float fracJourney = distCovered * 0.5f;
			spriteToFade.color = Color.Lerp (startColor, fadedColor, fracJourney);
			if (fracJourney > 1f)
			{
				isFadingOut = false;
			}
			//Debug.Log (fracJourney);
		}
		if (isFadingIn)
		{
			float distCovered = Time.time - fadeStartTime;
			float fracJourney = distCovered * 0.5f;
			spriteToFade.color = Color.Lerp (fadedColor, startColor, fracJourney);
			if (fracJourney > 1f)
			{
				isFadingIn = false;
			}
			//Debug.Log (fracJourney);
		}

		beatsPrint.text = songPosInBeats.ToString ();

		scorePrint.text = "Score: " + score;

		if (startCountdown)
		{
			timeSincePressed = Time.time - timeLastPressed;
			Debug.Log (timeSincePressed);
			activeCountdown = 5 - timeSincePressed;
			activePrint.text = "Don't Give Up! " + activeCountdown.ToString ("F2");
			if (activeCountdown < 0 && songPosInBeats > 30)
			{
				Scene scene = SceneManager.GetActiveScene(); 
				SceneManager.LoadScene(scene.name);
			}
		}

	}
		

	public void CreateStep()
	{
		Debug.Log ("CreateStep");
		int currentKey = Random.Range (0, 25);
		currentButton = keyboard [currentKey];
		if (!indicatorParent.ContainsKey(currentButton))
		{
			GameObject newIndicator = Instantiate (indicator,keyboard[currentKey].transform.position,Quaternion.identity, keyboard[currentKey].transform);
			indicatorParent.Add (currentButton.gameObject,newIndicator);
			StartCoroutine (FadeInTarget(newIndicator));
		}

	}

	IEnumerator FadeInTarget(GameObject targetObj)
	{
		float t = 0;
		float duration = secPerBeat * 1.8f;
		if (targetObj == null || targetObj.GetComponent<SpriteRenderer>() == null)
		{
			yield return null;
		}
		SpriteRenderer spR = targetObj.GetComponent<SpriteRenderer> ();
		while (t < duration && spR != null)
		{
			t += Time.deltaTime;
			float blend = Mathf.Clamp01(t / duration);
			spR.color = Color.Lerp(fadedColor, startColor, blend);
			//Debug.Log ("time = " + t);
			//Debug.Log ("Blend: " + blend + " spR: " + spR.color);
			yield return null;
		}
		spR.color = indicatorGold;
		yield return new WaitForSeconds (secPerBeat*2);
		StartCoroutine (FadeOutTarget (targetObj));
	}

	IEnumerator FadeOutTarget(GameObject targetObj)
	{
		
		float t = 0;
		float duration = secPerBeat * 8;
		if (targetObj == null || targetObj.GetComponent<SpriteRenderer>() == null)
		{
			yield return null;
		}
		SpriteRenderer spR = targetObj.GetComponent<SpriteRenderer> ();
		while (t < duration && targetObj != null)
		{
			t += Time.deltaTime;
			float blend = Mathf.Clamp01(t / duration);
			spR.color = Color.Lerp(startColor, fadedColor, blend);
			//Debug.Log ("time = " + t);
		//	Debug.Log ("Blend: " + blend + " spR: " + spR.color);
			yield return null;
		}
		yield return new WaitForSeconds (2);
		GameObject.Destroy (targetObj);
	}



	public void FadeOut (GameObject fadeObj)
	{
		
		spriteToFade = fadeObj.GetComponent<SpriteRenderer> ();
		fadeStartTime = Time.time;
		isFadingOut = true;

	}

	public void FadeIn (GameObject fadeObj)
	{
		spriteToFade = fadeObj.GetComponent<SpriteRenderer> ();
		fadeStartTime = Time.time;
		isFadingIn = true;
	}

	public void StartGame()
	{
		startButton.SetActive(false);
		highScore.SetActive(false);
		FadeOut (GameObject.Find ("Title Screen"));
		audioSource.Play();
		dsptimesong = (float) AudioSettings.dspTime;
		gameStart = true;
		if (score > 0)
		{
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);

		}
	}
}

public class Indicator{

	int key;
	GameObject pairedButton;
	float startNote;
	float endNote;


}