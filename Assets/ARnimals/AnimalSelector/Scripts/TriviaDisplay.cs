using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriviaDisplay : MonoBehaviour
{
    
    public int randNum;
    public TMP_Text triviaDisp;
    void Start()
    {
        genTrivia();
    }

    void genTrivia(){
        randNum = Random.Range(1,10);
        if (randNum == 1){
            triviaDisp.text = "<color=yellow>ELEPHANTS</color> can't <color=green>JUMP</color>!";
        }
        if (randNum == 2){
            triviaDisp.text = "<color=yellow>OWLS</color> can turn their <color=#80FFFF>HEADS</color> almost <color=green>ALL THE WAY AROUND</color>!";
        }
        if (randNum == 3){
            triviaDisp.text = "<color=yellow>BABY DOGS</color> are called <color=green>PUPPIES</color>!";
        }
        if (randNum == 4){
            triviaDisp.text = "<color=yellow>GIRAFFES</color> are the <color=#80FFFF>TALLEST ANIMAL</color> on <color=green>LAND</color>!";
        }
        if (randNum == 5){
            triviaDisp.text = "<color=yellow>SNAILS</color> carry their <color=#80FFFF>HOUSES</color> on their <color=green>BACK</color>!";
        }

        if (randNum == 6){
            triviaDisp.text = "<color=yellow>LIONS</color> are known as the <color=green>KING OF THE JUNGLE</color>!";
        }
        if (randNum == 7){
            triviaDisp.text = "<color=yellow>LADYBUGS</color> are usually <color=green>RED WITH BLACK SPOTS</color>!";
        }
        if (randNum == 8){
            triviaDisp.text = "<color=yellow>TURTLES</color> can hide <color=green>INSIDE THEIR SHELLS</color>!";
        }
        if (randNum == 9){
            triviaDisp.text = "<color=yellow>PARROTS</color> can imitate <color=green>SOME SOUNDS</color>!";
        }
        if (randNum == 10){
            triviaDisp.text = "<color=yellow>SNAKES</color> don't have <color=green>EYELIDS</color>!";
        }
    }
}
