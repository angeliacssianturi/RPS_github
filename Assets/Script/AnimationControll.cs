using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    [SerializeField]
    private Animator PlayerChoiceAnimation, ChoiceAnimation;

    public void ResetAnimation() { 
        PlayerChoiceAnimation.Play("ShowHandler");
        ChoiceAnimation.Play("RemoveChoice");
    }

    public void PlayerMadeChoice() { 
        PlayerChoiceAnimation.Play("Remv");
        ChoiceAnimation.Play("sh");

    }
}
