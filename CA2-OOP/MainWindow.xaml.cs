using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creating teams
        Team t1 = new Team("France");
        Team t2 = new Team("Italy");
        Team t3 = new Team("Spain");

        //French players
        Player p1 = new Player("Marie", "WWDDL");
        Player p2 = new Player("Claude", "DDDLW");
        Player p3 = new Player("Antoine", "LWDLW");

        //Italian players
        Player p4 = new Player("Marco", "WWDLL");
        Player p5 = new Player("Giovanni", "LLLLD");
        Player p6 = new Player("Valentina", "DLWWW");

        //Spanish players
        Player p7 = new Player("Maria", "WWWWW");
        Player p8 = new Player("Jose", "LLLLL");
        Player p9 = new Player("Pablo", "DDDDD");

        public MainWindow()
        {
            InitializeComponent();

            //Adding data on startup
            GetData();
            Calculate(t1);
            Calculate(t2);
            Calculate(t3);
        }

        void GetData()
        {
            //Displaying teams in lbxTeams
            lbxTeams.Items.Add(t1.Name);
            lbxTeams.Items.Add(t2.Name);
            lbxTeams.Items.Add(t3.Name);

            //Adding plyers to teams with starting values
            t1.Players.Add(p1);
            t1.Players.Add(p2);
            t1.Players.Add(p3);
            t2.Players.Add(p4);
            t2.Players.Add(p5);
            t2.Players.Add(p6);
            t3.Players.Add(p7);
            t3.Players.Add(p8);
            t3.Players.Add(p9);
        }

        void Calculate(Team team)
        {
            //Reset team points every time the method is called
            team.Points = 0;

            foreach (Player player in team.Players)
            {
                //Reset points every time the method is called
                player.Points = 0;
                foreach (char c in player.ResultRecord)
                {
                    if(c == 'W')
                        player.Points += 3;
                    if (c == 'D')
                        player.Points += 1;
                }
                //Keep out of foreach loop so that it does not add one player multiple times
                //Keep inside this foreach loop so that it adds once per player
                team.Points += player.Points;
            }
        }

        void DisplayPlayers(Team team)
        {
            lbxPlayers.Items.Clear(); //Clear the listbox so that it doesn't show the previous selections aswell
            lbxPlayers.Items.Add("Team total points: " + team.Points.ToString());
            List<Player> players = team.Players;
            foreach (Player player in players)
            {
                lbxPlayers.Items.Add(player.Name + " - " + player.ResultRecord + " - " + player.Points.ToString());
            }
        }

        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the selected team
            string selectedTeam = lbxTeams.SelectedItem as string;

            if (selectedTeam == t1.Name)
                DisplayPlayers(t1);
            if (selectedTeam == t2.Name)
                DisplayPlayers(t2);
            if (selectedTeam == t3.Name)
                DisplayPlayers(t3);
        }

        private void btnWin_Click(object sender, RoutedEventArgs e)
        {
            //Get the selected team
            string selectedTeam = lbxTeams.SelectedItem as string;

            if (selectedTeam == t1.Name)
            {
                foreach (Player player in t1.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "W";
                    Calculate(t1);
                    DisplayPlayers(t1);
                }
            }
            if (selectedTeam == t2.Name)
            {
                foreach (Player player in t2.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "W";
                    Calculate(t2);
                    DisplayPlayers(t2);
                }
            }
            if (selectedTeam == t3.Name)
            {
                foreach (Player player in t3.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "W";
                    Calculate(t3);
                    DisplayPlayers(t3);
                }
            }
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            //Get the selected team
            string selectedTeam = lbxTeams.SelectedItem as string;

            if (selectedTeam == t1.Name)
            {
                foreach (Player player in t1.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "D";
                    Calculate(t1);
                    DisplayPlayers(t1);
                }
            }
            if (selectedTeam == t2.Name)
            {
                foreach (Player player in t2.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "D";
                    Calculate(t2);
                    DisplayPlayers(t2);
                }
            }
            if (selectedTeam == t3.Name)
            {
                foreach (Player player in t3.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "D";
                    Calculate(t3);
                    DisplayPlayers(t3);
                }
            }
        }

        private void btnLoss_Click(object sender, RoutedEventArgs e)
        {
            //Get the selected team
            string selectedTeam = lbxTeams.SelectedItem as string;

            if (selectedTeam == t1.Name)
            {
                foreach (Player player in t1.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "L";
                    Calculate(t1);
                    DisplayPlayers(t1);
                }
            }
            if (selectedTeam == t2.Name)
            {
                foreach (Player player in t2.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "L";
                    Calculate(t2);
                    DisplayPlayers(t2);
                }
            }
            if (selectedTeam == t3.Name)
            {
                foreach (Player player in t3.Players)
                {
                    player.ResultRecord = player.ResultRecord.Remove(0, 1);
                    player.ResultRecord += "L";
                    Calculate(t3);
                    DisplayPlayers(t3);
                }
            }
        }
    }
}