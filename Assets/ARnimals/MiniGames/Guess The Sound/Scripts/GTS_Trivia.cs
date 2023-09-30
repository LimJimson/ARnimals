using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GTS_Trivia : MonoBehaviour
{
    int randomNum;
    public TMP_Text triviaTxt;
    public GTS_GameManager GTS_GameManagerScript;
    string guideChosen;

    public GameObject boyFactGuide;
    public GameObject girlFactGuide;
    private void Start()
    {
        guideChosen = StateNameController.guide_chosen;
        guideGender();

    }

    void guideGender()
    {
        if (guideChosen == "boy_guide")
        {
            boyFactGuide.SetActive(true);
            girlFactGuide.SetActive(false);
        }
        else if (guideChosen == "girl_guide")
        {
            boyFactGuide.SetActive(false);
            girlFactGuide.SetActive(true);
        }
    }
    public void generateTrivia()
    {
        randomNum = (Random.Range(1, 3));
        int _animalIndexCorrect = GTS_GameManagerScript.animalIndex;

        switch (_animalIndexCorrect){
            case 0:
                if(randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Crocodiles</color> are excellent swimmers!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Crocodiles</color> have strong jaws!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Crocodiles</color> live near water!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Crocodiles</color> can grow very big!";
                }
                break;
            case 1:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Elephants</color> have big ears!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Elephants</color> use their trunks to eat!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Elephants</color> live in herds!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Elephants</color> are the largest land animals!";
                }
                break;
            case 2:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Tigers</color> have beautiful stripes!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Tigers</color> are great hunters!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Tigers</color> are strong and fast!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Tigers</color> like to swim!";
                }
                break;
            case 3:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Zebras</color>  have black stripes!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Zebras</color>  are typically found in Africa!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Zebras</color>  run very fast!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Zebras</color>  each have their own unique black stripes!";
                }
                break;
            case 4:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Horses</color>  can gallop fast!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Horses</color>  eat hay and grass!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Horses</color>  love to be brushed!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Horses</color>  can pull heavy carts!";
                }
                break;
            case 5:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Bats</color> can fly at night!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Bats</color> sleep upside down!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Bats</color> eat insects!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Bats</color> are not birds!";
                }
                break;
            case 6:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Bears</color> are big and furry!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Bears</color> love honey!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Bear</color> cubs stay with their mom!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Bears</color> hibernate in winter!";
                }
                break;
            case 7:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Camel</color> are typically found in deserts!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Camels</color> can store water in their humps!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Camels</color> can carry heavy loads!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Camels</color> are usually used for desert travel!";
                }
                break;
            case 8:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Ducks</color> love to swim!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Ducks</color> have webbed feet";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Ducks</color> can fly too!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Ducks</color> like ponds!";
                }
                break;
            case 9:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Leopards</color> have spots!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Leopards</color> are great climbers!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Leopards</color> are fast runners!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Leopards</color> hunt at night!";
                }
                break;
            case 10:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Owls</color> have big, round eyes!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Owls</color> can turn their heads!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Owls</color> are known to be wise and quiet!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Owls</color> are night birds!";
                }
                break;
            case 11:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Pigeons</color> are typically found in cities!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Pigeons</color> cood and flap their wings!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Pigeons</color> eat birdseed!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Pigeons</color> like to nest!";
                }
                break;
            case 12:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Rhinos</color> are big and strong!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Rhinos</color> hae tough skins!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Rhinos</color> have one or two horns!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Rhinos</color> eat grass and leaves!";
                }
                break;
            case 13:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Seaguuls</color> love the beach!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Seagulls</color> have white feathers!";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Seagulls</color> hunts for fish!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Seaguls</color> can fly high!";
                }
                break;
            case 14:
                if (randomNum == 0)
                {
                    triviaTxt.text = "<color=#FFFF00>Deers</color> are typically found in the woods!";
                }
                else if (randomNum == 1)
                {
                    triviaTxt.text = "<color=#FFFF00>Deers</color> may or may not have antlers";
                }
                else if (randomNum == 2)
                {
                    triviaTxt.text = "<color=#FFFF00>Deers</color> are fast runners!";
                }
                else if (randomNum == 3)
                {
                    triviaTxt.text = "<color=#FFFF00>Deers</color> are shy and gentle!";
                }
                break;

        }
    }
}
