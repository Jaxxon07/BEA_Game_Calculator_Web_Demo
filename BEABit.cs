using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BEAFramework
{
    /// <summary>
    /// BEA Bit - Core Emotional State Entity for Unity
    /// Behavioral Emotional Architecture (BEA) Framework
    /// © 2025 Jeremy F. Jackson. All Rights Reserved. Beat⊕k™
    /// </summary>
    [System.Serializable]
    public class BEABit
    {
        [Header("Core Properties")]
        public int id;
        public string name;
        public string symbol;
        public Color color;
        public string description;
        
        [Header("Dynamic Properties")]
        [Range(0f, 255f)]
        public float level = 128f;
        public List<string> tags = new List<string>();
        [Range(0f, 1f)]
        public float decayRate = 0.01f;
        
        [Header("Interaction Properties")]
        public Dictionary<string, float> interactionWeights = new Dictionary<string, float>();
        
        private DateTime timestamp;

        public BEABit(int id, string name, string symbol, Color color, string description, 
                     float level = 128f, List<string> tags = null, float decayRate = 0.01f)
        {
            this.id = id;
            this.name = name;
            this.symbol = symbol;
            this.color = color;
            this.description = description;
            this.level = level;
            this.tags = tags ?? new List<string>();
            this.decayRate = decayRate;
            this.timestamp = DateTime.Now;
        }

        /// <summary>
        /// Get normalized intensity level (0.0 to 1.0)
        /// </summary>
        public float GetNormalizedLevel()
        {
            return level / 255f;
        }

        /// <summary>
        /// Apply natural decay over time
        /// </summary>
        public void Decay(float deltaTime = 1f)
        {
            level = Mathf.Max(0f, level - (decayRate * deltaTime * 255f));
        }

        /// <summary>
        /// Clone this BEABit
        /// </summary>
        public BEABit Clone()
        {
            var clone = new BEABit(id, name, symbol, color, description, level, 
                                  new List<string>(tags), decayRate);
            clone.interactionWeights = new Dictionary<string, float>(interactionWeights);
            return clone;
        }

        /// <summary>
        /// Merge properties from another BEABit
        /// </summary>
        public BEABit Merge(BEABit other, float weight = 0.5f)
        {
            float newLevel = Mathf.Min(255f, (level * (1f - weight)) + (other.level * weight));
            Color newColor = Color.Lerp(color, other.color, weight);
            var newTags = new List<string>(tags);
            newTags.AddRange(other.tags);
            newTags = newTags.Distinct().ToList();

            var merged = new BEABit(
                Mathf.RoundToInt((id + other.id) / 2f),
                $"{name}+{other.name}",
                symbol + other.symbol,
                newColor,
                $"Merged state: {description} combined with {other.description}",
                newLevel,
                newTags,
                (decayRate + other.decayRate) / 2f
            );

            return merged;
        }

        public override string ToString()
        {
            return $"{symbol} E[{id}] {name} (Level: {level:F0})";
        }
    }

    /// <summary>
    /// BEA Calculator - Core calculation engine for Unity
    /// </summary>
    public static class BEACalculator
    {
        /// <summary>
        /// Combine two emotional states using specified operator
        /// </summary>
        public static BEABit CombineStates(BEABit stateA, BEABit stateB, string operatorSymbol)
        {
            switch (operatorSymbol)
            {
                case "⊕": return Combust(stateA, stateB);
                case "⊖": return Balance(stateA, stateB);
                case "⨀": return Amplify(stateA, stateB);
                case "⦸": return Dissolve(stateA, stateB);
                default:
                    Debug.LogError($"Unknown operator: {operatorSymbol}");
                    return stateA;
            }
        }

        /// <summary>
        /// Combust (⊕) - Creates ignition and potential using pure BEA 1+1=3 mathematics
        /// </summary>
        private static BEABit Combust(BEABit stateA, BEABit stateB)
        {
            int baseId = (stateA.id + stateB.id) % 32; // Pure BEA modulo arithmetic - 1+1=3 principle
            float energyLevel = Mathf.Min(255f, stateA.level + stateB.level);

            // Blend colors with increased saturation
            Color newColor = Color.Lerp(stateA.color, stateB.color, 0.5f);
            newColor = Color.Lerp(newColor, Color.white, 0.2f); // Increase brightness

            var combinedTags = new List<string>(stateA.tags);
            combinedTags.AddRange(stateB.tags);
            combinedTags.AddRange(new[] { "ignited", "combusted" });
            combinedTags = combinedTags.Distinct().ToList();

            return new BEABit(
                baseId,
                $"Ignited {stateA.name}-{stateB.name}",
                stateA.symbol + "🔥" + stateB.symbol,
                newColor,
                $"Ignited fusion of {stateA.name} and {stateB.name}",
                energyLevel,
                combinedTags,
                Mathf.Max(stateA.decayRate, stateB.decayRate) * 0.8f
            );
        }

        /// <summary>
        /// Balance (⊖) - Creates equilibrium and stability using BEA mathematical averaging
        /// </summary>
        private static BEABit Balance(BEABit stateA, BEABit stateB)
        {
            int balancedId = Mathf.FloorToInt((stateA.id + stateB.id) / 2f); // Matches web version formula
            float balancedLevel = (stateA.level + stateB.level) / 2f;

            Color newColor = Color.Lerp(stateA.color, stateB.color, 0.5f);

            var balancedTags = new List<string>(stateA.tags);
            balancedTags.AddRange(stateB.tags);
            balancedTags.AddRange(new[] { "balanced", "harmonized" });
            balancedTags = balancedTags.Distinct().ToList();

            return new BEABit(
                balancedId,
                $"Balanced {stateA.name}-{stateB.name}",
                stateA.symbol + "⚖️" + stateB.symbol,
                newColor,
                $"Balanced harmony of {stateA.name} and {stateB.name}",
                balancedLevel,
                balancedTags,
                (stateA.decayRate + stateB.decayRate) / 2f * 0.7f
            );
        }

        /// <summary>
        /// Amplify (⨀) - Intensifies and magnifies emotions using BEA mathematics
        /// </summary>
        private static BEABit Amplify(BEABit stateA, BEABit stateB)
        {
            // Use BEA formula: Math.min(Math.max(state1.id, state2.id) + 2, 31)
            int amplifiedId = Mathf.Min(Mathf.Max(stateA.id, stateB.id) + 2, 31);
            float amplifiedLevel = Mathf.Min(255f, Mathf.Max(stateA.level, stateB.level) * 1.3f);

            // Use the state with higher ID as the dominant one
            BEABit dominantState = stateA.id >= stateB.id ? stateA : stateB;
            
            // Intensify the dominant color
            Color newColor = dominantState.color;
            newColor.r = Mathf.Min(1f, newColor.r * 1.4f);
            newColor.g = Mathf.Min(1f, newColor.g * 1.4f);
            newColor.b = Mathf.Min(1f, newColor.b * 1.4f);

            var amplifiedTags = new List<string>(stateA.tags);
            amplifiedTags.AddRange(stateB.tags);
            amplifiedTags.AddRange(new[] { "amplified", "intensified" });
            amplifiedTags = amplifiedTags.Distinct().ToList();

            return new BEABit(
                amplifiedId,
                $"Amplified {dominantState.name}",
                "📈" + dominantState.symbol,
                newColor,
                $"Amplified {dominantState.name} enhanced by {stateA.name}-{stateB.name}",
                amplifiedLevel,
                amplifiedTags,
                Mathf.Max(stateA.decayRate, stateB.decayRate) * 1.2f
            );
        }

        /// <summary>
        /// Dissolve (⦸) - Weakens and neutralizes emotions using BEA mathematics
        /// </summary>
        private static BEABit Dissolve(BEABit stateA, BEABit stateB)
        {
            // Use BEA formula: Math.max(Math.min(state1.id, state2.id) - 1, 0)
            int dissolvedId = Mathf.Max(0, Mathf.Min(stateA.id, stateB.id) - 1);
            float dissolvedLevel = Mathf.Max(16f, Mathf.Min(stateA.level, stateB.level) * 0.6f);

            // Move colors toward neutral gray
            Color newColor = Color.Lerp(stateA.color, stateB.color, 0.5f);
            newColor = Color.Lerp(newColor, Color.gray, 0.3f);

            var dissolvedTags = new List<string>(stateA.tags);
            dissolvedTags.AddRange(stateB.tags);
            dissolvedTags.AddRange(new[] { "dissolved", "neutralized" });
            dissolvedTags = dissolvedTags.Distinct().ToList();

            return new BEABit(
                dissolvedId,
                $"Dissolved {stateA.name}-{stateB.name}",
                "💨" + stateA.symbol + stateB.symbol,
                newColor,
                $"Dissolved interaction of {stateA.name} and {stateB.name}",
                dissolvedLevel,
                dissolvedTags,
                Mathf.Min(stateA.decayRate, stateB.decayRate) * 0.5f
            );
        }

        /// <summary>
        /// Get operator description - Pure BEA 1+1=3 mathematical approach
        /// </summary>
        public static string GetOperatorDescription(string operatorSymbol)
        {
            switch (operatorSymbol)
            {
                case "⊕": return "Combust: Pure BEA modulo arithmetic - creates emergent outcomes through (a+b) % 32";
                case "⊖": return "Balance: Mathematical equilibrium through averaging - (a+b) / 2";
                case "⨀": return "Amplify: Intensifies through max + 2 formula - max(a,b) + 2";
                case "⦸": return "Dissolve: Reduces through min - 1 formula - max(min(a,b) - 1, 0)";
                default: return "Unknown operator";
            }
        }

        /// <summary>
        /// Get all available operators
        /// </summary>
        public static string[] GetAllOperators()
        {
            return new[] { "⊕", "⊖", "⨀", "⦸" };
        }
    }

    /// <summary>
    /// Predefined emotional states for BEA framework
    /// </summary>
    public static class BEAStates
    {
        public static readonly BEABit[] AllStates = {
            // Baseline
            new BEABit(0, "Neutral", "😐", new Color(0.5f, 0.5f, 0.5f), "Balanced equilibrium, no emotional charge"),
            
            // Cognitive
            new BEABit(1, "Curiosity", "🤔", new Color(0f, 0.39f, 1f), "Initial exploration, seeking understanding"),
            new BEABit(3, "Interest", "🧐", new Color(1f, 0.55f, 0f), "Focused attention and engagement"),
            new BEABit(8, "Confusion", "🤯", new Color(1f, 0.08f, 0.58f), "Uncertainty and lack of clarity"),
            new BEABit(17, "Contemplation", "🧘‍♂️", new Color(0.44f, 0.5f, 0.56f), "Deep reflective thinking"),
            new BEABit(19, "Clarity", "💡", new Color(1f, 0.84f, 0f), "Clear understanding and insight"),
            
            // Peaceful
            new BEABit(2, "Calmness", "😊", new Color(0f, 0.78f, 0.39f), "Balance and receptive awareness"),
            new BEABit(14, "Relief", "😌", new Color(0.69f, 0.88f, 0.9f), "Release from tension or worry"),
            new BEABit(18, "Serenity", "🕊️", new Color(0.69f, 0.88f, 0.9f), "Perfect peace and tranquility"),
            new BEABit(24, "Harmony", "☯️", new Color(0.94f, 0.97f, 1f), "Perfect balance and alignment"),
            new BEABit(31, "Peace", "☮️", new Color(1f, 1f, 1f), "Ultimate tranquility and acceptance"),
            
            // Energetic
            new BEABit(4, "Excitement", "🎉", new Color(1f, 0.55f, 0f), "Intensified potential, driving force"),
            new BEABit(27, "Inspiration", "🎨", new Color(1f, 1f, 0.88f), "Creative spark, motivating vision"),
            
            // Empowered
            new BEABit(5, "Strength", "💪", new Color(0.71f, 0f, 0f), "Confidence in action and direction"),
            new BEABit(15, "Valor", "🛡️", new Color(0.55f, 0f, 0f), "Courage in action, brave determination"),
            new BEABit(22, "Resolve", "⚔️", new Color(0.27f, 0.51f, 0.71f), "Determined commitment to action"),
            new BEABit(26, "Confidence", "👑", new Color(1f, 0.84f, 0f), "Self-assured certainty in abilities"),
            
            // Transcendent
            new BEABit(6, "Wonder", "✨", new Color(1f, 0.84f, 0f), "Awe-inspiring realization, profound insight"),
            new BEABit(16, "Bliss", "🌟", new Color(1f, 1f, 0f), "Peak happiness, transcendent joy"),
            new BEABit(20, "Enlightenment", "🌅", new Color(1f, 1f, 0.88f), "Profound understanding, wisdom achieved"),
            new BEABit(21, "Transcendence", "🔮", new Color(0.28f, 0.24f, 0.55f), "Beyond ordinary experience, unity"),
            
            // Positive
            new BEABit(7, "Joy", "😄", new Color(1f, 0.75f, 0.8f), "Pure happiness and contentment"),
            new BEABit(28, "Gratitude", "🙏", new Color(0.94f, 0.97f, 1f), "Appreciation and thankfulness"),
            new BEABit(29, "Hope", "🌱", new Color(1f, 1f, 0f), "Optimistic expectation for the future"),
            
            // Connected
            new BEABit(25, "Empathy", "🤗", new Color(1f, 0.41f, 0.71f), "Deep understanding of others emotions"),
            new BEABit(30, "Love", "❤️", new Color(0.86f, 0.08f, 0.24f), "Deep affection and connection"),
            
            // Melancholic
            new BEABit(9, "Sadness", "😢", new Color(0.27f, 0.51f, 0.71f), "Acknowledgment of loss or unmet expectation"),
            new BEABit(12, "Melancholy", "🌧️", new Color(0.44f, 0.5f, 0.56f), "Bittersweet reflection, thoughtful sadness"),
            
            // Intense
            new BEABit(10, "Anger", "😡", new Color(0.86f, 0.08f, 0.24f), "Frustration, drive for resolution"),
            new BEABit(23, "Passion", "🌹", new Color(0.86f, 0.08f, 0.24f), "Intense enthusiasm and drive"),
            
            // Protective
            new BEABit(11, "Fear", "😰", new Color(0.54f, 0.17f, 0.89f), "Alert awareness of potential threat"),
            
            // Tense
            new BEABit(13, "Anxiety", "😵", new Color(1f, 0.65f, 0f), "Worried anticipation, nervous energy")
        };
        
        // Legacy compatibility - foundational states
        public static readonly BEABit[] FoundationalStates = {
            GetStateById(0), GetStateById(1), GetStateById(2), GetStateById(3), 
            GetStateById(4), GetStateById(5), GetStateById(6), GetStateById(7)
        };

        public static BEABit GetStateById(int id)
        {
            return AllStates.FirstOrDefault(s => s.id == id)?.Clone();
        }

        public static BEABit[] GetAllStates()
        {
            return AllStates.Select(s => s.Clone()).ToArray();
        }
    }
}