using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeGraphics : MonoBehaviour {
	public float FadeSpeed = 0.9f;
	public GameObject FadeObject = null;

	public bool LetStart = false;

	private Image FadeImage = null;
	private bool ReachClear = false;

	void Start () {
		FadeImage = FadeObject.transform.GetChild (0).transform.GetComponent<Image>();
	}

	void Update(){
		if (LetStart == true)
			StartFade ();
	}

	void FadeToClear(){
		FadeImage.color = Color.Lerp(FadeImage.color, Color.clear, FadeSpeed * Time.deltaTime);
	}
	
	void FadeToBlack(){
		FadeImage.color = Color.Lerp(FadeImage.color, Color.black, FadeSpeed * Time.deltaTime);
	}

	void StartFade(){
		if (ReachClear == false)
			FadeToClear ();
		else
			FadeToBlack ();

		if (FadeImage.color.a <= 0.05f) {
			ReachClear = true;
		} else if(FadeImage.color.a >= 0.95f && ReachClear == true){
			LetStart = false;
		}
	}
}
