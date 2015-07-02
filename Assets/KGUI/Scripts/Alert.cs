using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class Alert : MonoBehaviour {
	public string AlertTitle = "타이틀 예제";

	[TextArea(3,10)]
	public string AlertContent = "타오르고 힘차게 우리의 위하여, 뛰노는 실현에 위하여 열락의\n힘있다. 붙잡아 과실이 찾아 찾아다녀도, 투명하되 놀이 구하지\n안고, 있다. 용기가 관현악이며, 얼음이 있다. 영락과 피가 작고\n불러 청춘에서만 있다.";

	public float AlertOut = 5.0f;
	private float TopSize = 0;
	private int moved = 0;

	void Start () {
		Text Title = gameObject.transform.GetChild (0).transform.FindChild ("TextObject").transform.FindChild ("Title").GetComponent<Text> ();
		Text Content = gameObject.transform.GetChild(0).transform.FindChild("TextObject").transform.FindChild("Content").GetComponent<Text> ();

		if(TopSize == 0)
			TopSize = gameObject.transform.GetChild (0).transform.FindChild ("Top Panel").transform.localScale.x / AlertOut / 100;

		Title.text = AlertTitle;
		Content.text = AlertContent;

		StartCoroutine(Dest());
	}

	void Update () {
		Start ();
	}

	IEnumerator Dest() {
		yield return new WaitForSeconds(0.01f);
		AlertOut -= 0.01f;

		gameObject.transform.GetChild (0).transform.FindChild ("Top Panel").transform.localScale -= new Vector3(TopSize, 0, 0);

		if(AlertOut <= 0)
			StartCoroutine(Fade());
	}

	IEnumerator Fade() {
		yield return new WaitForSeconds(0.00001f);
		moved++;
		gameObject.transform.Translate (new Vector3 (0, 0.3f));
		gameObject.transform.GetChild (0).GetComponent<CanvasGroup> ().alpha -= 0.10f;

		if(moved > 10)
			Destroy(gameObject);
	}
}
