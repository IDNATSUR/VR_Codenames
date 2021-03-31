using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameNetwork : MonoBehaviour
{
    public static PlayerGameNetwork Instance;
    public string Name { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);

        Instance = this;

        Name = "Player #" + Random.Range(0, 9999);
    }
}
