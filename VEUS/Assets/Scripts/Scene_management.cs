using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_management : MonoBehaviour
{

    public Animator animator;

    public GameObject player;

    public GameObject Dialogue;

    static string sceneName = "";

    static int level;

    

    void Start()
    {
        DontDestroyOnLoad(Dialogue);
        DontDestroyOnLoad(player);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player")){

            animator.SetTrigger("loadScene");

            if (gameObject.name.Equals("exitTownHall"))
            {
                level = 1;
                sceneName = "townHall";
            }

            else if (gameObject.name.Equals("exitNewsroom")){
                level = 1;
                sceneName = "newsroom";
            }

            else if (gameObject.name.Equals("exitBarbershop"))
            {
                level = 1;
                sceneName = "barbershop";
            }

            else if (gameObject.name.Equals("enterTownHall"))
            {
                level = 2;

            }
            else if (gameObject.name.Equals("enterBarberShop"))
            {
                level = 3;
            }
            else if (gameObject.name.Equals("enterNewsroom"))
            {
                level = 4;
            }

            Debug.Log("Collider: " + gameObject.name + " " + level);
        }
    }


    public void exitScene()
    {
        Debug.Log("loading level " + level + " " + sceneName);
        SceneManager.LoadScene(level);
    }

    public void playerPosition()
    {
        if (sceneName.Equals("townHall")){
            player.transform.position = new Vector3(-11f, 0f, 0f);
            sceneName = "";
        }
        else if (sceneName.Equals("newsroom"))
        {
            player.transform.position = new Vector3(42f, 2.7f, 0f);
            sceneName = "";
        }
        else if (sceneName.Equals("barbershop"))
        {
            player.transform.position = new Vector3(32f, 20f, 0f);
            sceneName = "";
        }
    }
} 
