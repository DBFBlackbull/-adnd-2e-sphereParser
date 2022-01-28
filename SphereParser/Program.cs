using System.Text.RegularExpressions;

namespace SphereParser
{
    class Program
    {
        private static readonly List<string> All = new()
        {
            "Bless/Curse (1st)",
            "Combine (1st)",
            "Detect Magic (1st)",
            // "Orison (1st)",
            "Purify Food & Drink/Putrefy Food & Drink (1st)",
            "Chant (2nd)",
            "Mystic Transfer* (2nd)-",
            "Sanctify/Defile* (2nd)-",
            "Dispel Magic (3rd)",
            "Remove Curse/Bestow Curse (3rd)",
            "Focus* (4th)-",
            "Tongues (4th)",
            "Uplift* (4th)-",
            "Atonement (5th)",
            "Commune (5th)",
            "Meld* (5th)-",
            "Quest (5th)",
            "True Seeing/False Seeing (5th)",
            "Speak with Monsters (6th)",
            "Gate (7th)",
        };

        private static readonly List<string> Animal = new()
        {
            "Animal Friendship (1st)",
            // "Calm Animals (1st)",
            "Invisibility to Animals (1st)",
            "Locate Animals or Plants (1st)",
            "Charm Person or Mammal (2nd)",
            "Messenger (2nd)",
            "Snake Charm (2nd)",
            "Speak with Animals (2nd)",
            // "Control Animal (3rd)",
            "Hold Animal (3rd)",
            "Summon Insects (3rd)",
            "Animal Summoning I (4th)",
            "Call Woodland Beings (4th)",
            "Giant Insect (4th)",
            "Repel Insects (4th)",
            "Animal Growth (5th)",
            "Animal Summoning II (5th)",
            "Commune with Nature (5th)",
            "Insect Plague (5th)",
            "Animal Summoning III (6th)",
            "Antianimal Shell (6th)",
            "Creeping Doom (7th)",
            "Reincarnate (7th)",
        };

        private static readonly List<string> Astral = new()
        {
            // "Astral Celerity (1st)",
            "Speak with Astral Traveler (1st)-",
            // "Astral Awareness (2nd)",
            // "Ethereal Barrier (2nd)",
            "Astral Window (3rd)-",
            // "Etherealness (3rd)",
            "Join with Astral Traveler (4th)-",
            "Plane Shift (5th)",
            "Astral Spell (7th)",
        };

        private static readonly List<string> Chaos = new()
        {
            // "Battlefate (1st)",
            "Mistaken Missive (1st)-",
            // "Chaos Ward (2nd)",
            "Dissension’s Feast (2nd)-",
            "Miscast Magic (3rd)-",
            "Random Causality (3rd)-",
            "Chaotic Combat (4th)-",
            "Chaotic Sleep (4th)-",
            "Inverted Ethics (4th)-",
            "Chaotic Commands (5th)-",
            // "Entropy Shield (6th)",
            "Uncontrolled Weather (7th)-",
        };

        private static readonly List<string> Charm = new()
        {
            "Command (1st)",
            "Remove Fear/Cause Fear (1st)",
            "Sanctuary (1st)",
            "Enthrall (2nd)",
            "Hold Person (2nd)",
            "Music of the Spheres (2nd)-",
            "Snake Charm (2nd)",
            // "Dictate (3rd)",
            "Emotion Control (3rd)-",
            "Cloak of Bravery/Cloak of Fear (4th)",
            "Free Action (4th)",
            "Imbue with Spell Ability (4th)",
            // "Command Monster (6th)",
            "Confusion (7th)",
            "Exaction (7th)",
        };

        private static readonly List<string> Combat = new()
        {
            "Command (1st)",
            "Magical Stone (1st)",
            "Aid (2nd)",
            "Spiritual Hammer (2nd)",
            "Prayer (3rd)",
            "Unearthly Choir* (3rd)-",
            // "Recitation (4th)",
            "Flame Strike (5th)",
            // "Righteous Wrath of the Faithful (5th)",
            "Spiritual Wrath* (6th)-",
            "Word of Recall (6th)",
            "Holy Word/Unholy Word (7th)",
        };

        private static readonly List<string> Creation = new()
        {
            "Light/Darkness (1st)",
            "Create Holy Symbol (2nd)-",
            "Continual Light/Continual Darkness (3rd)",
            "Create Food & Water (3rd)",
            "Blessed Abundance (5th)-",
            "Blade Barrier (6th)",
            "Heroes’ Feast (6th)",
            "The Great Circle/The Black Circle* (6th)-",
        };

        private static readonly List<string> Divination = new()
        {
            "Analyze Balance (1st)-",
            "Detect Evil/Detect Good (1st)",
            "Detect Poison (1st)",
            "Augury (2nd)",
            "Detect Charm/Undetectable Charm (2nd)",
            "Find Traps (2nd)",
            // "Detect Spirits (3rd)",
            "Extradimensional Detection (3rd)-",
            "Locate Object/Obscure Object (3rd)",
            "Speak with Dead (3rd)",
            "Detect Lie/Undetectable Lie (4th)",
            "Divination (4th)",
            // "Omniscient Eye (4th)",
            "Consequence (5th)-",
            "Magic Font (5th)",
            "Find the Path/Lose the Path (6th)",
            "Stone Tell (6th)",
            "Divine Inspiration (7th)-",
        };

        private static readonly List<string> ElementalAir = new()
        {
            // "Wind Column (1st)",
            "Dust Devil (2nd)",
            // "Wind Servant (3rd)",
            "Zone of Sweet Air (3rd)-",
            // "Windborne (4th)",
            "Air Walk (5th)",
            "Cloud of Purification (5th)-",
            "Control Winds (5th)",
            // "Whirlwind (6th)",
            // "Conjure Air Elemental (7th)",
            "Wind Walk (7th)",
        };
        private static readonly List<string> ElementalEarth = new()
        {
            // "Strength of Stone (1st)",
            // "Soften Earth and Stone (2nd)",
            "Meld into Stone (3rd)",
            "Stone Shape (3rd)",
            // "Adamantite Mace (4th)",
            "Spike Stones (5th)",
            "Transmute Rock to Mud/Transmute Mud to Rock (5th)",
            "Stone Tell (6th)",
            "Animate Rock (7th)",
            // "Antimineral Shell (7th)",
            "Conjure Earth Elemental (7th)",
            "Earthquake (7th)",
            "Transmute Metal to Wood (7th)",
        };
        private static readonly List<string> ElementalFire = new()
        {
            // "Firelight (1st)",
            "Log of Everburning (1st)-",
            "Fire Trap (2nd)",
            "Flame Blade (2nd)",
            "Heat Metal/Chill Metal (2nd)",
            "Produce Flame (2nd)",
            "Flame Walk (3rd)",
            "Protection from Fire (3rd)",
            "Pyrotechnics (3rd)",
            "Produce Fire/Quench Fire (4th)",
            // "Animate Flame (5th)",
            "Wall of Fire (5th)",
            "Conjure Fire Elemental (6th)",
            "Fire Seeds (6th)",
            "Chariot of Sustarre (7th)",
            "Fire Storm (7th)",
        };
        private static readonly List<string> ElementalWater = new()
        {
            "Create Water/Destroy Water (1st)",
            // "Watery Fist (2nd)",
            "Water Breathing/Air Breathing (3rd)",
            "Water Walk (3rd)",
            "Lower Water/Raise Water (4th)",
            "Reflecting Pool (4th)",
            // "Produce Ice (5th)",
            "Part Water (6th)",
            "Transmute Water to Dust/Improved Create Water (6th)",
            // "Conjure Water Elemental (7th)",
            //"Tsunami (7th)",
        };
        private static readonly List<string> Guardian = new()
        {
            // "Blessed Watchfulness (1st)",
            "Light/Darkness (1st)",
            "Sacred Guardian (1st)-",
            // "Iron Vigil (2nd)",
            "Silence, 15’ Radius (2nd)",
            "Wyvern Watch (2nd)",
            "Continual Light/Continual Darkness (3rd)",
            "Glyph of Warding (3rd)",
            "Abjure (4th)",
            // "Dimensional Anchor (4th)",
            "Dispel Evil/Dispel Good (5th)",
            "Unceasing Vigilance of the Holy Sentinel (5th)-",
            "Blade Barrier (6th)",
            "Forbiddance (6th)",
            "Symbol (7th)",
        };
        private static readonly List<string> Healing = new()
        {
            "Cure Light Wounds/Cause Light Wounds (1st)",
            // "Cure Moderate Wounds/Cause Moderate Wounds (2nd)",
            "Slow Poison (2nd)",
            "Cure Blindness or Deafness/Cause Blindness or Deafness (3rd)",
            "Cure Disease/Cause Disease (3rd)",
            // "Hold Poison (3rd)",
            // "Repair Injury (3rd)",
            "Cure Serious Wounds/Cause Serious Wounds (4th)",
            "Fortify* (4th)-",
            "Neutralize Poison/Poison (4th)",
            "Cure Critical Wounds/Cause Critical Wounds (5th)",
            "Heal/Harm (6th)",
            "Regenerate (7th)",
        };
        private static readonly List<string> Law = new()
        {
            "Command (1st)",
            // "Protection from Chaos (1st)",
            "Calm Chaos (2nd)-",
            "Enthrall (2nd)",
            "Hold Person (2nd)",
            // "Dictate (3rd)",
            "Rigid Thinking (3rd)-",
            "Strength of One (3rd)-",
            "Compulsive Order (4th)-",
            "Defensive Harmony (4th)-",
            "Champion’s Strength (5th)-",
            "Impeding Permission (5th)-",
            "Legal Thoughts (6th)-",
        };
        private static readonly List<string> Necromantic = new()
        {
            // "Dispel Fatigue (1st)",
            "Invisibility to Undead (1st)",
            "Aid (2nd)",
            // "Restore Strength (2nd)",
            "Animate Dead (3rd)",
            "Feign Death (3rd)",
            "Negative Plane Protection (3rd)",
            "Remove Paralysis (3rd)",
            "Speak with Dead (3rd)",
            // "Suspended Animation (4th)",
            // "Unfailing Endurance (4th)",
            "Raise Dead (5th)",
            "Restoration (7th)",
            "Resurrection (7th)",
        };
        private static readonly List<string> Numbers = new()
        {
            "Analyze Balance (1st)-",
            // "Calculate (1st)",
            "Personal Reading (1st)-",
            "Moment (2nd)-",
            "Music of the Spheres (2nd)-",
            // "Etherealness (3rd)",
            "Extradimensional Detection (3rd)-",
            "Moment Reading (3rd)-",
            "Telethaumaturgy (3rd)-",
            "Addition (4th)-",
            "Dimensional Folding (4th)-",
            "Probability Control (4th)-",
            "Consequence (5th)-",
            // "Dimensional Translocation (5th)",
            "Extradimensional Manipulation (5th)-",
            "Extradimensional Pocket (5th)-",
            "Physical Mirror (6th)-",
            "Seclusion (6th)-",
            "Spacewarp (7th)-",
            "Timelessness (7th)-",
        };
        private static readonly List<string> Plant = new()
        {
            //  = 
            "Entangle (1st)",
            "Locate Animals or Plants (1st)",
            "Pass without Trace (1st)",
            "Shillelagh (1st)",
            "Barkskin (2nd)",
            "Detect Snares & Pits (2nd)",
            "Goodberry/Badberry (2nd)",
            "Trip (2nd)",
            "Warp Wood (2nd)",
            "Plant Growth (3rd)",
            "Slow Rot (3rd)-",
            "Snare (3rd)",
            "Spike Growth (3rd)",
            "Tree (3rd)",
            "Hallucinatory Forest (4th)",
            "Hold Plant (4th)",
            "Plant Door (4th)",
            "Speak with Plants (4th)",
            "Sticks to Snakes (4th)",
            "Antiplant Shell (5th)",
            "Commune with Nature (5th)",
            "Pass Plant (5th)",
            "Liveoak (6th)",
            "Transport Via Plants (6th)",
            "Turn Wood (6th)",
            "Wall of Thorns (6th)",
            "Changestaff (7th)",
        };
        private static readonly List<string> Protection = new()
        {
            "Endure Cold/Endure Heat (1st)",
            "Protection from Evil/Protection from Good (1st)",
            "Ring of Hands/Ring of Woe* (1st)-",
            "Sanctuary (1st)",
            // "Resist Acid and Corrosion (2nd)",
            "Resist Fire/Resist Cold (2nd)",
            "Withdraw (2nd)",
            "Line of Protection/Line of Destruction (3rd)-",
            "Magical Vestment (3rd)",
            "Negative Plane Protection (3rd)",
            "Protection from Evil, 10’ Radius/Prot. from Good, 10’ Radius (3rd)",
            "Remove Paralysis (3rd)",
            "Spell Immunity (4th)",
            "Antiplant Shell (5th)",
            // "Impregnable Mind (5th)",
            "Antianimal Shell (6th)",
            // "Antimineral Shell (7th)",
            // "Impervious Sanctity of Mind (7th)",
        };
        private static readonly List<string> Summoning = new()
        {
            "Call Upon Faith (1st)-",
            "Draw Upon Holy Might (2nd)-",
            "Dust Devil (2nd)",
            "Messenger (2nd)",
            // "Summon Animal Spirit (3rd)",
            "Abjure (4th)",
            // "Dimensional Translocation (5th)",
            "Dispel Evil/Dispel Good (5th)",
            "Aerial Servant (6th)",
            "Animate Object (6th)",
            "Conjure Animals (6th)",
            "Word of Recall (6th)",
            "Exaction (7th)",
            "Mind Tracker (7th)-",
            "Spirit of Power (7th)-",
            "Succor (7th)",
        };
        private static readonly List<string> Sun = new()
        {
            "Light/Darkness (1st)",
            // "Sunscorch (1st)",
            "Continual Light/Continual Darkness (3rd)",
            "Starshine (3rd)",
            "Blessed Warmth (4th)-",
            "Moonbeam (5th)",
            "Rainbow (5th)",
            "Sol’s Searing Orb (6th)-",
            "Sunray (7th)",
        };
        private static readonly List<string> Thought = new()
        {
            "Emotion Read (1st)-",
            "Thought Capture (1st)-",
            "Idea (2nd)-",
            "Mind Read (2nd)-",
            "Emotion Control (3rd)-",
            "Memory Read (3rd)-",
            "Telepathy (3rd)-",
            "Genius (4th)-",
            "Mental Domination (4th)-",
            "Modify Memory (4th)-",
            "Rapport (4th)-",
            "Solipsism (4th)-",
            "Thought Broadcast (4th)-",
            // "Impregnable Mind (5th)",
            "Memory Wrack (5th)-",
            "Mindshatter (5th)-",
            "Thoughtwave (5th)-",
            "Disbelief (6th)-",
            "Group Mind (6th)-",
            // "Impervious Sanctity of Mind (7th)",
            "Mind Tracker (7th)-",
        };
        private static readonly List<string> Time = new()
        {
            "Know Age (1st)-",
            "Know Time (1st)-",
            "Hesitation (2nd)-",
            "Nap (2nd)-",
            "Accelerate Healing (3rd)-",
            "Choose Future (3rd)-",
            // "Unfailing Premonition (3rd)",
            "Age Plant (4th)-",
            "Body Clock (4th)-",
            "Age Object (5th)-",
            // "Othertime (5th)",
            "Repeat Action (5th)-",
            "Time Pool (5th)-",
            "Age Creature (6th)-",
            "Reverse Time (6th)-",
            "Skip Day (6th)-",
            "Age Dragon (7th)-",
        };
        private static readonly List<string> Travelers = new()
        {
            "Know Direction (1st)-",
            "Aura of Comfort (2nd)-",
            "Lighten Load (2nd)-",
            "Create Campsite (3rd)-",
            "Helping Hand (3rd)-",
            "Know Customs (3rd)-",
            "Circle of Privacy (4th)-",
            "Tree Steed (4th)-",
            "Clear Path (5th)-",
            "Easy March (5th)-",
            "Monster Mount (6th)-",
            "Hovering Road (7th)-",
        };
        private static readonly List<string> War = new()
        {
            "Courage (1st)-",
            "Morale (1st)-",
            "Emotion Perception (2nd)-",
            "Rally (2nd)-",
            "Adaptation (3rd)-",
            "Caltrops (3rd)-",
            // "Fortify (3rd)",
            // "Entrench (4th)",
            "Leadership/Doubt (4th)-",
            "Tanglefoot/Selective Passage (4th)-",
            "Disguise (5th)-",
            "Illusory Artillery (5th)-",
            "Gravity Variation (6th)-",
            "Illusory Fortification (7th)-",
            "Shadow Engine (7th)-",
        };
        private static readonly List<string> Wards = new()
        {
            "Antivermin Barrier (1st)-",
            "Weighty Chest (1st)-",
            // "Ethereal Barrier (2nd)",
            "Frisky Chest (2nd)-",
            "Zone of Truth (2nd)-",
            "Efficacious Monster Ward (3rd)-",
            "Invisibility Purge (3rd)-",
            "Squeaking Floor (3rd)-",
            "Thief’s Lament (3rd)-",
            "Zone of Sweet Air (3rd)-",
            "Fire Purge (4th)-",
            "Weather Stasis (4th)-",
            "Barrier of Retention (5th)-",
            "Elemental Forbiddance (5th)-",
            "Grounding (5th)-",
            "Shrieking Walls (5th)-",
            "Undead Ward (5th)-",
            "Crushing Walls (6th)-",
            "Dragonbane (6th)-",
            "Land of Stability (6th)-",
            "Tentacle Walls (7th)-",
        };
        private static readonly List<string> Weather = new()
        {
            "Faerie Fire (1st)",
            "Obscurement (1st)",
            "Call Lightning (3rd)",
            // "Weather Prediction (3rd)",
            "Control Temperature, 10’ Radius (4th)",
            "Protection from Lightning (4th)",
            "Weather Stasis (4th)-",
            "Control Winds (5th)",
            "Rainbow (5th)",
            "Weather Summoning (6th)",
            "Control Weather (7th)",
        };

        public static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, string>();
            UpdateDictionary(dictionary, nameof(All), All);
            UpdateDictionary(dictionary, nameof(Animal), Animal);
            UpdateDictionary(dictionary, nameof(Astral), Astral);
            UpdateDictionary(dictionary, nameof(Chaos), Chaos);
            UpdateDictionary(dictionary, nameof(Charm), Charm);
            UpdateDictionary(dictionary, nameof(Combat), Combat);
            UpdateDictionary(dictionary, nameof(Creation), Creation);
            UpdateDictionary(dictionary, nameof(Divination), Divination);
            UpdateDictionary(dictionary, "Elemental (Air)", ElementalAir);
            UpdateDictionary(dictionary, "Elemental (Earth)", ElementalEarth);
            UpdateDictionary(dictionary, "Elemental (Fire)", ElementalFire);
            UpdateDictionary(dictionary, "Elemental (Water)", ElementalWater);
            UpdateDictionary(dictionary, nameof(Guardian), Guardian);
            UpdateDictionary(dictionary, nameof(Healing), Healing);
            UpdateDictionary(dictionary, nameof(Law), Law);
            UpdateDictionary(dictionary, nameof(Necromantic), Necromantic);
            UpdateDictionary(dictionary, nameof(Numbers), Numbers);
            UpdateDictionary(dictionary, nameof(Plant), Plant);
            UpdateDictionary(dictionary, nameof(Protection), Protection);
            UpdateDictionary(dictionary, nameof(Summoning), Summoning);
            UpdateDictionary(dictionary, nameof(Sun), Sun);
            UpdateDictionary(dictionary, nameof(Thought), Thought);
            UpdateDictionary(dictionary, nameof(Time), Time);
            UpdateDictionary(dictionary, nameof(Travelers), Travelers);
            UpdateDictionary(dictionary, nameof(War), War);
            UpdateDictionary(dictionary, nameof(Wards), Wards);
            UpdateDictionary(dictionary, nameof(Weather), Weather);

            var regex = new Regex(@"\((\d)[a-z]{2}\)", RegexOptions.IgnoreCase);

            var keys = dictionary.Keys
                .OrderByDescending(s => s.EndsWith(")"))
                .ThenBy(s => regex.Match(s).Groups[1].Value)
                .ThenBy(s => s)
                .ToList();
            int i = 0;
            foreach (var key in keys)
            {
                if (i % 3 == 0)
                    Console.WriteLine("");
                var value = dictionary[key];
                Console.WriteLine($"{key.TrimEnd('-')}: {value.TrimEnd(',', ' ')}");
                i++;
            }
        }

        private static void UpdateDictionary(Dictionary<string, string> dic, string sphere, List<string> list)
        {
            foreach (var spell in list)
            {
                if (!dic.ContainsKey(spell))
                    dic.Add(spell, "");

                dic[spell] += $"{sphere}, ";
            }
        }
    }
}