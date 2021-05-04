using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static bool gameover = false;
    public Button overBtn;

    // Start is called before the first frame update
    void Start()
    {
        overBtn = GetComponent<Button>();
        overBtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(EndGame.gameover) {
            print("game over..");
            overBtn.gameObject.SetActive(true);
        }
    }
}
