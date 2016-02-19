using UnityEngine;
using System;
using System.Diagnostics;
using System.Collections;
using System.Runtime.InteropServices;

static class User32 {
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    internal static readonly IntPtr InvalidHandleValue = IntPtr.Zero;
    internal const int SW_MAXIMIZE = 3;
}

public class Runner : MonoBehaviour {

    Jukebox jukebox;

    void Awake() {

        if (GameObject.Find("Jukebox"))
            jukebox = GameObject.Find("Jukebox").GetComponent<Jukebox>();
    }

    public void Run(Game game) {
        Process myProcess = new Process();
        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        myProcess.StartInfo.CreateNoWindow = true;
        myProcess.StartInfo.UseShellExecute = false;
        myProcess.StartInfo.FileName = game.executablePath;//"C:\\WINNITRON\\Games\\Canabalt\\Canabalt.exe";
        myProcess.EnableRaisingEvents = true;
        StartCoroutine(RunProcess(myProcess));
    }

    IEnumerator RunProcess(Process process) {
        if (jukebox) jukebox.stop();
        GM.ChangeState(GM.WorldState.Idle);
        Screen.fullScreen = false;
        //TO DO - stuff that is a transition
        yield return new WaitForSeconds(1.0f);
        process.Start();
        process.WaitForExit();

        Process currentProcess = Process.GetCurrentProcess();
        IntPtr hWnd = currentProcess.MainWindowHandle;
        if (hWnd != IntPtr.Zero) {
            User32.SetForegroundWindow(hWnd);
            User32.ShowWindow(hWnd, User32.SW_MAXIMIZE);
        }

        Screen.fullScreen = true;
        GM.ChangeState(GM.WorldState.Intro);
        if (jukebox) jukebox.play();

    }
}

