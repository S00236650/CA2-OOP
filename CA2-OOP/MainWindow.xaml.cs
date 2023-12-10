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

            SortTeams();
        }

        void SortTeams()
        {
            //Creating a list so that it can be sorted by points
            List<Team> teams = new List<Team> { t1, t2, t3 };
            teams.Sort();

            //Displaying teams in lbxTeams
            lbxTeams.Items.Clear();
            lbxTeams.Items.Add(teams[2].Name);
            lbxTeams.Items.Add(teams[1].Name);
            lbxTeams.Items.Add(teams[0].Name);
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

        BitmapImage GetImageSource(bool filled)
        {
            //Set the path for the star images
            string starOutline = "/staroutline.png";
            string starSolid = "/starsolid.png";

            // Create a new BitmapImage for the empty star
            BitmapImage emptyStar = new BitmapImage();
            emptyStar.BeginInit();
            emptyStar.UriSource = new Uri(starOutline, UriKind.RelativeOrAbsolute);
            emptyStar.EndInit();

            // Create a new BitmapImage for the filled star
            BitmapImage fillStar = new BitmapImage();
            fillStar.BeginInit();
            fillStar.UriSource = new Uri(starSolid, UriKind.RelativeOrAbsolute);
            fillStar.EndInit();

            if(filled)
                return fillStar;
            else
                return emptyStar;
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

            SortTeams();
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

            SortTeams();
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

            SortTeams();
        }

        private void lbxPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected player
            Player selectedPlayer = new Player();
            if (lbxPlayers.SelectedItem != null)
            {
                if (lbxPlayers.SelectedItem.ToString().Contains(p1.Name))
                    selectedPlayer = p1;
                if (lbxPlayers.SelectedItem.ToString().Contains(p2.Name))
                    selectedPlayer = p2;
                if (lbxPlayers.SelectedItem.ToString().Contains(p3.Name))
                    selectedPlayer = p3;
                if (lbxPlayers.SelectedItem.ToString().Contains(p4.Name))
                    selectedPlayer = p4;
                if (lbxPlayers.SelectedItem.ToString().Contains(p5.Name))
                    selectedPlayer = p5;
                if (lbxPlayers.SelectedItem.ToString().Contains(p6.Name))
                    selectedPlayer = p6;
                if (lbxPlayers.SelectedItem.ToString().Contains(p7.Name))
                    selectedPlayer = p7;
                if (lbxPlayers.SelectedItem.ToString().Contains(p8.Name))
                    selectedPlayer = p8;
                if (lbxPlayers.SelectedItem.ToString().Contains(p9.Name))
                    selectedPlayer = p9;
            }

            // Check if the selectedPlayer is not null
            if (selectedPlayer != null)
            {
            if (selectedPlayer.Points == 0)
                {
                    imgStar1.Source = GetImageSource(false);
                    imgStar2.Source = GetImageSource(false);
                    imgStar3.Source = GetImageSource(false);
                }
                else if (selectedPlayer.Points > 0 && selectedPlayer.Points <= 5)
                {
                    imgStar1.Source = GetImageSource(true);
                    imgStar2.Source = GetImageSource(false);
                    imgStar3.Source = GetImageSource(false);
                }
                else if (selectedPlayer.Points > 5 && selectedPlayer.Points <= 10)
                {
                    imgStar1.Source = GetImageSource(true);
                    imgStar2.Source = GetImageSource(true);
                    imgStar3.Source = GetImageSource(false);
                }
                else if (selectedPlayer.Points > 10 && selectedPlayer.Points <= 15)
                {
                    imgStar1.Source = GetImageSource(true);
                    imgStar2.Source = GetImageSource(true);
                    imgStar3.Source = GetImageSource(true);
                }
            }
        }
    }
}