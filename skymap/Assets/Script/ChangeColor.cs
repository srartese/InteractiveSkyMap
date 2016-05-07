using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

    public Color colorStart = Color.white;
    public Color colorEnd = new Color(1F, 0.8F, 0.5F);
    public float duration = 3.2F;
    public Renderer rend;
    public TestCol colid;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        colid = gameObject.GetComponentInChildren<TestCol>();
    }
    void Update()
    {
      
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        
        
    }
}
