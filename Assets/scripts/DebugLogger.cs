using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Logs messages for debugging.
/// </summary>
public class DebugLogger : MonoBehaviour 
{
    /// <summary>
    /// Reference to the one and only instance of this singleton class.
    /// Use this to keep track of whether there is a copy of this thing.
    /// </summary>
    private static DebugLogger s_instance = null;

    /// <summary>
    /// List of messages received.
    /// </summary>
    private static List<string> s_messages = new List<string>();

    /// <summary>
    /// Store a reference to this instance into s_instance;
    /// </summary>
    private void Awake()
    {
        s_instance = this;
    }

#if DEBUG_MODE

    /// <summary>
    /// Called one or more times each frame to recreate the UI.
    /// </summary>
    private void OnGUI()
    {
        // Automagically finds a place to put a label with the word "Hello."
        //GUILayout.Label("Hello");

        // For each message in the list...
        for(int i = 0; i < s_messages.Count; ++i)
        {
            // Output the message.
            GUILayout.Label(s_messages[i]);
        }
    }

#endif

    /// <summary>
    /// Adds a new message to the log.
    /// </summary>
    public static void LogMessage(string newMessage)
    {
        // If there is no Logger in the scene yet.
        if(s_instance == null)
        {
            // Finds the prefab version of the logger in your Resources folder.
            GameObject loggerPrefab = Resources.Load<GameObject>("Logger");

            // Spawns an instance of the prefab to ensure that logging happens properly.
            Instantiate<GameObject>(loggerPrefab);
        }

        // Add a message to the visual display.
        s_messages.Add(newMessage);

        // Also logs to the console.
        Debug.Log(newMessage);
    }
}
