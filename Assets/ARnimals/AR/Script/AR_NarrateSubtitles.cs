using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AR_NarrateSubtitles : MonoBehaviour
{
    public ARPlacement ARPlacementScript;
    public AR_Narration arNarrationScript;
    public TMP_Text subtitleTxt;

    int animalIndex;
    string guideChosen = "boy_guide";

    bool isAudioPaused;
    private void Start()
    {
        
        //if(StateNameController.guide_chosen == null)
        //{
        //    guideChosen = "boy_guide";
        //}
        //else
        //{
        //    guideChosen = StateNameController.guide_chosen;
        //}
    }
    
    private void Update()
    {
    }

    public void animalSub()
    {
        animalIndex = ARPlacementScript.getAnimalIndex();
        StopAllCoroutines();
        switch (animalIndex)
        {
            case 0: //bat
                if(guideChosen == "boy_guide")
                {
                    StartCoroutine(batSubPatrick());
                }
                else if(guideChosen == "girl_guide")
                {
                    StartCoroutine(batSubSandy());
                }
                break;

            case 1://bear
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(bearSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(bearSubSandy());
                }
                break;

            case 2://camel
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(camelSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(camelSubSandy());
                }
                break;

            case 3: //crab
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(crabSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(crabSubSandy());
                }
                break;

            case 4://crocodile
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(crocodileSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(crocodileSubSandy());
                }
                break;

            case 5://deer
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(deerSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(deerSubSandy());
                }
                break;

            case 6://duck
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(duckSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(duckSubSandy());
                }
                break;

            case 7://elephant
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(elephantSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(elephantSubSandy());
                }
                break;

            case 8://horse
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(horseSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(horseSubSandy());
                }
                break;

            case 9://koi
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(koiSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(koiSubSandy());
                }
                break;

            case 10://leopard

                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(leopardSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(leopardSubSandy());
                }
                break;

            case 11://octopus
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(octopusSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(octopusSubSandy());
                }
                break;

            case 12://pigeon
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(pigeonSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(pigeonSubSandy());
                }
                break;

            case 13://piranha
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(piranhaSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(piranhaSubSandy());
                }
                break;

            case 14://rhinoceros
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(rhinocerosSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(rhinocerosSubSandy());
                }
                break;

            case 15://seagull
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(seagullSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(seagullSubSandy());
                }
                break;

            case 16://shark
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(sharkSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(sharkSubSandy());
                }
                break;

            case 17://owl
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(owlSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(owlSubSandy());
                }
                break;

            case 18://tiger
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(tigerSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(tigerSubSandy());
                }

                break;

            case 19://zebra
                if (guideChosen == "boy_guide")
                {
                    StartCoroutine(zebraSubPatrick());
                }
                else if (guideChosen == "girl_guide")
                {
                    StartCoroutine(zebraSubSandy());
                }
                break;
        }
    }
    
    //Patrick

    IEnumerator batSubPatrick()
    {

            subtitleTxt.text = "Bats are the only mammals capable of sustained flight.";
            yield return new WaitForSeconds(3f);

            subtitleTxt.text = "Their wings are essentially elongated";
            yield return new WaitForSeconds(2.8f);

            subtitleTxt.text = "webbed hands with a flexible membrane of skin";
            yield return new WaitForSeconds(3f);

            subtitleTxt.text = "that stretches between their fingers and arms";
            yield return new WaitForSeconds(2.7f);

            subtitleTxt.text = "This adaptation allows them to fly";
            yield return new WaitForSeconds(2.3f);

            subtitleTxt.text = "and maneuver with great agility";
            yield return new WaitForSeconds(2f);

            subtitleTxt.text = "Bats have diverse diets, which vary by species";
            yield return new WaitForSeconds(3f);

            subtitleTxt.text = "While many bats are insectivores and";
            yield return new WaitForSeconds(2.7f);

            subtitleTxt.text = "play a crucial role in controlling";
            yield return new WaitForSeconds(1.7f);

            subtitleTxt.text = "insect populations, others are frugivores (fruit eaters)";
            yield return new WaitForSeconds(3.7f);

            subtitleTxt.text = "nectarivores (nectar feeders), or even";
            yield return new WaitForSeconds(2.5f);

            subtitleTxt.text = "carnivores that feed on small vertebrates";
            yield return new WaitForSeconds(3f);
         
            subtitleTxt.text = "The diet of a bat is closely tied";
            yield return new WaitForSeconds(2.5f);

            subtitleTxt.text = "to its specific ecological niche";
            yield return new WaitForSeconds(2.7f);

            subtitleTxt.text = "Most bat species use echolocation to";
            yield return new WaitForSeconds(2.5f);

            subtitleTxt.text = "navigate and locate prey in the dark";
            yield return new WaitForSeconds(2.5f);

            subtitleTxt.text = "They emit high-pitched sound waves (ultrasounds)";
            yield return new WaitForSeconds(2.7f);

            subtitleTxt.text = "and listen for the echoes produced";
            yield return new WaitForSeconds(1.7f);

            subtitleTxt.text = "when these waves bounce off objects";
            yield return new WaitForSeconds(2f);

            subtitleTxt.text = "By interpreting these echoes";
            yield return new WaitForSeconds(2f);

            subtitleTxt.text = "bats can create a mental";
            yield return new WaitForSeconds(1.8f);

            subtitleTxt.text = "map of their surroundings and";
            yield return new WaitForSeconds(1.8f);

            subtitleTxt.text = "pinpoint the location of prey";
            yield return new WaitForSeconds(2f);

            subtitleTxt.text = "Echolocation is an incredibly sophisticated";
            yield return new WaitForSeconds(3f);

            subtitleTxt.text = "and precise navigation system";
            yield return new WaitForSeconds(3f);
            yield return null;

    }
    IEnumerator bearSubPatrick()
    {
        subtitleTxt.text = "Bears are known for their ability to";
        yield return new WaitForSeconds(1.5f);

        subtitleTxt.text = "hibernate during the winter months";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "While in hibernation, their metabolic rate drops";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "significantly, and they do not eat or drink";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "They rely on stored body fat for sustenance";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "There are several bear species, including the polar bear";
        yield return new WaitForSeconds(3.4f);

        subtitleTxt.text = "brown bear, black bear, and panda bear";
        yield return new WaitForSeconds(3.2f);

        subtitleTxt.text = "Each species has its unique adaptations and behaviors";
        yield return new WaitForSeconds(4.2f);

        subtitleTxt.text = "Bears are omnivorous, meaning they eat a variety of foods";
        yield return new WaitForSeconds(3.2f);

        subtitleTxt.text = "including plants, fruits, insects, fish, and, in some cases, larger prey";
        yield return new WaitForSeconds(4.7f);

        subtitleTxt.text = "Their diet can vary depending on the species and habitat";
        yield return new WaitForSeconds(4f);
        yield return null;
    }
    IEnumerator camelSubPatrick()
    {
        subtitleTxt.text = "There are two main species of camels";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "the Dromedary camel (Camelus dromedarius), which has a single hump";
        yield return new WaitForSeconds(4.5f);

        subtitleTxt.text = "and the Bactrian camel (Camelus bactrianus), which has two humps";
        yield return new WaitForSeconds(4.5f);

        subtitleTxt.text = "Dromedary camels are more common in North Africa and the Middle East";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "while Bactrian camels are typically found in Central Asia";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Camels are often called \"ships of the desert\"";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "because of their remarkable ability to store water";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Their humps are not water storage containers";
        yield return new WaitForSeconds(2.8f);

        subtitleTxt.text = "but rather fat reservoirs";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "When a camel's body breaks down this fat, it releases water";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "as a byproduct, helping them survive in arid environments";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator crabSubPatrick()
    {

        subtitleTxt.text = "Crabs have a hard exoskeleton that provides";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "protection and support for their bodies";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "As they grow, they periodically shed this";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "exoskeleton in a process called molting";
        yield return new WaitForSeconds(3.6f);

        subtitleTxt.text = "Crabs are known for their distinctive way of";
        yield return new WaitForSeconds(1.8f);

        subtitleTxt.text = "moving sideways, a result of the structure of their legs";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "This lateral movement is highly efficient for";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "for navigating in their underwater environments";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Crabs are incredibly diverse, with";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "thousands of species found in various";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "aquatic habitats, including oceans";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "rivers, and freshwater bodies";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "They come in various sizes, shapes, and colors";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator crocodileSubPatrick()
    {
        subtitleTxt.text = "Crocodiles are ancient reptiles that";
        yield return new WaitForSeconds(1.8f);

        subtitleTxt.text = "have been around for millions of years";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They are often referred to as \"living fossils\" ";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "because their basic body plan has remained";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "relatively unchanged for a long time";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Crocodiles are ectothermic, which means they rely on external";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "sources of heat to regulate their body temperature";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They are known for their patience when hunting, often lying";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "in wait for prey to come close before striking";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Crocodiles have one of the strongest";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "bite forces in the animal kingdom";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Their jaws can exert immense pressure when clamping";
        yield return new WaitForSeconds(3.4f);

        subtitleTxt.text = "down on prey, making them formidable predators";
        yield return new WaitForSeconds(3f);

        yield return null;
    }
    IEnumerator deerSubPatrick()
    {
        subtitleTxt.text = "Male deer, known as bucks, grow ";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "and shed their antlers every year";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "The size and complexity of the antlers can vary ";
        yield return new WaitForSeconds(2.8f);

        subtitleTxt.text = "based on factors like age, genetics, and nutrition";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Deer are herbivores and ruminants";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "meaning they have a specialized stomach with four compartments";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "to help digest plant material effectively";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Many deer species exhibit seasonal migrations";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "moving between different habitats in search of food";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "and to avoid harsh weather conditions";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "This behavior is an adaptation for survival";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator duckSubPatrick()
    {
        subtitleTxt.text = "Ducks have a special gland near their tails ";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "called the uropygial gland that produces oil";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "Ducks use their bills to spread this oil over their feathers";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "which helps make them highly water-resistant";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "This adaptation keeps them dry and buoyant while swimming";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Ducks are known for their quacking sounds";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "but not all ducks quack, and the";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "sounds they make can vary widely";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "For example, male mallards (drakes)";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "often produce the classic \"quack\" sound";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "while female mallards make softer, more raspy sounds";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Other duck species have distinct vocalizations";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "which they use for communication and attracting mates";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Ducks belong to the family Anatidae, and there are over";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "120 different species of ducks worldwide";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They can be found in various habitats";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "including freshwater lakes, rivers, marshes";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "and even some saltwater environments";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Some well-known duck species include the mallard";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "wood duck, and the northern pintail";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "but there are many more with unique characteristics";
        yield return new WaitForSeconds(3f);

        yield return null;
    }
    IEnumerator elephantSubPatrick()
    {
        subtitleTxt.text = "Elephants are known for their remarkable memory";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They can remember locations of water sources, recognize other individuals";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "and even recall past experiences for many years";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Elephants are the largest land mammals on Earth";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "with African elephants being larger than their Asian counterparts";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Adult African elephants can weigh up to 14,000 pounds (6,350 kg).";
        yield return new WaitForSeconds(7f);

        subtitleTxt.text = "Elephants are highly social creatures that live in";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "close-knit family groups led by a matriarch";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "They communicate with each other through";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "a variety of vocalizations, body language, and infrasound";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator horseSubPatrick()
    {
        subtitleTxt.text = "Horses are known for their speed, and thoroughbred";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "racehorses can reach speeds of over 40 miles per hour (65 km/h)";
        yield return new WaitForSeconds(5f);

        subtitleTxt.text = "The fastest recorded speed for a horse was 55 miles per hour (88.5 km/h)";
        yield return new WaitForSeconds(6f);

        subtitleTxt.text = "Horses are herbivores, but unlike some other herbivores";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "with multi-chambered stomachs";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "they have a simple, single-chambered stomach";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "This means they are more prone to digestive issues like colic";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "Horses have played a crucial role in human history";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "from transportation to agriculture and warfare";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "They were first domesticated around 4,000-3,000 BCE and have";
        yield return new WaitForSeconds(5f);

        subtitleTxt.text = "been vital to the development of many cultures and civilizations";
        yield return new WaitForSeconds(4f);



        yield return null;
    }
    IEnumerator koiSubPatrick()
    {
        subtitleTxt.text = "Koi fish, particularly the brightly colored varieties";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "have deep cultural and symbolic significance in Japan";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "They are associated with qualities like";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "perseverance, endurance, and good luck";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Koi have a relatively long lifespan";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "compared to many other fish";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "In ideal conditions, they can live for several decades";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "with some reports of koi living over 100 years";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Koi come in a wide range of color varieties";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "including red, orange, yellow, blue, black, and white";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "Different patterns and combinations of these colors";
        yield return new WaitForSeconds(2.6f);

        subtitleTxt.text = "create many distinct and prized koi varieties";
        
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator leopardSubPatrick()
    {
        subtitleTxt.text = "Leopards are renowned for their ability to blend";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "into their surroundings due to their spotted coat";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "Their spots, called rosettes, provide";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "excellent camouflage in various habitats";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "Leopards are incredibly strong and agile predators";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "They can carry prey larger than their own body weight";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "into trees to protect it from scavengers";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Leopards have one of the most extensive";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "geographical ranges of any big cat";
        yield return new WaitForSeconds(2.6f);

        subtitleTxt.text = "They are adaptable and can be found in a";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "variety of habitats across Africa and parts of Asia";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator octopusSubPatrick()
    {
        subtitleTxt.text = "Octopuses are considered one of";
        yield return new WaitForSeconds(1.5f);

        subtitleTxt.text = "the most intelligent invertebrates";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "They have complex problem-solving abilities";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "excellent memory, and can exhibit learning behavior";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Octopuses are experts in camouflage and can change both";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "their color and texture to match their surroundings";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "This skill is vital for hunting and avoiding predators";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Octopuses have three hearts";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Two of these pump blood to the gills";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "while the third heart is responsible for circulating ";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "oxygenated blood to the rest of the body";
        yield return new WaitForSeconds(3f);

        yield return null;
    }
    IEnumerator pigeonSubPatrick()
    {
        subtitleTxt.text = "Pigeons have a remarkable homing ability";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "and they can find their way home even when released";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "hundreds of miles away from their loft";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Pigeons have been used as messenger birds for centuries";
        yield return new WaitForSeconds(3.2f);

        subtitleTxt.text = "with some trained pigeons delivering";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "important messages during wars";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "The common pigeon is a descendant of wild rock pigeons";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "and has been domesticated for various purposes";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "including racing and as pets";
        yield return new WaitForSeconds(2f);
        yield return null;
    }
    IEnumerator piranhaSubPatrick()
    {
        subtitleTxt.text = "Piranhas are well-known for their sharp, interlocking teeth";
        yield return new WaitForSeconds(3.2f);

        subtitleTxt.text = "which they use to rip apart prey";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Their reputation as \"vicious killers\" is somewhat exaggerated";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "but they are opportunistic carnivores";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Piranhas often hunt in groups, which";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "can make them more effective predators";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "In a feeding frenzy, they can";
        yield return new WaitForSeconds(1.5f);

        subtitleTxt.text = "strip the flesh off prey very quickly";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Piranhas are primarily found in the rivers and";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "tributaries of the Amazon Basin in South America";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator rhinocerosSubPatrick()
    {
        subtitleTxt.text = "Rhinoceroses are known for their thick, tough skin";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "which can be as much as 1.5 inches (3.8 cm) thick";
        yield return new WaitForSeconds(4.7f);

        subtitleTxt.text = "This skin helps protect them from";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "thorns, branches, and insect bites";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Despite its appearance, rhino skin is actually quite sensitive";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "to sunburn and insect bites, which is why they often";
        yield return new WaitForSeconds(2.9f);

        subtitleTxt.text = "wallow in mud to create a protective layer";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "There are five species of rhinoceros, and they";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "they are divided into two main genera";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "The first genus is Dicerorhinus, which includes";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "the critically endangered Sumatran and Javan rhinoceroses";
        yield return new WaitForSeconds(3.8f);

        subtitleTxt.text = "The second genus is Rhinoceros, which includes";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "the White, Black, and Indian rhinoceroses";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator seagullSubPatrick()
    {
        subtitleTxt.text = "Seagulls are a diverse group of birds in the Laridae family";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "and they are found all over the world, not just near the sea";
        yield return new WaitForSeconds(4.7f);

        subtitleTxt.text = "They adapt to various environments, including urban areas";
        yield return new WaitForSeconds(4.3f);

        subtitleTxt.text = "Seagulls are opportunistic feeders, and their diet can";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "include fish, insects, small mammals, and even human scraps";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Some species of seagulls can live for several decades";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "with the oldest recorded seagull";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "living to be over 49 years old";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator sharkSubPatrick()
    {
        subtitleTxt.text = "Sharks are ancient creatures that have been around";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "for over 400 million years, predating dinosaurs";
        yield return new WaitForSeconds(3.8f);

        subtitleTxt.text = "They are considered one of";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "the oldest vertebrate groups on Earth";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "Sharks have rows of teeth that are";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "constantly replaced throughout their lives";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "A single shark may lose thousands";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "of teeth during its lifetime";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "There are over 500 different species of sharks";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "ranging from the massive whale shark";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "to the small dwarf lanternshark, each with its";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "unique characteristics and adaptations";
        yield return new WaitForSeconds(3f);


        yield return null;
    }
    IEnumerator owlSubPatrick()
    {
        subtitleTxt.text = "Owls are known for their silent flight";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "They have specialized wing feathers";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "that reduce turbulence and noise";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "allowing them to fly silently and hunt stealthily";
        yield return new WaitForSeconds(3.8f);

        subtitleTxt.text = "Owls have large, forward-facing eyes";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "that give them excellent binocular vision";
        yield return new WaitForSeconds(2.73f);

        subtitleTxt.text = "Their eyes are so large that they cannot";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "move them within their sockets";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "which is why they can rotate their heads up";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "to 270 degrees to see in different directions";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Owls have highly developed hearing";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "with asymmetrical ear openings that allow them";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "to pinpoint the location of prey by";
        yield return new WaitForSeconds(1.8f);

        subtitleTxt.text = "detecting even the slightest of sounds";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "This keen sense of hearing";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "helps them hunt in complete darkness";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator tigerSubPatrick()
    {
        subtitleTxt.text = "Tigers are the largest of all the big cat species";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "with some individuals reaching lengths of";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "up to 12 feet and weighing over 900 pounds";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Tigers are primarily solitary animals, with each";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "individual typically claiming its own territory";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They are known for their ambush hunting style";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Tigers are endangered due to habitat loss and poaching";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Conservation efforts are in place to";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "protect these magnificent creatures";
        yield return new WaitForSeconds(3f);

        yield return null;
    }
    IEnumerator zebraSubPatrick()
    {
        subtitleTxt.text = "Zebras are known for their distinctive black and white stripes";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Scientists still debate the exact purpose of these stripes";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "with theories including camouflage and discouraging biting flies";
        yield return new WaitForSeconds(4.5f);

        subtitleTxt.text = "Zebras are social animals that often form";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "herds for protection against predators";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "They have a complex social structure";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Each zebra's stripe pattern is unique, much like human fingerprints";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "making it easier for individuals to recognize one another within a herd";
        yield return new WaitForSeconds(5f);

        yield return null;
    }

    //Sandy
    IEnumerator batSubSandy()
    {
        subtitleTxt.text = "Bats are the only mammals capable of sustained flight.";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Their wings are essentially elongated";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "webbed hands with a flexible membrane of skin";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "that stretches between their fingers and arms";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "This adaptation allows them to fly";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "and maneuver with great agility";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Bats have diverse diets, which vary by species";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "While many bats are insectivores and";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "play a crucial role in controlling";
        yield return new WaitForSeconds(1.5f);

        subtitleTxt.text = "insect populations, others are frugivores (fruit eaters)";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "nectarivores (nectar feeders), or even";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "carnivores that feed on small vertebrates";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "The diet of a bat is closely tied";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "to its specific ecological niche";
        yield return new WaitForSeconds(2.1f);

        subtitleTxt.text = "Most bat species use echolocation to";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "navigate and locate prey in the dark";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "They emit high-pitched sound waves (ultrasounds)";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "and listen for the echoes produced";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "when these waves bounce off objects";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "By interpreting these echoes";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "bats can create a mental";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "map of their surroundings and";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "pinpoint the location of prey";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Echolocation is an incredibly sophisticated";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "and precise navigation system";
        yield return new WaitForSeconds(3f);
        yield return null;
        yield return null;
    }
    IEnumerator bearSubSandy()
    {
        subtitleTxt.text = "Bears are known for their ability to";
        yield return new WaitForSeconds(1.8f);

        subtitleTxt.text = "hibernate during the winter months";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "While in hibernation, their metabolic rate drops";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "significantly, and they do not eat or drink";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They rely on stored body fat for sustenance";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "There are several bear species, including the polar bear";
        yield return new WaitForSeconds(3.4f);

        subtitleTxt.text = "brown bear, black bear, and panda bear";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Each species has its unique adaptations and behaviors";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "Bears are omnivorous, meaning they eat a variety of foods";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "including plants, fruits, insects, fish, and, in some cases, larger prey";
        yield return new WaitForSeconds(4.7f);

        subtitleTxt.text = "Their diet can vary depending on the species and habitat";
        yield return new WaitForSeconds(4f);
        yield return null;
    }
    IEnumerator camelSubSandy()
    {
        subtitleTxt.text = "There are two main species of camels";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "the Dromedary camel (Camelus dromedarius), which has a single hump";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "and the Bactrian camel (Camelus bactrianus), which has two humps";
        yield return new WaitForSeconds(4.3f);

        subtitleTxt.text = "Dromedary camels are more common in North Africa and the Middle East";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "while Bactrian camels are typically found in Central Asia";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Camels are often called \"ships of the desert\"";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "because of their remarkable ability to store water";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Their humps are not water storage containers";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "but rather fat reservoirs";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "When a camel's body breaks down this fat, it releases water";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "as a byproduct, helping them survive in arid environments";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator crabSubSandy()
    {
        subtitleTxt.text = "Crabs have a hard exoskeleton that provides";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "protection and support for their bodies";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "As they grow, they periodically shed this";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "exoskeleton in a process called molting";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "Crabs are known for their distinctive way of";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "moving sideways, a result of the structure of their legs";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "This lateral movement is highly efficient for";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "for navigating in their underwater environments";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Crabs are incredibly diverse, with";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "thousands of species found in various";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "aquatic habitats, including oceans";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "rivers, and freshwater bodies";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "They come in various sizes, shapes, and colors";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator crocodileSubSandy()
    {
        subtitleTxt.text = "Crocodiles are ancient reptiles that";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "have been around for millions of years";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "They are often referred to as \"living fossils\" ";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "because their basic body plan has remained";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "relatively unchanged for a long time";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Crocodiles are ectothermic, which means they rely on external";
        yield return new WaitForSeconds(5f);

        subtitleTxt.text = "sources of heat to regulate their body temperature";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They are known for their patience when hunting, often lying";
        yield return new WaitForSeconds(3.4f);

        subtitleTxt.text = "in wait for prey to come close before striking";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Crocodiles have one of the strongest";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "bite forces in the animal kingdom";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Their jaws can exert immense pressure when clamping";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "down on prey, making them formidable predators";
        yield return new WaitForSeconds(3f);

        yield return null;
    }
    IEnumerator deerSubSandy()
    {
        subtitleTxt.text = "Male deer, known as bucks, grow ";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "and shed their antlers every year";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "The size and complexity of the antlers can vary";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "based on factors like age, genetics, and nutrition";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Deer are herbivores and ruminants";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "meaning they have a specialized stomach with four compartments";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "to help digest plant material effectively";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Many deer species exhibit seasonal migrations";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "moving between different habitats in search of food";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "and to avoid harsh weather conditions";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "This behavior is an adaptation for survival";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator duckSubSandy()
    {
        subtitleTxt.text = "Ducks have a special gland near their tails";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "called the uropygial gland that produces oil";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Ducks use their bills to spread this oil over their feathers";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "which helps make them highly water-resistant";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "This adaptation keeps them dry and buoyant while swimming";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Ducks are known for their quacking sounds";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "but not all ducks quack, and the";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "sounds they make can vary widely";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "For example, male mallards (drakes)";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "often produce the classic \"quack\" sound";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "while female mallards make softer, more raspy sounds";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "Other duck species have distinct vocalizations";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "which they use for communication and attracting mates";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Ducks belong to the family Anatidae, and there are over";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "120 different species of ducks worldwide";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "They can be found in various habitats";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "including freshwater lakes, rivers, marshes";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "and even some saltwater environments";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Some well-known duck species include the mallard";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "wood duck, and the northern pintail";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "but there are many more with unique characteristics";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator elephantSubSandy()
    {
        subtitleTxt.text = "Elephants are known for their remarkable memory";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They can remember locations of water sources, recognize other individuals";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "and even recall past experiences for many years";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Elephants are the largest land mammals on Earth";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "with African elephants being larger than their Asian counterparts";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Adult African elephants can weigh up to 14,000 pounds (6,350 kg).";
        yield return new WaitForSeconds(6f);

        subtitleTxt.text = "Elephants are highly social creatures that live in";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "close-knit family groups led by a matriarch";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "They communicate with each other through";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "a variety of vocalizations, body language, and infrasound";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator horseSubSandy()
    {
        subtitleTxt.text = "Horses are known for their speed, and thoroughbred";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "racehorses can reach speeds of over 40 miles per hour (65 km/h)";
        yield return new WaitForSeconds(5.5f);

        subtitleTxt.text = "The fastest recorded speed for a horse was 55 miles per hour (88.5 km/h)";
        yield return new WaitForSeconds(7.5f);

        subtitleTxt.text = "Horses are herbivores, but unlike some other herbivores";
        yield return new WaitForSeconds(3.6f);

        subtitleTxt.text = "with multi-chambered stomachs";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "they have a simple, single-chambered stomach";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "This means they are more prone to digestive issues like colic";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Horses have played a crucial role in human history";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "from transportation to agriculture and warfare";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They were first domesticated around 4,000-3,000 BCE and have";
        yield return new WaitForSeconds(5.3f);

        subtitleTxt.text = "been vital to the development of many cultures and civilizations";
        yield return new WaitForSeconds(4f);
        yield return null;
    }
    IEnumerator koiSubSandy()
    {
        subtitleTxt.text = "Koi fish, particularly the brightly colored varieties";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "have deep cultural and symbolic significance in Japan";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "They are associated with qualities like";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "perseverance, endurance, and good luck";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Koi have a relatively long lifespan";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "compared to many other fish";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "In ideal conditions, they can live for several decades";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "with some reports of koi living over 100 years";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "Koi come in a wide range of color varieties";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "including red, orange, yellow, blue, black, and white";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "Different patterns and combinations of these colors";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "create many distinct and prized koi varieties";

        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator leopardSubSandy()
    {
        subtitleTxt.text = "Leopards are renowned for their ability to blend";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "into their surroundings due to their spotted coat";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Their spots, called rosettes, provide";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "excellent camouflage in various habitats";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Leopards are incredibly strong and agile predators";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "They can carry prey larger than their own body weight";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "into trees to protect it from scavengers";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Leopards have one of the most extensive";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "geographical ranges of any big cat";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "They are adaptable and can be found in a";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "variety of habitats across Africa and parts of Asia";
        yield return new WaitForSeconds(3f);

        yield return null;
    }
    IEnumerator octopusSubSandy()
    {
        subtitleTxt.text = "Octopuses are considered one of";
        yield return new WaitForSeconds(1.8f);

        subtitleTxt.text = "the most intelligent invertebrates";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "They have complex problem-solving abilities";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "excellent memory, and can exhibit learning behavior";
        yield return new WaitForSeconds(3.2f);

        subtitleTxt.text = "Octopuses are experts in camouflage and can change both";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "their color and texture to match their surroundings";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "This skill is vital for hunting and avoiding predators";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Octopuses have three hearts";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Two of these pump blood to the gills";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "while the third heart is responsible for circulating ";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "oxygenated blood to the rest of the body";
        yield return new WaitForSeconds(2f);


        yield return null;
    }
    IEnumerator pigeonSubSandy()
    {
        subtitleTxt.text = "Pigeons have a remarkable homing ability";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "and they can find their way home even when released";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "hundreds of miles away from their loft";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Pigeons have been used as messenger birds for centuries";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "with some trained pigeons delivering";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "important messages during wars";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "The common pigeon is a descendant of wild rock pigeons";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "and has been domesticated for various purposes";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "including racing and as pets";
        yield return new WaitForSeconds(2f);
        yield return null;
    }
    IEnumerator piranhaSubSandy()
    {
        subtitleTxt.text = "Piranhas are well-known for their sharp, interlocking teeth";
        yield return new WaitForSeconds(3.2f);

        subtitleTxt.text = "which they use to rip apart prey";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "Their reputation as \"vicious killers\" is somewhat exaggerated";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "but they are opportunistic carnivores";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Piranhas often hunt in groups, which";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "can make them more effective predators";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "In a feeding frenzy, they can";
        yield return new WaitForSeconds(1.5f);

        subtitleTxt.text = "strip the flesh off prey very quickly";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Piranhas are primarily found in the rivers and";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "tributaries of the Amazon Basin in South America";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator rhinocerosSubSandy()
    {
        subtitleTxt.text = "Rhinoceroses are known for their thick, tough skin";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "which can be as much as 1.5 inches (3.8 cm) thick";
        yield return new WaitForSeconds(5.8f);

        subtitleTxt.text = "This skin helps protect them from";
        yield return new WaitForSeconds(1.6f);

        subtitleTxt.text = "thorns, branches, and insect bites";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "Despite its appearance, rhino skin is actually quite sensitive";
        yield return new WaitForSeconds(4.3f);

        subtitleTxt.text = "to sunburn and insect bites, which is why they often";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "wallow in mud to create a protective layer";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "There are five species of rhinoceros, and they";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "they are divided into two main genera";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "The first genus is Dicerorhinus, which includes";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "the critically endangered Sumatran and Javan rhinoceroses";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "The second genus is Rhinoceros, which includes";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "the White, Black, and Indian rhinoceroses";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator seagullSubSandy()
    {
        subtitleTxt.text = "Seagulls are a diverse group of birds in the Laridae family";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "and they are found all over the world, not just near the sea";
        yield return new WaitForSeconds(3.7f);

        subtitleTxt.text = "They adapt to various environments, including urban areas";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Seagulls are opportunistic feeders, and their diet can";
        yield return new WaitForSeconds(3.2f);

        subtitleTxt.text = "include fish, insects, small mammals, and even human scraps";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Some species of seagulls can live for several decades";
        yield return new WaitForSeconds(3.2f);

        subtitleTxt.text = "with the oldest recorded seagull";
        yield return new WaitForSeconds(1.5f);

        subtitleTxt.text = "living to be over 49 years old";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator sharkSubSandy()
    {
        subtitleTxt.text = "Sharks are ancient creatures that have been around";
        yield return new WaitForSeconds(2.4f);

        subtitleTxt.text = "for over 400 million years, predating dinosaurs";
        yield return new WaitForSeconds(4.2f);

        subtitleTxt.text = "They are considered one of";
        yield return new WaitForSeconds(1.4f);

        subtitleTxt.text = "the oldest vertebrate groups on Earth";
        yield return new WaitForSeconds(2.3f);

        subtitleTxt.text = "Sharks have rows of teeth that are";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "constantly replaced throughout their lives";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "A single shark may lose thousands";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "of teeth during its lifetime";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "There are over 500 different species of sharks";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "ranging from the massive whale shark";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "to the small dwarf lanternshark, each with its";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "unique characteristics and adaptations";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator owlSubSandy()
    {
        subtitleTxt.text = "Owls are known for their silent flight";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "They have specialized wing feathers";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "that reduce turbulence and noise";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "allowing them to fly silently and hunt stealthily";
        yield return new WaitForSeconds(3.8f);

        subtitleTxt.text = "Owls have large, forward-facing eyes";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "that give them excellent binocular vision";
        yield return new WaitForSeconds(2.7f);

        subtitleTxt.text = "Their eyes are so large that they cannot";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "move them within their sockets";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "which is why they can rotate their heads up";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "to 270 degrees to see in different directions";
        yield return new WaitForSeconds(3.5f);

        subtitleTxt.text = "Owls have highly developed hearing";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "with asymmetrical ear openings that allow them";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "to pinpoint the location of prey by";
        yield return new WaitForSeconds(1.8f);

        subtitleTxt.text = "detecting even the slightest of sounds";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "This keen sense of hearing";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "helps them hunt in complete darkness";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator tigerSubSandy()
    {
        subtitleTxt.text = "Tigers are the largest of all the big cat species";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "with some individuals reaching lengths of";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "up to 12 feet and weighing over 900 pounds";
        yield return new WaitForSeconds(4f);

        subtitleTxt.text = "Tigers are primarily solitary animals, with each";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "individual typically claiming its own territory";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "They are known for their ambush hunting style";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "Tigers are endangered due to habitat loss and poaching";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Conservation efforts are in place to";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "protect these magnificent creatures";
        yield return new WaitForSeconds(3f);
        yield return null;
    }
    IEnumerator zebraSubSandy()
    {
        subtitleTxt.text = "Zebras are known for their distinctive black and white stripes";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "Scientists still debate the exact purpose of these stripes";
        yield return new WaitForSeconds(3.3f);

        subtitleTxt.text = "with theories including camouflage";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "and discouraging biting flies";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Zebras are social animals that often form";
        yield return new WaitForSeconds(3f);

        subtitleTxt.text = "herds for protection against predators";
        yield return new WaitForSeconds(2.5f);

        subtitleTxt.text = "They have a complex social structure";
        yield return new WaitForSeconds(2f);

        subtitleTxt.text = "Each zebra's stripe pattern is unique";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "much like human fingerprints";
        yield return new WaitForSeconds(1.7f);

        subtitleTxt.text = "making it easier for individuals to";
        yield return new WaitForSeconds(2.2f);

        subtitleTxt.text = "recognize one another within a herd";
        yield return new WaitForSeconds(2.3f);

        yield return null;
    }
}
