using UnityEngine;
using System.Collections;

public class piano : MonoBehaviour {

	public int position = 0;
	public int samplerate = 44100;
	public float frequency = 440;
	private AudioClip simple;
	private AudioSource fuente;
	private GameObject cubo;
    private int[] notes = new int[] {294, 330, 349, 392, 415, 440, 494};  // SI bajo 262?
	
	// Use this for initialization
	void Start () {		
		//Localizacion del objeto ya creado con nombre "Cube" a la variable cubo
		cubo = GameObject.Find ("Cube");
		//Translacion del objeto a la posicion 0, 0, -5
		cubo.GetComponent<Transform> ().Translate (0f, 0f, -5f);

		//Inicializacion del clip
		// public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, 
        //                                bool stream, AudioClip.PCMReaderCallback pcmreadercallback,
        //                                AudioClip.PCMSetPositionCallback pcmsetpositioncallback); 
		//simple = AudioClip.Create ("Simple", samplerate * 2, 1, samplerate, true, OnAudioRead);
		simple = AudioClip.Create ("Simple", samplerate/2, 1, samplerate, true, OnAudioRead);

		//Inserccion de una fuente de audio al objeto cubo
		//Puntero a la fuente de audio de cubo
		fuente = cubo.AddComponent<AudioSource> ();

		fuente.clip = simple;
	} // Fi de Start

	void OnAudioRead(float[] data)
	{
		int count = 0;
		while (count < data.Length) 
		{
			//data[count] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate));
			data[count] = Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate);
			position++;
			count++;
		}
	} // Fi de OnAudioRead

		// Update is called once per frame
	void Update () {
	 GameObject unaTecla;
	 /*
	     if (Input.anyKey ) {
	       Debug.Log( KeyCode.Alpha1 );
	       //No put traure la tecla?
	       // https://docs.unity3d.com/ScriptReference/Input-inputString.html
           //  foreach (char c in Input.inputString)
	     }
	*/
/*
		if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{		
			frequency = 262;
			fuente.Play();
		}
*/
        //Deteccion de si es pulsada una tecla
		if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{
		
			frequency = notes[0];
			fuente.Play();
	        unaTecla = GameObject.Find ("DO"); 		
	        unaTecla.transform.Rotate(new Vector3(-10, 0, 0));
		}
		
		if(Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{
		    unaTecla = GameObject.Find ("DO"); 		
	        unaTecla.transform.Rotate(new Vector3(10, 0, 0));
		}
		
		
		if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
		{
			frequency = notes[1]; //294;
			fuente.Play();
	        unaTecla = GameObject.Find ("RE"); 		
	        unaTecla.transform.Rotate(new Vector3(-10, 0, 0));
		}
		if(Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
		{
		    unaTecla = GameObject.Find ("RE"); 		
	        unaTecla.transform.Rotate(new Vector3(10, 0, 0));
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
		{
			frequency = notes[2]; //330;
			fuente.Play();
	        unaTecla = GameObject.Find ("MI"); 		
	        unaTecla.transform.Rotate(new Vector3(-10, 0, 0));

		}
        if(Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
		{
		    unaTecla = GameObject.Find ("MI"); 		
	        unaTecla.transform.Rotate(new Vector3(10, 0, 0));
		}

		
		if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
		{
			frequency = notes[3]; // 349;
			fuente.Play();
			unaTecla = GameObject.Find ("FA"); 		
	        unaTecla.transform.Rotate(new Vector3(-10, 0, 0));

		}
		if(Input.GetKeyUp(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
		{
		    unaTecla = GameObject.Find ("FA"); 		
	        unaTecla.transform.Rotate(new Vector3(10, 0, 0));
		}

		
		if(Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
		{
			frequency = notes[4]; // 392;
			fuente.Play();
	        unaTecla = GameObject.Find ("SOL"); 		
	        unaTecla.transform.Rotate(new Vector3(-10, 0, 0));			
		}
		if(Input.GetKeyUp(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
		{
		    unaTecla = GameObject.Find ("SOL"); 		
	        unaTecla.transform.Rotate(new Vector3(10, 0, 0));
		}
		
		
		if(Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
		{
			frequency = notes[5]; // 415;
			fuente.Play();
	        unaTecla = GameObject.Find ("LA"); 		
	        unaTecla.transform.Rotate(new Vector3(-10, 0, 0));			
		}
		if(Input.GetKeyUp(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
		{
		    unaTecla = GameObject.Find ("LA"); 		
	        unaTecla.transform.Rotate(new Vector3(10, 0, 0));
		}
		

		if(Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
		{
			frequency = notes[6]; // 494;
			fuente.Play();
	        unaTecla = GameObject.Find ("SI"); 		
	        unaTecla.transform.Rotate(new Vector3(-10, 0, 0));			
		}
		if(Input.GetKeyUp(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
		{
		    unaTecla = GameObject.Find ("SI"); 		
	        unaTecla.transform.Rotate(new Vector3(10, 0, 0));
		}


	} // Fi de Update
} //  Fi de piano
