using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dvd : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
        var outline = gameObject.AddComponent<Outline>();
	    outline.OutlineMode = Outline.Mode.OutlineAll;
	    outline.OutlineColor = Color.white;
	    outline.OutlineWidth = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
