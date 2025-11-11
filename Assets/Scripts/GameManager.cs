using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    //change gameobject to name of script on ghosts and pacman when created!
    public Ghost[] ghosts;

    public GameObject pacman;

    public Transform pellets;

    public int score {  get; private set; }

    public int lives { get; private set; }


    //first thing game does when started
    private void Start()
    {
        NewGame();
    }

    //if you die and click delete the game will restart
    private void Update()
    {
        if (this.lives <= 0 && Input.GetKeyDown(KeyCode.Delete))
        {
            NewGame();
        }
    }

    //when a new game starts lives are set to 3 and score is set to 0
    private void NewGame() 
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    //this resets all ghosts, pacman and pellets to be visible at the start of the game
    private void NewRound() 
    {
        foreach (Transform pellet in this.pellets) 
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    //if lives remain ghosts and pacman will become visible but pellets will not respawn
    private void ResetState() 
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }


    //if lives reach 0 gameover gets called
    private void GameOver() 
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score) 
    {
        this.score = score;
    }

    private void SetLives(int lives) 
    {
        this.lives = lives;
    }

    //if pacman is eaten by a ghost this will be called
    public void PacmanEaten() 
    {
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        //this gives a 3 second pause after dying before you respawn
        if (this.lives > 0) 
        {
            Invoke(nameof(ResetState), 3.0f);
        }
       
        //if lives are 0 then game ends
        else
        {
            GameOver();
        }
    }
}
