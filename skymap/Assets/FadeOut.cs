using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	public void FadeMe() {
		StartCoroutine (DoFade ());
	}

		IEnumerator DoFade () {
			CanvasGroup canvasGroup = GetComponents<CanvasGroup>();

			while (canvasGroup.alpha>0){

				canvasGroup.alpha -= Time.deltaTime / 2;
				yield return null;
		}

			canvasGroup.interactable = false;
			yield return null;
	}
}
