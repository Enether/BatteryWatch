﻿using System.Windows.Forms;

namespace BatteryWatch
{
    public partial class SettingsWindow : Form
    {
        private int lowestBatteryPercent = 0;
        private int highestBatteryPercent = 0;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void lowestBatteryPercentTextBox_TextChanged(object sender, System.EventArgs e)
        {
            bool hasParsed = int.TryParse(this.lowestBatteryPercentTextBox.Text, out this.lowestBatteryPercent);

            if (!hasParsed)
                this.lowestBatteryPercent = -1;  // used to trigger the invalid input window
        }

        private void highestBatteryPercentTextBox_TextChanged(object sender, System.EventArgs e)
        {
            bool hasParsed = int.TryParse(this.highestBatteryPercentTextBox.Text, out this.highestBatteryPercent);

            if (!hasParsed)
                this.highestBatteryPercent = -1;  // used to trigger the invalid input window
        }

        private void closeSettingsButton_Click(object sender, System.EventArgs e)
        {
            if(lowestBatteryPercent != 0 && highestBatteryPercent != 0) // they are changed
            {
                if (InputIsValid(this.lowestBatteryPercent, this.highestBatteryPercent))
                {
                    this.Hide();

                    // create the tray icon and start the watcher loop
                    var bwac = new BatteryWatchApplicationContext(this.lowestBatteryPercent, this.highestBatteryPercent);
                }
                else
                {
                    InvalidInputWindow invalidInputWindow = new InvalidInputWindow();
                    invalidInputWindow.Show();
                }

            }
        }

        private bool InputIsValid(int minimumPercentage, int maximumPercentage)
        {
            /* returns if the input that has been entered is valid. Must be numbers from 2-99 and the minimumPercentage must
             be 5 less than the maximum */
            bool validMinPercentage = (minimumPercentage >= 2 && minimumPercentage <= 94);
            bool validMaxPercentage = (maximumPercentage >= 7 && maximumPercentage <= 99);
            bool differenceIsBiggerThanFive = (maximumPercentage - minimumPercentage) >= 5;

            return validMinPercentage && validMaxPercentage && differenceIsBiggerThanFive;
        }
    }
}
