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
                    triviaDisp.text = "Bats are the only mammals capable of sustained flight.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "A group of bats is called a colony.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Bats use echolocation to navigate and hunt for food.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "There are over 1,400 species of bats worldwide.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Bats are important pollinators for many plants.";
                }
                break;

            case 1: // bear
                if (randNum == 1)
                {
                    triviaDisp.text = "Bears are strong swimmers and can cover long distances in water.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Polar bears are the largest land carnivores and are excellent hunters in the Arctic.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Koalas, often called bears, are not bears at all but marsupials.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Brown bears, like grizzlies, can be found in various parts of North America and Eurasia.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Pandas have a diet primarily consisting of bamboo, but they are classified as bears.";
                }
                break;

            case 2: // camel
                if (randNum == 1)
                {
                    triviaDisp.text = "Camels are known as 'ships of the desert' due to their ability to traverse harsh desert terrain.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Dromedary camels have one hump, while Bactrian camels have two.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Camels can drink up to 40 gallons of water in one go to survive in arid conditions.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Camels are social animals and live in groups called herds.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Camels have been domesticated for over 3,000 years and have been used for transportation and carrying goods.";
                }
                break;

            case 3: // crab
                if (randNum == 1)
                {
                    triviaDisp.text = "Crabs belong to the crustacean family and are known for their hard exoskeletons.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Some crabs can walk sideways, a unique and characteristic movement.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Hermit crabs use empty shells as their protective homes and change shells as they grow.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Crabs are omnivorous, feeding on both plants and small animals.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "The coconut crab, the largest land-living arthropod, can climb trees and crack open coconuts with its powerful claws.";
                }
                break;

            case 4: // crocodile
                if (randNum == 1)
                {
                    triviaDisp.text = "Crocodiles are ancient reptiles that have been around for over 200 million years.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "They are known for their powerful jaws, which can exert tremendous bite force.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Crocodiles are excellent swimmers and can move swiftly both in water and on land.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Female crocodiles are attentive mothers, guarding their nests and protecting their young.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Crocodiles have a keen sense of hearing and can communicate with each other using vocalizations.";
                }
                break;

            case 5: // deer
                if (randNum == 1)
                {
                    triviaDisp.text = "Deer are herbivorous mammals known for their graceful appearance and antlers.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Only male deer, called bucks, grow antlers, which are shed and regrown each year.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Deer are known for their keen sense of hearing and ability to detect predators.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Deer are crepuscular animals, meaning they are most active during dawn and dusk.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "White-tailed deer are one of the most common and widely distributed deer species in North America.";
                }
                break;

            case 6: // duck
                if (randNum == 1)
                {
                    triviaDisp.text = "Ducks have waterproof feathers due to a special gland near their tails.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Mallards are one of the most common and widely recognized duck species.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Ducks are omnivorous, feeding on a diet that includes aquatic plants, insects, and small fish.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Ducklings are known for their adorable yellow fluff and are excellent swimmers from a young age.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Ducks are migratory birds, and many species undertake long-distance migrations during seasonal changes.";
                }
                break;

            case 7: // elephant
                if (randNum == 1)
                {
                    triviaDisp.text = "Elephants are the largest land animals on Earth, with some individuals weighing over 10 tons.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Elephants are known for their long trunks, which are actually elongated noses and upper lips.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Elephants are highly intelligent and have complex social structures, living in tight-knit family groups.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "The African elephant is the largest species of elephant and has larger ears compared to the Asian elephant.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Elephants are herbivores, and they can consume large quantities of vegetation each day.";
                }
                break;

            case 8: // horse
                if (randNum == 1)
                {
                    triviaDisp.text = "Horses have been domesticated by humans for thousands of years, playing crucial roles in agriculture, transportation, and sport.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Horses have a unique digestive system called hindgut fermentation, allowing them to efficiently break down fibrous plant material.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "A horse's age can be estimated by examining its teeth, as their teeth continually erupt throughout their life.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Horses are known for their keen sense of hearing and can rotate their ears 180 degrees to detect sounds.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "The fastest recorded sprinting speed of a horse is approximately 55 miles per hour (88.5 kilometers per hour).";
                }
                break;

            case 9: // koi
                if (randNum == 1)
                {
                    triviaDisp.text = "Koi fish are a colorful variety of the common carp and are known for their vibrant patterns and colors.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Koi fish have been bred for centuries in Japan, where they are highly regarded as symbols of luck and prosperity.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Koi fish have a lifespan that can exceed 20 years, with some living much longer in the right conditions.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Koi ponds are popular in many cultures, and people often enjoy keeping these beautiful fish as ornamental pets.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Koi fish are known to be highly adaptable, and they can thrive in a wide range of water temperatures and conditions.";
                }
                break;

            case 10: // leopard
                if (randNum == 1)
                {
                    triviaDisp.text = "Leopards are known for their distinctive rosette-shaped spots on their fur.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Leopards are excellent climbers and are often seen resting in trees.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Leopards are among the strongest of the big cats and can carry prey much larger than themselves into trees.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Leopards are incredibly adaptable and can thrive in a wide range of habitats, from savannas to forests.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Leopards are known for their stealth and are capable of silently stalking their prey before making a swift attack.";
                }
                break;

            case 11: // octopus
                if (randNum == 1)
                {
                    triviaDisp.text = "Octopuses are highly intelligent marine animals, known for their problem-solving abilities.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Octopuses have three hearts: two branchial hearts that pump blood through the gills and one systemic heart that pumps blood to the rest of the body.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Octopuses are masters of camouflage and can change both the color and texture of their skin to blend in with their surroundings.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Octopuses are known for their incredible flexibility and can squeeze through tiny openings and crevices.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Octopuses have a beak-like mouth and use it to break open shells to access their prey.";
                }
                break;

            case 12: // pigeon
                if (randNum == 1)
                {
                    triviaDisp.text = "Pigeons are highly adaptable birds and can be found in urban environments all over the world.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Pigeons have an excellent sense of direction and have been used as messengers in history.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Pigeons produce a special milk-like substance called 'pigeon milk' to feed their chicks.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Pigeons are known for their distinctive cooing sounds, which can vary between species.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Pigeons have been domesticated for thousands of years and have various breeds, including racing pigeons and show pigeons.";
                }
                break;

            case 13: // piranha
                if (randNum == 1)
                {
                    triviaDisp.text = "Piranhas are known for their sharp teeth and powerful jaws, which they use to tear apart prey.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Piranhas are omnivorous and feed on a diet that includes fish, insects, and even carrion.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Piranhas are social fish and often travel in schools, which can be quite large.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Contrary to their reputation, not all piranhas are aggressive, and some species are relatively harmless to humans.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Piranhas have keen senses, including excellent vision, which helps them detect prey and navigate murky waters.";
                }
                break;

            case 14: // rhinoceros
                if (randNum == 1)
                {
                    triviaDisp.text = "Rhinoceroses are known for their thick, protective skin and large horn on their snout.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "There are five species of rhinoceros: White, Black, Indian, Javan, and Sumatran rhinoceros.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Rhinoceroses are herbivores, primarily feeding on grasses, leaves, and vegetation.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Despite their massive size, rhinoceroses can reach speeds of up to 30 miles per hour (48 kilometers per hour).";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Rhinoceros populations are threatened by poaching for their horns, which are highly sought after in illegal wildlife trade.";
                }
                break;

            case 15: // seagull
                if (randNum == 1)
                {
                    triviaDisp.text = "Seagulls are a type of bird commonly found near coastlines and bodies of water.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Seagulls are known for their distinctive calls, which can vary among different species.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Seagulls are opportunistic feeders and will eat a wide range of food, including fish, insects, and even human leftovers.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Seagulls are highly adaptable birds and can thrive in urban environments.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Seagulls are skilled flyers and are often seen gliding effortlessly on air currents near the coast.";
                }
                break;

            case 16: // shark
                if (randNum == 1)
                {
                    triviaDisp.text = "Sharks are a diverse group of fish with over 500 species, ranging in size from a few inches to over 40 feet.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Sharks have been around for over 400 million years, making them older than dinosaurs.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Sharks have a unique sense called electroreception, which allows them to detect electrical signals produced by other animals.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Great White Sharks are known for their powerful jaws and are often called 'apex predators' of the ocean.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Sharks play a crucial role in maintaining the health of marine ecosystems by controlling prey populations.";
                }
                break;

            case 17: // owl
                if (randNum == 1)
                {
                    triviaDisp.text = "Owls are birds of prey known for their silent flight, which is enabled by specialized wing feathers.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Owls have large eyes that are adapted for low light conditions, allowing them to see well at night.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Owls are excellent hunters and have strong talons and a sharp beak for capturing and consuming their prey.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Different owl species have varying calls and hoots, which are used for communication and territory marking.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Owls are often associated with wisdom and are featured in the folklore and mythology of many cultures.";
                }
                break;

            case 18: // tiger
                if (randNum == 1)
                {
                    triviaDisp.text = "Tigers are the largest big cat species and can weigh up to 700 pounds (318 kilograms).";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Tigers are known for their distinctive orange coat with black stripes, and each tiger's stripe pattern is unique.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Tigers are solitary animals and are known for their stealth and ambush hunting techniques.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "There are several subspecies of tigers, including the Bengal tiger, Siberian tiger, and Sumatran tiger.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Tigers are critically endangered, with habitat loss and poaching posing significant threats to their survival.";
                }
                break;

            case 19: // zebra
                if (randNum == 1)
                {
                    triviaDisp.text = "Zebras are known for their distinctive black and white stripes, and each zebra's stripe pattern is unique.";
                }
                else if (randNum == 2)
                {
                    triviaDisp.text = "Zebras are herbivores and primarily graze on grasses and other vegetation.";
                }
                else if (randNum == 3)
                {
                    triviaDisp.text = "Zebras are social animals and often form herds, which provide protection against predators.";
                }
                else if (randNum == 4)
                {
                    triviaDisp.text = "Zebras are native to Africa and are commonly found in savannas, grasslands, and open woodlands.";
                }
                else if (randNum == 5)
                {
                    triviaDisp.text = "Zebras have excellent stamina and can run at speeds of up to 40 miles per hour (64 kilometers per hour) to escape from predators.";
                }
                break;

        }
    }
}
