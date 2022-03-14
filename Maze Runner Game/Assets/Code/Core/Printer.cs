using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Printer
{
    static bool PrinterOn = true;
    public static void PrintMsg(string msg)
    {
        if (PrinterOn)
        {
            Debug.Log(msg);
        }
    }
}
