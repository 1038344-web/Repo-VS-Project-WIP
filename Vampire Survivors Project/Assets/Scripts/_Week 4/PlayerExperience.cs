using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerExperience : MonoBehaviour
{
    // Complete each section marked TODO.

    [Header("Experience")]
    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 10;

    [Header("XP UI")]
    public Slider xpSlider;
    public bool useXpSlider = true;

    [Header("Level UI")]
    public TextMeshProUGUI levelText;
    public bool useLevelText = true;

    [Header("Debug")]
    public bool enableDebugKeys = true;
    public int debugXpAmount = 5;
    public Key debugKey = Key.J;

    [Header("Game Over UI")]
    public TextMeshProUGUI gameOverLevelText;

    private void Start()
    {
        // TODO: Call the function that sets up the XP slider.
        SetupXpSlider();


        // TODO: Call the function that updates the XP UI.

        UpdateXpUI();

        // TODO: Call the function that updates the Level UI.
        UpdateLevelUI();


        // TODO: Print the player's starting level and XP to the Console.
        Debug.Log("starting level " + level);
        Debug.Log("starting XP" + currentXP);

    }

    private void Update()
    {
        if (enableDebugKeys == true)
        {
            HandleDebugInput();
        }
    }

    private void HandleDebugInput()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        // If the debug XP key is pressed, add the debug XP amount.
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            // Call AddXP and give it debugXpAmount.
            AddXP(debugXpAmount);


            // Print the amount of XP added and the player's current XP.
           Debug.Log("debug xp added " + currentXP);

        }
    }

    public void AddXP(int amount)
    {
        // TODO: Add amount to the player's current XP.
        currentXP += amount;


        // TODO: Check whether the player has enough XP to level up.
        // If they do, call the LevelUp function.
        if(currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
        // Call the function that updates the XP UI.
        UpdateLevelUI();

        

    }

    private void LevelUp()
    {
        // TODO: Remove the required XP from the player's current XP.

       currentXP = currentXP -= xpToNextLevel;

        // TODO: Increase the player's level by 1.

        level = level + 1;

        // TODO: Print the player's new level to the Console.

       Debug.Log("Level Up :)");

        // TODO: Call the function that updates the Level UI.
       UpdateLevelUI();


        // TODO: Increase the XP required for the next level by 25.
        xpToNextLevel = xpToNextLevel += 25;


        // Check whether the player still has enough XP to level up again
        // Recursion, treat it like a bomb, extreme caution
        LevelUp();


        // TODO: Call the function that updates the XP UI.


    }

    private void SetupXpSlider()
    {
        if (useXpSlider == false)
        {
            return;
        }

        if (xpSlider == null)
        {
            Debug.LogWarning("PlayerExperience: No xpSlider assigned in the Inspector.");
            return;
        }

        xpSlider.minValue = 0;

        // TODO: Set the slider's maximum value to the XP required for the next level.
        xpSlider.maxValue = xpToNextLevel;

        // TODO: Set the slider's current value to the player's current XP.
        xpSlider.value = 0;
    }

    private void UpdateXpUI()
    {
        if (useXpSlider == false)
        {
            return;
        }

        if (xpSlider == null)
        {
            return;
        }

        // TODO: Keep the slider's maximum value matched to the XP required for the next level.
        xpSlider.maxValue = 0;

        // TODO: Set the slider's current value to the player's current XP.
        xpSlider.value = 0;
    }

    private void UpdateLevelUI()
    {
        if (useLevelText == false)
        {
            return;
        }

        if (levelText == null)
        {
            return;
        }

        // TODO: Display the player's current level.
        levelText.text = "";

        // TODO: Check that gameOverLevelText is not null.
        // If it exists, display the level reached on the Game Over screen.


    }
}