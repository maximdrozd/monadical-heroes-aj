using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems
{
    public class HeroSystem : MonoBehaviour
    {
        public string[] namePrefix;
        public string[] nameCore;
        public string[] nameSuffix;
        public GameObject pfHero;
        public List<Stat> statPool;
        public GameObject[] ragdolls;
        public List<Hero> heroes;
        public static HeroSystem Instance;
        public Hero activeHero;

        private void Awake()
        {
            Instance = this;
            heroes = new List<Hero>();
        }

        public void SetActiveHero(Hero hero)
        {
            //Reset selection color back to default
            if(activeHero) activeHero.GetComponent<Hero>().SetActive(false);
            //Set new active hero with all parameters
            activeHero = hero;
            hero.SetActive(true);
        }

        public void SpawnRandomHero()
        {
            GameObject hero = Instantiate(pfHero, new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)),
                Quaternion.identity);
            Hero heroBehaviour = hero.GetComponent<Hero>();
            heroBehaviour.stats = statPool.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            heroBehaviour.displayName = $"{namePrefix[Random.Range(0, namePrefix.Length)]} " +
                                        $"{nameCore[Random.Range(0, nameCore.Length)]} " +
                                        $"{nameSuffix[Random.Range(0, nameSuffix.Length)]}";
            Destroy(heroBehaviour.ragdoll);
            heroes.Add(heroBehaviour);
            heroBehaviour.ragdoll = Instantiate(ragdolls[heroes.Count % ragdolls.Length], hero.transform);
        }
    }
}