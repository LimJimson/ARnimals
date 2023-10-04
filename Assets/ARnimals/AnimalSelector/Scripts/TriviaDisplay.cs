using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TriviaDisplay : MonoBehaviour
{
    
    int randNum;
    int chosenIndex;
    public TMP_Text triviaDisp;
    void Start()
    {
        randNum = UnityEngine.Random.Range(1, 5);
    }
    private void Update()
    {
        chosenIndex = StateNameController.animalIndexChosen;
    }

    public void Trivia(){

        
        switch (chosenIndex)
        {
            case 0: // bat
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Bats</color> can see in the dark!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Bats</color> eat insects at night!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Bats</color> use echolocation to navigate and hunt for food!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Bats</color> are shy and gentle creatures!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Bats</color> sleep while hanging upside down!";
                }
                break;

            case 1: // bear
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Bears</color> are big and furry!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Bears</color> live in forests and caves!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Bears</color> like to eat fish and honey!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Bears</color> can stand on their hind legs!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Bears</color> are excellent swimmers!";
                }
                break;

            case 2: // camel
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> can go without water for days!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> humps store fat, not water!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> have long eyelashes to protect their eyes!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> can store water!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> have long necks and legs!";
                }
                break;

            case 3: // crab
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Crabs</color> live on the beach!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Crabs</color> can pinch if scared!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Crabs</color> like to eat small things!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Crabs</color> walk sideways!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Crabs</color> have hard shells!";
                }
                break;

            case 4: // crocodile
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Crocodiles</color> can swim very fast!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Crocodiles</color> have powerful jaws!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Crocodiles</color> live in water and on land!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Female crocodiles</color> have tough and scaly skin!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Crocodiles</color> use their tails for swimming!";
                }
                break;

            case 5: // deer
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Deers</color> have a keen sense of smell and hearing!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Deers</color> are graceful and shy!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Deers</color> can run very fast!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Deers</color> eat leaves and grass!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Deers</color> play an important role in ecosystems!";
                }
                break;

            case 6: // duck
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducks</color> swim in ponds and lakes!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducks</color> quack and waddle!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducks</color> like to eat bread crumbs!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducklings</color> are excellent swimmers from a young age!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducks</color> can fly, swim, and walk!";
                }
                break;

            case 7: // elephant
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> are herbivores, meaning they eat plants!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> have a great memory!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> can communicate with low rumbles";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> live in groups called herds!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> use their ears to cool off!";
                }
                break;

            case 8: // horse
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Horses</color> are friendly and rideable!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Horses</color> come in many coat colors!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Horses</color> can gallop very quickly!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Horses</color> are known for their keen sense of hearing.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Horse</color> are used in sports like racing and riding!";
                }
                break;

            case 9: // koi
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi's</color> are colorful fish!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi's</color> swim in ponds!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi's</color> can live a long time!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi's</color> can grow quite large!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi's</color> are known for their graceful swimming!";
                }
                break;

            case 10: // leopard
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> have sharp claws for hunting!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> can leap long distances!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> spots help them hide in the grass!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> are fast runners and climbers!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> like to hunt at night!";
                }
                break;

            case 11: // octopus
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> are highly intelligent marine animals!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> have three hearts!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> are masters of camouflage!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> have eight long arms!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> live in the sea!";
                }
                break;

            case 12: // pigeon
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> are known as city birds!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> have soft, cooing voices!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> can fly very high!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> are found all over the world!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> are gentle and friendly birds!";
                }
                break;

            case 13: // piranha
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Piranhas</color> are commonly found in the river!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Piranhas</color> have sharp teeth!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Piranhas</color> hunt in a group!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>piranhas</color> eat meat quickly!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Piranhas</color> have excellent vision!";
                }
                break;

            case 14: // rhinoceros
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Rhinoceroses</color> have thick skin to protect them!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>rhinoceros</color> can charge at a fast speed if threatened!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Rhinoceroses</color> are endangered due to poaching!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>rhinoceroses</color> like to roll in mud!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Rhinoceros</color> have one or two horns!";
                }
                break;

            case 15: // seagull
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> love the ocean!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> have white feathers!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> can fly for a long time!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> have sharp beaks for catching fish!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> are social birds and often gather in flocks!";
                }
                break;

            case 16: // shark
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> lives in the ocean!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> have very sharp teeth!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> can swim very fast!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> can detect prey from far away using their senses!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> can be really big";
                }
                break;

            case 17: // owl
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> can swivel their heads almost all the way around!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> are symbols of wisdom in some cultures!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> make a hooting sound!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> hunt for mice and insects!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> are birds of the night";
                }
                break;

            case 18: // tiger
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> have orange fur with stripes!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> are big and strong predators!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> can climb and swim well";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> are endangered animals and need protection!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> have excellent night vision!";
                }
                break;

            case 19: // zebra
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> use their stripes to confuse predators!";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> have black and white stripes!";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> groom each other to bond!";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> run very fast to escape danger!";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> are herbivores and eat grass";
                }
                break;

        }
    }
}
