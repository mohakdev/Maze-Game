using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    static bool PrinterOn = true;
    static bool OnlyPrint = false;
    /// <summary>
    /// Prints and message if Printer is ON and Only Print is not used.
    /// </summary>
    public static void PrintMsg(string msg)
    {
        if (PrinterOn && !OnlyPrint)
        {
            Debug.Log(msg);
        }
    }
    /// <summary>
    /// Only Print makes it so normal print messages dont work
    /// </summary>
    public static void OnlyPrintMsg(string msg)
    {
        OnlyPrint = true;
        if (PrinterOn)
        {
            Debug.Log(msg);
        }
    }
}
