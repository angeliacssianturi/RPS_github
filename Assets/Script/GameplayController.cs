using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameChoices {
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite;

    [SerializeField]
    private Image playerChoice_Img, opponentChoice_Img;

    [SerializeField]
    private Text infoText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationControll animationControll;


    void Awake() {
        animationControll = GetComponent<AnimationControll>();

    }

    public void SetChoices(GameChoices gameChoices) {

        switch(gameChoices) {
            case GameChoices.ROCK:
                player_Choice = GameChoices.ROCK;

                playerChoice_Img.sprite = rock_Sprite;
                break;

            case GameChoices.PAPER:
                player_Choice = GameChoices.PAPER;
                
                playerChoice_Img.sprite = paper_Sprite;
               
                break;

            case GameChoices.SCISSORS:
                player_Choice = GameChoices.SCISSORS;
                
                playerChoice_Img.sprite = scissors_Sprite;
                
                break;
        }
        SetOppenentChoice();
        DetermineWinner();
    }
    void SetOppenentChoice() {
        int rnd = Random.Range(0,3);
        switch(rnd) {
            case 0:
                opponent_Choice = GameChoices.ROCK;

                opponentChoice_Img.sprite = rock_Sprite;
                break;
            case 1:
                opponent_Choice = GameChoices.PAPER;

                opponentChoice_Img.sprite = paper_Sprite;
                break;
            case 2:
                opponent_Choice = GameChoices.SCISSORS;

                opponentChoice_Img.sprite = scissors_Sprite;
                break;
        }
    }

    void DetermineWinner() {
        if(player_Choice == opponent_Choice){
            infoText.text = "It's a Draw!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK){
            //Player Won
            infoText.text = "You Win!!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK){
            //Oppenent Won
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS){
            //Player Won
            infoText.text = "You Win!!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS){
            //Oppenent Won
            infoText.text = "You Lose!";

            
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER){
            //Player Won
            infoText.text = "You Win!!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER){
            //Oppenent Won
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

    }
    IEnumerator DisplayWinnerAndRestart() {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        animationControll.ResetAnimation();

    }

}
