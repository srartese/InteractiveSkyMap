using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public void FadeMe() {
		StartCoroutine (DoFade ());
	}
	

	IEnumerator DoFade () {
		CanvasGroup canvasGroup = GetComponents<CanvasGroup>()[0];
		
		while (canvasGroup.alpha<1){
			
			canvasGroup.alpha += Time.deltaTime / 2;
			yield return null;
		}
		
		canvasGroup.interactable = true;
		yield return null;
	}


}