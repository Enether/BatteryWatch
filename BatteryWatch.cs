﻿using BatteryWatch.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


/* VERSION: 0.1
   AUTHOR: Enether */
namespace BatteryWatch
{
    static class BatteryWatch
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BatteryWatchApplicationContext());
        }
    }
}


public class BatteryWatchApplicationContext : ApplicationContext
{
    private NotifyIcon trayIcon;

    public BatteryWatchApplicationContext()
    {
        // Initialize Tray Icon
        trayIcon = new NotifyIcon()
        {
            Icon = new Icon("../../Resources/Danleech-Simple-Picasa.ico"),
            ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", OnExit)
            }),
            Visible = true
        };
    }

    void OnExit(object sender, EventArgs e)
    {
        // Hide tray icon, otherwise it will remain shown until user mouses over it
        trayIcon.Visible = false;

        Application.Exit();
    }
}