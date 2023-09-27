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
                    triviaDisp.text = "<color=#FFFF00>Bats</color> are the only mammals capable of sustained flight.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "A group of <color=#FFFF00>bats</color> is called a colony.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Bats</color> use echolocation to navigate and hunt for food.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "There are over 1,400 species of <color=#FFFF00>bats</color> worldwide.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Bats</color> are important pollinators for many plants.";
                }
                break;

            case 1: // bear
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Bears</color> are strong swimmers and can cover long distances in water.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Polar bears</color> are the largest land carnivores.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Koalas</color>, often called bears, are not bears at all but marsupials.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Brown bears</color>, can be found in various parts of North America and Eurasia.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Pandas</color> have a diet primarily consisting of bamboo, but they are classified as bears.";
                }
                break;

            case 2: // camel
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> are known as 'ships of the desert' due to their ability to traverse harsh desert terrain.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Dromedary camels</color> have one hump, while Bactrian camels have two.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> can drink up to 40 gallons of water in one go to survive in arid conditions.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> are social animals and live in groups called herds.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Camels</color> is used for transportation and carrying goods in some countries.";
                }
                break;

            case 3: // crab
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Crabs</color> belong to the crustacean family and are known for their hard exoskeletons.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Some <color=#FFFF00>crabs</color> can walk sideways, a unique and characteristic movement.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Hermit crabs</color> use empty shells as their protective homes and change shells as they grow.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Crabs</color> are omnivorous, feeding on both plants and small animals.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "The <color=#FFFF00>coconut crab</color> is the largest land-living arthropod.";
                }
                break;

            case 4: // crocodile
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Crocodiles</color> are ancient reptiles that have been around for over 200 million years.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Crocodiles</color> are known for their powerful jaws, which can exert tremendous bite force.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Crocodiles</color> are excellent swimmers and can move swiftly both in water and on land.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Female crocodiles</color> are attentive mothers, guarding their nests and protecting their young.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Crocodiles</color> have a keen sense of hearing and can communicate with each other using vocalizations.";
                }
                break;

            case 5: // deer
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Deer</color> are herbivorous mammals known for their graceful appearance and antlers.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Only <color=#FFFF00>male deer</color>, called bucks, grow antlers, which are shed and regrown each year.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Deer</color> are known for their keen sense of hearing and ability to detect predators.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Deer</color> are crepuscular animals, meaning they are most active during dawn and dusk.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>White-tailed deer</color> are one of the most common deer species in North America.";
                }
                break;

            case 6: // duck
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducks</color> have waterproof feathers due to a special gland near their tails.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Mallards</color> are one of the most common and widely recognized duck species.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducks</color> are omnivorous, feeding on aquatic plants, insects, and small fish.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducklings</color> are excellent swimmers from a young age.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Ducks</color> are migratory birds, they migrate during seasonal changes.";
                }
                break;

            case 7: // elephant
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> are the largest land animals on Earth, with some individuals weighing over 10 tons.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> are known for their long trunks, which are actually elongated noses and upper lips.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> are highly intelligent and have complex social structures, living in tight-knit family groups.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "The <color=#FFFF00>African elephant</color> is the largest species of elephant and has larger ears compared to the Asian elephant.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Elephants</color> are herbivores, and they can consume large quantities of vegetation each day.";
                }
                break;

            case 8: // horse
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Horses</color> have been domesticated by humans for thousands of years.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Horses</color> have a unique digestive system called hindgut fermentation.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "A <color=#FFFF00>horse's</color> age can be estimated by examining its teeth.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Horses</color> are known for their keen sense of hearing.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "The fastest recorded sprinting speed of a <color=#FFFF00>horse</color> is approximately 55 miles/hr";
                }
                break;

            case 9: // koi
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi</color> fish are a colorful variety of the common carp and are known for their vibrant patterns and colors.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi</color> fish have been bred for centuries in Japan, where they are highly regarded as symbols of luck and prosperity.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi</color> fish have a lifespan that can exceed 20 years, with some living much longer in the right conditions.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi</color> ponds are popular in many cultures, and people often enjoy keeping these beautiful fish as ornamental pets.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Koi</color> fish are known to be highly adaptable, and they can thrive in a wide range of water temperatures and conditions.";
                }
                break;

            case 10: // leopard
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> are known for their distinctive rosette-shaped spots on their fur.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> are excellent climbers and are often seen resting in trees.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> are among the strongest of the big cats and can carry prey much larger than themselves into trees.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> are incredibly adaptable and can thrive in a wide range of habitats, from savannas to forests.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Leopards</color> are known for their stealth and are capable of silently stalking their prey before making a swift attack.";
                }
                break;

            case 11: // octopus
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> are highly intelligent marine animals.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> have three hearts.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> are masters of camouflage and can change both the color and texture of their skin to blend in with their surroundings.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> are known for their incredible flexibility and can squeeze through tiny openings and crevices.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Octopuses</color> have a beak-like mouth and use it to break open shells to access their prey.";
                }
                break;

            case 12: // pigeon
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> are highly adaptable birds and can be found in urban environments all over the world.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> have an excellent sense of direction and have been used as messengers in history.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> produce a special milk-like substance called 'pigeon milk' to feed their chicks.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> are known for their distinctive cooing sounds, which can vary between species.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Pigeons</color> have been domesticated for thousands of years and have various breeds.";
                }
                break;

            case 13: // piranha
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Piranhas</color> are known for their sharp teeth and powerful jaws, which they use to tear apart prey.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Piranhas</color> are omnivorous and feed on a diet that includes fish, insects, and even carrion.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Piranhas</color> are social fish and often travel in schools, which can be quite large.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Not all <color=#FFFF00>piranhas</color> are aggressive, and some species are relatively harmless to humans.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Piranhas</color> have keen senses, including excellent vision, which helps them detect prey and navigate murky waters.";
                }
                break;

            case 14: // rhinoceros
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Rhinoceroses</color> are known for their thick, protective skin and large horn on their snout.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "There are five species of <color=#FFFF00>rhinoceros</color>: White, Black, Indian, Javan, and Sumatran rhinoceros.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Rhinoceroses</color> are herbivores, primarily feeding on grasses, leaves, and vegetation.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Despite their massive size, <color=#FFFF00>rhinoceroses</color> can reach speeds of up to 30 miles/hr.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Rhinoceros</color> populations are threatened by poaching for their horns, which are highly sought after in illegal wildlife trade.";
                }
                break;

            case 15: // seagull
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> are a type of bird commonly found near coastlines and bodies of water.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> are known for their distinctive calls, which can vary among different species.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> are opportunistic feeders and will eat a wide range of food, including fish, insects, and even human leftovers.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> are highly adaptable birds and can thrive in urban environments.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Seagulls</color> are skilled flyers and are often seen gliding effortlessly on air currents near the coast.";
                }
                break;

            case 16: // shark
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> are a diverse group of fish with over 500 species.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> have been around for over 400 million years.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> have a unique sense called electroreception, which allows them to detect electrical signals produced by other animals.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Great White Sharks</color> are known for their powerful jaws and are often called 'apex predators' of the ocean.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Sharks</color> play a crucial role in maintaining the health of marine ecosystems by controlling prey populations.";
                }
                break;

            case 17: // owl
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> are birds of prey known for their silent flight, which is enabled by specialized wing feathers.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> have large eyes that are adapted for low light conditions, allowing them to see well at night.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> are excellent hunters and have strong talons and a sharp beak for capturing and consuming their prey.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Different <color=#FFFF00>owl</color> species have varying calls and hoots, which are used for communication and territory marking.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Owls</color> are often associated with wisdom and are featured in the folklore and mythology of many cultures.";
                }
                break;

            case 18: // tiger
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> are the largest big cat species and can weigh up to 318 kgs.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> are known for their distinctive orange coat with black stripes.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> are solitary animals and are known for their stealth and ambush hunting techniques.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "There are several subspecies of <color=#FFFF00>tigers</color>, including the Bengal tiger, Siberian tiger, and Sumatran tiger.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Tigers</color> are critically endangered, with habitat loss and poaching posing significant threats to their survival.";
                }
                break;

            case 19: // zebra
                if (randNum == 1)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> are known for their distinctive black and white stripes.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> are herbivores and primarily graze on grasses and other vegetation.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> are social animals and often form herds, which provide protection against predators.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> are native to Africa and are commonly found in savannas, grasslands, and open woodlands.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "<color=#FFFF00>Zebras</color> have excellent stamina and can run at speeds of up to 40miles/hr to escape from predators.";
                }
                break;

        }
    }
}
