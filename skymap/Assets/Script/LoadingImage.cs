using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingImage : MonoBehaviour {

    public Image loadingImage;            //Drag the circular image i.e Slider in our case
    public float time;                      //In how much time the progress bar will fill/empty
    void Start()
    {
        loadingImage.fillAmount = 0f;      // Initally progress bar is empty
    }
    void Update()
    {
       loadingImage.fillAmount += Time.deltaTime / time;
    }
}