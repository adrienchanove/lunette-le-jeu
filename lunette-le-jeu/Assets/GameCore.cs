using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    // Nb objet trouvés
    public int objet = 0;
    // Nb objet total
    public int maxObjet = 3;
    // Konami code
    private bool konami = false;
    private KeyCode[] konamiCode = { 
        KeyCode.UpArrow,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.B,
        KeyCode.A 
    };


    [SerializeField]
    public GameObject gameOverMenu;
    [SerializeField]
    public GameObject winMenu;


    // Start is called before the first frame update
    IEnumerator Start ()
    {
        int konamiCodeIndex = 0;

        while (true)
        {
            if (Input.GetKeyDown(konamiCode[konamiCodeIndex]))
            {
                Debug.Log("Konami code: " + konamiCode[konamiCodeIndex]);
                konamiCodeIndex++;

                if (konamiCodeIndex == konamiCode.Length)
                {
                    konami = true;
                    konamiCodeIndex = 0;
                }
                
            }
            else if (Input.anyKeyDown)
            {
                konamiCodeIndex = 0;
            }
            
            yield return null;
        }
	}
    

    // Update is called once per frame
    void Update()
    {
        /*/ Konami code
        //Debug.Log(Input.);
         Event e = Event.current;
        if (e.isKey){
            Debug.Log("Detected key code: " + e.keyCode);
            if (Input.GetKeyDown(konamiCode[konamiCodeIndex]))
            {
                //Debug.Log("Konami code: " + konamiCode[konamiCodeIndex]);
                konamiCodeIndex++;
            }
            else
            {
                konamiCodeIndex = 0;
            }
            if (konamiCodeIndex == konamiCode.Length)
            {
                konami = true;
                konamiCodeIndex = 0;
            }
        }*/
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            // PERDUE
            Debug.Log("Player touched Monster");
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }

        // Collision avec l'objet
        if (collision.gameObject.tag == "Collectible")
        {
            // OBJET TROUVE
            Debug.Log("Player touched Collectible");
            objet++;
            Destroy(collision.gameObject);
            if (objet == maxObjet)
            {
                winMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }

        // Collision avec les murs
        if (collision.gameObject.tag == "KONAMI" && konami)
        {
            // Super KONAMI
            Debug.Log("Mur detruit");
            Destroy(collision.gameObject);
           
        }
    }


}
