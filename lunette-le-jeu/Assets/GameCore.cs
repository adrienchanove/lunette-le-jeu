using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    // Nb objet trouvés
    public int objet = 0;
    // Nb objet total
    public int maxObjet = 3;
    [SerializeField]
    public GameObject gameOverMenu;
    [SerializeField]
    public GameObject winMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }


}
