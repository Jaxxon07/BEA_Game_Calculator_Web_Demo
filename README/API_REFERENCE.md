# BEA Framework API Reference

## Emotional State System

### Complete 32-State Mapping

The BEA framework implements a comprehensive emotional spectrum with 32 distinct states:

| ID | Name | Symbol | Category | Intensity | Description |
|----|------|--------|----------|-----------|-------------|
| 0 | Neutral | 😐 | baseline | 0 | Balanced equilibrium, no emotional charge |
| 1 | Curiosity | 🤔 | cognitive | 3 | Initial exploration, seeking understanding |
| 2 | Calmness | 😊 | peaceful | 2 | Balance and receptive awareness |
| 3 | Interest | 🧐 | cognitive | 4 | Focused attention and engagement |
| 4 | Excitement | 🎉 | energetic | 6 | High energy enthusiasm |
| 5 | Strength | 💪 | empowered | 5 | Physical and emotional power |
| 6 | Wonder | ✨ | transcendent | 7 | Awe-inspiring realization, profound insight |
| 7 | Joy | 😄 | positive | 8 | Pure happiness and contentment |
| 8 | Confusion | 🤯 | cognitive | 3 | Uncertainty and lack of clarity |
| 9 | Sadness | 😢 | melancholic | 5 | Acknowledgment of loss or unmet expectation |
| 10 | Anger | 😡 | intense | 7 | Frustration, drive for resolution |
| 11 | Fear | 😨 | protective | 6 | Alert awareness of potential threat |
| 12 | Melancholy | 🌧️ | melancholic | 4 | Bittersweet reflection, thoughtful sadness |
| 13 | Anxiety | 😵‍💫 | tense | 5 | Worried anticipation, nervous energy |
| 14 | Relief | 😌 | peaceful | 3 | Release from tension or worry |
| 15 | Valor | 🛡️ | empowered | 8 | Courage in action, brave determination |
| 16 | Bliss | 🌟 | transcendent | 9 | Peak happiness, transcendent joy |
| 17 | Contemplation | 🧘‍♂️ | cognitive | 4 | Deep reflective thinking |
| 18 | Serenity | 🕊️ | peaceful | 6 | Perfect peace and tranquility |
| 19 | Clarity | 💡 | cognitive | 5 | Clear understanding and insight |
| 20 | Enlightenment | 🌅 | transcendent | 10 | Profound understanding, wisdom achieved |
| 21 | Transcendence | 🔮 | transcendent | 10 | Beyond ordinary experience, unity |
| 22 | Resolve | ⚔️ | empowered | 6 | Determined commitment to action |
| 23 | Passion | 🌹 | intense | 9 | Intense enthusiasm and drive |
| 24 | Harmony | ☯️ | peaceful | 7 | Perfect balance and alignment |
| 25 | Empathy | 🤗 | connected | 5 | Deep understanding of others' emotions |
| 26 | Confidence | 👑 | empowered | 6 | Self-assured certainty in abilities |
| 27 | Inspiration | 🎨 | energetic | 7 | Creative spark, motivating vision |
| 28 | Gratitude | 🙏 | positive | 5 | Appreciation and thankfulness |
| 29 | Hope | 🌱 | positive | 4 | Optimistic expectation for the future |
| 30 | Love | ❤️ | connected | 8 | Deep affection and connection |
| 31 | Peace | ☮️ | peaceful | 8 | Ultimate tranquility and acceptance |

### Emotional Categories

#### Cognitive States (5 states)
States involving thinking, understanding, and mental processing.
- **E[1] Curiosity**, **E[3] Interest**, **E[8] Confusion**, **E[17] Contemplation**, **E[19] Clarity**

#### Peaceful States (5 states)
Calm, tranquil emotions that promote balance and harmony.
- **E[2] Calmness**, **E[14] Relief**, **E[18] Serenity**, **E[24] Harmony**, **E[31] Peace**

#### Transcendent States (4 states)
Peak emotional experiences that go beyond ordinary human experience.
- **E[6] Wonder**, **E[16] Bliss**, **E[20] Enlightenment**, **E[21] Transcendence**

#### Empowered States (4 states)
Emotions associated with personal power, courage, and determination.
- **E[5] Strength**, **E[15] Valor**, **E[22] Resolve**, **E[26] Confidence**

#### Positive States (3 states)
Uplifting emotions that create well-being and optimism.
- **E[7] Joy**, **E[28] Gratitude**, **E[29] Hope**

#### Energetic States (2 states)
Dynamic emotions that create movement and motivation.
- **E[4] Excitement**, **E[27] Inspiration**

#### Connected States (2 states)
Emotions that link us to others and create interpersonal bonds.
- **E[25] Empathy**, **E[30] Love**

#### Melancholic States (2 states)
Reflective, sorrowful emotions that acknowledge loss and difficulty.
- **E[9] Sadness**, **E[12] Melancholy**

#### Intense States (2 states)
High-energy emotions that can be overwhelming in their power.
- **E[10] Anger**, **E[23] Passion**

#### Protective States (1 state)
- **E[11] Fear**: Alert awareness that keeps us safe from threats

#### Tense States (1 state)
- **E[13] Anxiety**: Worried anticipation and nervous energy

### Intensity Levels

- **Low (0-3)**: Subtle, foundational emotions
- **Medium (4-6)**: Reactive, interactive emotions  
- **High (7-9)**: Intense, overwhelming emotions
- **Peak (10)**: Transcendent, transformative emotions

## Core Classes

### BEABit

The fundamental emotional state entity in the BEA framework.

#### Properties

```csharp
public int id                                    // Unique identifier (0-31)
public string name                               // Human-readable name
public string symbol                             // Unicode symbol representation
public Color color                               // Visual representation color
public string description                        // Detailed description
public float level                               // Intensity level (0-255)
public List<string> tags                         // Categorization tags
public float decayRate                           // Natural degradation rate
public Dictionary<string, float> interactionWeights // Cross-state influence weights
```

#### Methods

```csharp
// Get normalized intensity (0.0 to 1.0)
public float GetNormalizedLevel()

// Create a deep copy of the BEABit
public BEABit Clone()

// Apply decay over time
public void ApplyDecay(float deltaTime)

// Check if state has specific tag
public bool HasTag(string tag)
```

#### Constructors

```csharp
public BEABit(int id, string name, string symbol, Color color, 
              string description, float level = 128f, 
              List<string> tags = null, float decayRate = 0.01f)
```

### BEAGrid

Main grid system for emotional state processing and cellular automata simulation.

#### Properties

```csharp
[SerializeField] private int width              // Grid width (default: 32)
[SerializeField] private int height             // Grid height (default: 32)
[SerializeField] private bool wrappedGrid       // Enable edge wrapping
[SerializeField] private ComputeShader gridComputeShader // GPU acceleration
[SerializeField] private int sparksPerFrameLimit // Performance limit
[SerializeField] private int decayRate          // Global decay speed
[SerializeField] private float updateInterval   // Simulation speed
[SerializeField] private bool autoUpdate        // Automatic updates
[SerializeField] private Material gridMaterial  // Visualization material
[SerializeField] private bool showDebugView     // Debug overlay
```

#### Methods

```csharp
// Initialize the grid system
public void Initialize()

// Start the simulation
public void StartSimulation()

// Stop the simulation
public void StopSimulation()

// Reset grid to initial state
public void ResetGrid()

// Set state at specific grid position
public void SetStateAt(int x, int y, BEABit state)

// Get state at specific grid position
public BEABit GetStateAt(int x, int y)

// Inject random spark at position
public void InjectSpark(int x, int y, BEABit state)

// Update single simulation step
public void UpdateStep()

// Get grid dimensions
public Vector2Int GetGridSize()

// Check if position is valid
public bool IsValidPosition(int x, int y)
```

#### Events

```csharp
public event Action<BEABit> OnStateChanged       // Global state change
public event Action<Vector2Int, BEABit> OnCellChanged // Specific cell change
public event Action<float> OnPerformanceUpdate  // Performance metrics
```

### BEAController

Central coordination system for the BEA framework.

#### Methods

```csharp
// Initialize all systems
public void InitializeSystems()

// Shutdown all systems
public void ShutdownSystems()

// Get current system status
public SystemStatus GetSystemStatus()

// Register event listeners
public void RegisterListeners()

// Unregister event listeners
public void UnregisterListeners()
```

### BEACalculator

Static utility class for emotional state mathematics implementing the BEA framework's unique computational principles.

#### Mathematical Operations

The BEA Calculator implements four core mathematical operations for emotional state transformation:

##### Combust Operation (⊕) - "1+1=3 Principle"
Creates emergent properties through emotional fusion. This operation demonstrates the BEA framework's core principle that emotional combinations can produce results greater than their sum.

##### Balance Operation (⊖) - Equilibrium Seeking
Seeks harmony and stability between two emotional states, often resulting in peaceful or centered emotions.

##### Dissolve Operation (⊗) - State Degradation
Breaks down complex emotional states into simpler components or causes transformation through reduction.

##### Amplify Operation (⨀) - Intensification
Intensifies the stronger emotional state through enhancement and addition.

#### Methods

```csharp
// Combine two emotional states using specified operator
public static BEABit CombineStates(BEABit stateA, BEABit stateB, string operatorSymbol)

// Combust operation (⊕) - 1+1=3 principle  
private static BEABit Combust(BEABit stateA, BEABit stateB)

// Balance operation (⊖) - Equilibrium seeking
private static BEABit Balance(BEABit stateA, BEABit stateB)

// Dissolve operation (⊗) - State degradation
private static BEABit Dissolve(BEABit stateA, BEABit stateB)

// Amplify operation (⨀) - Intensification
private static BEABit Amplify(BEABit stateA, BEABit stateB)

// Calculate emotional distance between states
public static float CalculateDistance(BEABit stateA, BEABit stateB)

// Calculate interaction weight between two emotional categories
public static float GetCategoryInteractionWeight(string categoryA, string categoryB)

// Normalize value to specified range
public static float NormalizeValue(float value, float min, float max)

// Apply intensity modifier based on state category
public static float ApplyIntensityModifier(BEABit state, float baseValue)

// Check state compatibility for operations
public static bool AreStatesCompatible(BEABit stateA, BEABit stateB)
```

#### Example BEA Calculations

```csharp
// Demonstrating the 1+1=3 principle
var curiosity = EmotionalStates.GetState(1);    // E[1] Curiosity (intensity: 3)
var bliss = EmotionalStates.GetState(16);       // E[16] Bliss (intensity: 9)
var result = BEACalculator.CombineStates(curiosity, bliss, "⊕");
// Result: E[27] Inspiration (intensity: 7) - emergent creative spark

// Balance operation for harmony
var anger = EmotionalStates.GetState(10);       // E[10] Anger (intensity: 7)
var passion = EmotionalStates.GetState(23);     // E[23] Passion (intensity: 9)
var balanced = BEACalculator.CombineStates(anger, passion, "⊖");
// Result: E[18] Serenity (intensity: 6) - transformative balance

// Dissolve operation for simplification
var anxiety = EmotionalStates.GetState(13);     // E[13] Anxiety (intensity: 5)
var calmness = EmotionalStates.GetState(2);     // E[2] Calmness (intensity: 2)
var dissolved = BEACalculator.CombineStates(anxiety, calmness, "⊗");
// Result: E[14] Relief (intensity: 3) - tension release

// Amplification for enhancement
var peace = EmotionalStates.GetState(31);       // E[31] Peace (intensity: 8)
var neutral = EmotionalStates.GetState(0);      // E[0] Neutral (intensity: 0)
var amplified = BEACalculator.CombineStates(peace, neutral, "⨀");
// Result: Enhanced peaceful state with greater intensity
```

### Interfaces

#### ICalculationService

```csharp
public interface ICalculationService
{
    BEABit ProcessCalculation(BEABit input);
    void InitializeService();
    bool IsServiceReady();
}
```

## Enumerations

### SystemStatus

```csharp
public enum SystemStatus
{
    Uninitialized,
    Initializing,
    Ready,
    Running,
    Paused,
    Error,
    Shutdown
}
```

### BEAOperator

```csharp
public enum BEAOperator
{
    Combust,    // ⊕
    Balance,    // ⊖
    Dissolve,   // ⊗
    Amplify     // ⨀
}
```

## Advanced Usage Examples

### Complete Emotional State Initialization

```csharp
// Initialize the complete 32-state emotional system
public class EmotionalStateManager : MonoBehaviour
{
    private Dictionary<int, BEABit> emotionalStates;
    
    void Start()
    {
        InitializeEmotionalStates();
    }
    
    private void InitializeEmotionalStates()
    {
        emotionalStates = new Dictionary<int, BEABit>();
        
        // Initialize all 32 states with proper categorization
        emotionalStates[0] = new BEABit(0, "Neutral", "😐", Color.gray, "Balanced equilibrium");
        emotionalStates[1] = new BEABit(1, "Curiosity", "🤔", Color.yellow, "Seeking understanding", 128f, new List<string>{"cognitive"});
        emotionalStates[2] = new BEABit(2, "Calmness", "😊", Color.blue, "Peaceful awareness", 128f, new List<string>{"peaceful"});
        emotionalStates[16] = new BEABit(16, "Bliss", "🌟", Color.white, "Transcendent joy", 230f, new List<string>{"transcendent"});
        emotionalStates[31] = new BEABit(31, "Peace", "☮️", Color.green, "Ultimate tranquility", 200f, new List<string>{"peaceful"});
        
        // Configure interaction weights for cross-emotional influence
        ConfigureInteractionWeights();
    }
    
    private void ConfigureInteractionWeights()
    {
        // Cognitive states enhance each other
        emotionalStates[1].interactionWeights["cognitive"] = 1.2f;
        emotionalStates[3].interactionWeights["cognitive"] = 1.3f;
        
        // Peaceful states create stability
        emotionalStates[2].interactionWeights["peaceful"] = 1.1f;
        emotionalStates[31].interactionWeights["peaceful"] = 1.5f;
        
        // Transcendent states transform others
        emotionalStates[16].interactionWeights["transcendent"] = 2.0f;
        emotionalStates[20].interactionWeights["transcendent"] = 2.5f;
    }
}
```

### Advanced Grid Operations with Emotional Categories

```csharp
public class AdvancedBEAGrid : MonoBehaviour
{
    private BEAGrid grid;
    private Dictionary<string, List<BEABit>> categorizedStates;
    
    void Start()
    {
        grid = GetComponent<BEAGrid>();
        grid.Initialize();
        
        CategorizeEmotionalStates();
        SetupAdvancedPatterns();
    }
    
    private void CategorizeEmotionalStates()
    {
        categorizedStates = new Dictionary<string, List<BEABit>>
        {
            ["cognitive"] = new List<BEABit>(),
            ["peaceful"] = new List<BEABit>(),
            ["transcendent"] = new List<BEABit>(),
            ["empowered"] = new List<BEABit>(),
            ["intense"] = new List<BEABit>()
        };
        
        // Populate categories based on emotional state mapping
        // This allows for category-based operations and patterns
    }
    
    private void SetupAdvancedPatterns()
    {
        // Create spiral pattern of increasing transcendent states
        CreateTranscendentSpiral();
        
        // Establish peaceful borders for containment
        CreatePeacefulBoundaries();
        
        // Add cognitive catalyst points
        InjectCognitiveCatalysts();
    }
    
    private void CreateTranscendentSpiral()
    {
        Vector2Int center = new Vector2Int(16, 16);
        float angle = 0f;
        float radius = 2f;
        
        var transcendentStates = new int[] { 6, 16, 20, 21 }; // Wonder, Bliss, Enlightenment, Transcendence
        
        for (int i = 0; i < transcendentStates.Length; i++)
        {
            int x = center.x + Mathf.RoundToInt(radius * Mathf.Cos(angle));
            int y = center.y + Mathf.RoundToInt(radius * Mathf.Sin(angle));
            
            var state = EmotionalStates.GetState(transcendentStates[i]);
            grid.SetStateAt(x, y, state);
            
            angle += Mathf.PI / 2f; // 90-degree increments
            radius += 1f;
        }
    }
}
```

### Complex Emotional State Combinations

```csharp
public class EmotionalAlchemist : MonoBehaviour
{
    // Demonstrates advanced BEA mathematical operations
    
    public BEABit CreateEmotionalFormula(string formula)
    {
        // Parse and execute complex emotional formulas
        // Example: "(E[1] ⊕ E[16]) ⊖ E[31] = ?"
        
        switch (formula)
        {
            case "inspiration_genesis":
                return CreateInspirationGenesis();
            case "transcendent_balance":
                return CreateTranscendentBalance();
            case "emotional_catalyst":
                return CreateEmotionalCatalyst();
            default:
                return EmotionalStates.GetState(0); // Return neutral
        }
    }
    
    private BEABit CreateInspirationGenesis()
    {
        // Complex formula: (Curiosity ⊕ Wonder) ⊕ (Joy ⊖ Passion) = Creative Inspiration
        var curiosity = EmotionalStates.GetState(1);   // E[1] Curiosity
        var wonder = EmotionalStates.GetState(6);       // E[6] Wonder
        var joy = EmotionalStates.GetState(7);          // E[7] Joy
        var passion = EmotionalStates.GetState(23);     // E[23] Passion
        
        // First combination: Curiosity ⊕ Wonder = Enhanced Wonder
        var enhancedWonder = BEACalculator.CombineStates(curiosity, wonder, "⊕");
        
        // Second combination: Joy ⊖ Passion = Balanced Enthusiasm
        var balancedEnthusiasm = BEACalculator.CombineStates(joy, passion, "⊖");
        
        // Final combination: Enhanced Wonder ⊕ Balanced Enthusiasm = Pure Inspiration
        var pureInspiration = BEACalculator.CombineStates(enhancedWonder, balancedEnthusiasm, "⊕");
        
        return pureInspiration;
    }
    
    private BEABit CreateTranscendentBalance()
    {
        // Formula: (Enlightenment ⊖ Peace) ⊗ Neutral = Transcendent Clarity
        var enlightenment = EmotionalStates.GetState(20); // E[20] Enlightenment
        var peace = EmotionalStates.GetState(31);         // E[31] Peace
        var neutral = EmotionalStates.GetState(0);        // E[0] Neutral
        
        var balancedWisdom = BEACalculator.CombineStates(enlightenment, peace, "⊖");
        var transcendentClarity = BEACalculator.CombineStates(balancedWisdom, neutral, "⊗");
        
        return transcendentClarity;
    }
}
```

### Emotional State Monitoring and Analytics

```csharp
public class EmotionalAnalytics : MonoBehaviour
{
    private Dictionary<string, float> categoryMetrics;
    private Queue<BEABit> emotionalHistory;
    private const int HISTORY_SIZE = 100;
    
    void Start()
    {
        categoryMetrics = new Dictionary<string, float>();
        emotionalHistory = new Queue<BEABit>();
        
        // Subscribe to grid events for real-time analysis
        var grid = FindObjectOfType<BEAGrid>();
        if (grid != null)
        {
            grid.OnCellChanged += AnalyzeEmotionalChange;
            grid.OnPerformanceUpdate += UpdatePerformanceMetrics;
        }
    }
    
    private void AnalyzeEmotionalChange(Vector2Int position, BEABit newState)
    {
        // Track emotional state transitions
        RecordEmotionalTransition(newState);
        
        // Update category metrics
        UpdateCategoryMetrics(newState);
        
        // Detect emotional patterns
        DetectEmotionalPatterns();
        
        // Generate insights
        GenerateEmotionalInsights();
    }
    
    private void RecordEmotionalTransition(BEABit state)
    {
        emotionalHistory.Enqueue(state);
        
        if (emotionalHistory.Count > HISTORY_SIZE)
        {
            emotionalHistory.Dequeue();
        }
    }
    
    private void DetectEmotionalPatterns()
    {
        if (emotionalHistory.Count < 10) return;
        
        var recentStates = emotionalHistory.TakeLast(10).ToArray();
        
        // Detect emotional escalation patterns
        if (IsEscalatingPattern(recentStates))
        {
            Debug.Log("Emotional escalation detected!");
            TriggerStabilizationProtocol();
        }
        
        // Detect transcendent emergence patterns
        if (IsTranscendentPattern(recentStates))
        {
            Debug.Log("Transcendent emergence detected!");
            EnhanceTranscendentStates();
        }
    }
    
    private bool IsEscalatingPattern(BEABit[] states)
    {
        // Check for increasing intensity levels
        for (int i = 1; i < states.Length; i++)
        {
            if (states[i].level <= states[i-1].level)
                return false;
        }
        return true;
    }
    
    private void TriggerStabilizationProtocol()
    {
        // Inject peaceful states to balance intense emotions
        var grid = FindObjectOfType<BEAGrid>();
        var peacefulStates = new int[] { 2, 14, 18, 24, 31 }; // Calmness, Relief, Serenity, Harmony, Peace
        
        for (int i = 0; i < 5; i++)
        {
            int x = Random.Range(0, grid.GetGridSize().x);
            int y = Random.Range(0, grid.GetGridSize().y);
            var state = EmotionalStates.GetState(peacefulStates[Random.Range(0, peacefulStates.Length)]);
            grid.InjectSpark(x, y, state);
        }
    }
}
```

### Event Handling

```csharp
public class EmotionalObserver : MonoBehaviour
{
    private BEAGrid grid;
    
    void Start()
    {
        grid = FindObjectOfType<BEAGrid>();
        
        // Subscribe to events
        grid.OnCellChanged += HandleCellChanged;
        grid.OnPerformanceUpdate += HandlePerformanceUpdate;
    }
    
    private void HandleCellChanged(Vector2Int position, BEABit newState)
    {
        Debug.Log($"Cell at {position} changed to {newState.name}");
    }
    
    private void HandlePerformanceUpdate(float fps)
    {
        Debug.Log($"Current FPS: {fps}");
    }
}
```

### Custom Rule Implementation

```csharp
public class CustomEmotionalRule : IBEARule
{
    public float Priority => 1.0f;
    
    public bool IsApplicable(BEABit state)
    {
        return state.level > 200f; // Apply to high-intensity states
    }
    
    public BEABit ApplyRule(BEABit current, BEABit[] neighbors)
    {
        // Custom logic for state transformation
        var newState = current.Clone();
        newState.level *= 0.9f; // Reduce intensity
        return newState;
    }
}
```

## Constants

### Emotional State IDs

```csharp
public static class EmotionalStateIds
{
    // Baseline
    public const int NEUTRAL = 0;
    
    // Cognitive States (5 states)
    public const int CURIOSITY = 1;
    public const int INTEREST = 3;
    public const int CONFUSION = 8;
    public const int CONTEMPLATION = 17;
    public const int CLARITY = 19;
    
    // Peaceful States (5 states)
    public const int CALMNESS = 2;
    public const int RELIEF = 14;
    public const int SERENITY = 18;
    public const int HARMONY = 24;
    public const int PEACE = 31;
    
    // Energetic States (2 states)
    public const int EXCITEMENT = 4;
    public const int INSPIRATION = 27;
    
    // Empowered States (4 states)
    public const int STRENGTH = 5;
    public const int VALOR = 15;
    public const int RESOLVE = 22;
    public const int CONFIDENCE = 26;
    
    // Transcendent States (4 states)
    public const int WONDER = 6;
    public const int BLISS = 16;
    public const int ENLIGHTENMENT = 20;
    public const int TRANSCENDENCE = 21;
    
    // Positive States (3 states)
    public const int JOY = 7;
    public const int GRATITUDE = 28;
    public const int HOPE = 29;
    
    // Connected States (2 states)
    public const int EMPATHY = 25;
    public const int LOVE = 30;
    
    // Melancholic States (2 states)
    public const int SADNESS = 9;
    public const int MELANCHOLY = 12;
    
    // Intense States (2 states)
    public const int ANGER = 10;
    public const int PASSION = 23;
    
    // Protective States (1 state)
    public const int FEAR = 11;
    
    // Tense States (1 state)
    public const int ANXIETY = 13;
}
```

### Grid Constants

```csharp
public static class GridConstants
{
    // Grid Dimensions
    public const int DEFAULT_WIDTH = 32;
    public const int DEFAULT_HEIGHT = 32;
    public const int MIN_GRID_SIZE = 8;
    public const int MAX_GRID_SIZE = 128;
    
    // Simulation Parameters
    public const float DEFAULT_UPDATE_INTERVAL = 0.05f;
    public const float MIN_UPDATE_INTERVAL = 0.01f;
    public const float MAX_UPDATE_INTERVAL = 1.0f;
    
    // Performance Limits
    public const int MAX_SPARKS_PER_FRAME = 5;
    public const int MAX_SIMULTANEOUS_CALCULATIONS = 1000;
    public const int PERFORMANCE_HISTORY_SIZE = 60;
    
    // Emotional State Ranges
    public const float MIN_LEVEL = 0f;
    public const float MAX_LEVEL = 255f;
    public const float NEUTRAL_LEVEL = 128f;
    public const float DECAY_THRESHOLD = 1f;
    
    // Mathematical Constants
    public const float BEA_GOLDEN_RATIO = 1.618f;      // Used in transcendent calculations
    public const float COMBUST_MULTIPLIER = 1.5f;      // 1+1=3 principle base multiplier
    public const float BALANCE_DAMPENING = 0.8f;       // Equilibrium seeking factor
    public const float DISSOLVE_REDUCTION = 0.6f;      // State degradation factor
    
    // Category Weights
    public const float COGNITIVE_WEIGHT = 1.0f;
    public const float PEACEFUL_WEIGHT = 0.8f;
    public const float TRANSCENDENT_WEIGHT = 2.0f;
    public const float EMPOWERED_WEIGHT = 1.2f;
    public const float INTENSE_WEIGHT = 1.5f;
    public const float CONNECTED_WEIGHT = 1.1f;
    
    // Interaction Distances
    public const int NEIGHBOR_RADIUS = 1;              // Standard Moore neighborhood
    public const int EXTENDED_RADIUS = 2;              // Extended influence range
    public const int TRANSCENDENT_RADIUS = 3;          // Transcendent state influence
}
```

### Operator Symbols

```csharp
public static class BEAOperators
{
    public const string COMBUST = "⊕";      // Creates emergent properties (1+1=3)
    public const string BALANCE = "⊖";      // Seeks equilibrium and harmony
    public const string DISSOLVE = "⊗";     // Breaks down complex states
    public const string AMPLIFY = "⨀";      // Intensifies stronger emotional state
}
```

---

**API Version**: 1.0  
**Compatibility**: Unity 2022.3 LTS+  
**Last Updated**: October 20, 2025

---

*This API reference provides essential information for developers working with the BEA framework. For implementation examples, see the Quick Start Guide and project documentation.*

© 2025 Jeremy F. Jackson. All Rights Reserved. **Beat⊕k™** is a trademark of Jeremy F. Jackson.
