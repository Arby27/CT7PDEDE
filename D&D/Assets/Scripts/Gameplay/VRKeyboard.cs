using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class VRKeyboard : MonoBehaviour {

    public static VRKeyboard vRKeyboard;

    public InputField textEntry;
    public bool minimalMode;
    static bool keyboardShowing;
    public string text = "";

    
    // Use this for initialization
    void Awake()
    {
        vRKeyboard = this;
    }

    void OnEnable()
    {
        SteamVR_Events.System(EVREventType.VREvent_KeyboardCharInput).Listen(OnKeyboard);
        SteamVR_Events.System(EVREventType.VREvent_KeyboardClosed).Listen(OnKeyboardClosed);
    }

    private void Update()
    {
        if (textEntry.isFocused == true)
        {
            KeyboardUp();
        }
    }

    private void OnKeyboard(VREvent_t args)
    {
        
        VREvent_Keyboard_t keyboard = args.data.keyboard;
        byte[] inputBytes = new byte[] { keyboard.cNewInput0, keyboard.cNewInput1, keyboard.cNewInput2, keyboard.cNewInput3, keyboard.cNewInput4, keyboard.cNewInput5, keyboard.cNewInput6, keyboard.cNewInput7 };
        int len = 0;
        for (; inputBytes[len] != 0 && len < 7; len++) ;
        string input = Encoding.UTF8.GetString(inputBytes, 0, len);

        if (minimalMode)
        {
            if (input == "\b")
            {
                if (text.Length > 0)
                {
                    text = text.Substring(0, text.Length - 1);
                }
            }
            else if (input == "\x1b")
            {
                // Close the keyboard
                SteamVR.instance.overlay.HideKeyboard();
                keyboardShowing = false;
            }
            else
            {
                text += input;
            }
            textEntry.text = text;
            PlayerNetwork.playerName = text + " #" + Random.Range(1000, 9999);
        }
        else
        {
            StringBuilder textBuilder = new StringBuilder(1024);
            uint size = SteamVR.instance.overlay.GetKeyboardText(textBuilder, 1024);
            text = textBuilder.ToString();
            textEntry.text = text;
            PlayerNetwork.playerName = text + " #" + Random.Range(1000, 9999);
        }
    }

    private void OnKeyboardClosed(VREvent_t args)
    {
        keyboardShowing = false;
        
    }

    public void KeyboardUp()
    {
        if (!keyboardShowing)
        {
            keyboardShowing = true;
            int inputMode = (int)EGamepadTextInputMode.k_EGamepadTextInputModeNormal;
            int lineMode = (int)EGamepadTextInputLineMode.k_EGamepadTextInputLineModeSingleLine;
            SteamVR.instance.overlay.ShowKeyboard(inputMode, lineMode, "RoomName", 20, textEntry.text, minimalMode, 0);
        }
        else
        {
            textEntry.DeactivateInputField();
        }
    }


}
