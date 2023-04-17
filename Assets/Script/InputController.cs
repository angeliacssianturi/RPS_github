using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private AnimationControll animationControll;
    private GameplayController gameplayController;

    private string playersChoice;

    void Awake(){
        animationControll = GetComponent<AnimationControll>();
        gameplayController = GetComponent<GameplayController>();
    }

    public void GetChoice() {

        string choiceName = UnityEngine.EventSystems.
            EventSystem.current.currentSelectedGameObject.name;

        GameChoices selectedChoice = GameChoices.NONE;

        switch(choiceName) {
            case "Rock":
                selectedChoice = GameChoices.ROCK;
                break;
            case "Paper":
                selectedChoice = GameChoices.PAPER;
                break;
            case "Scissors":
                selectedChoice = GameChoices.SCISSORS;
                break;
        }

        gameplayController.SetChoices(selectedChoice);
        animationControll.PlayerMadeChoice();
    }
}
