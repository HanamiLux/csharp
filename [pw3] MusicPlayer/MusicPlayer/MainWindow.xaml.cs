using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace MusicPlayer
{

    public partial class MainWindow : Window
    {
        List<string> files = new List<string>(); //Для ВСЕХ файлов (можно и linq, но мне лень) нужен лишь в начале
        List<string> songs = new List<string> {"Add your music here!"}; //Для ListBox с красивыми (обрезанными) названиями
        List<string> songPaths = new List<string>(); // Для медиаэлемента, хранит все пути до .mp3
        List<string> oldSongPaths = new List<string>(); // Для медиаэлемента и возврата от рандомного songPaths
        int currentsong = 1;
        int splittedPathStartIndex= 0;

        const int TICK = 20;
        byte j = 0;
        public MainWindow()
        {
            InitializeComponent();
            Default();
            ListBox.ItemsSource = songs;
        }

        /// <summary>
        /// Получение всех mp3 файлов папки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            Default();
            var dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                files = Directory.GetFiles(dialog.FileName).ToList();
                splittedPathStartIndex = dialog.FileName.Length;
                foreach (string file in files) //Только mp3 файлы добавляются в ListBox
                {
                    if (file.Contains(".mp3"))
                    {
                        songs.Add(file.Substring(splittedPathStartIndex + 1)); //Из имени файла убирается путь до него
                        songPaths.Add(file);
                    }
                }
            }
            else
                return;
            oldSongPaths = songPaths.ToList();
            ListBox.ItemsSource = songs;
            PlayPause();
            MusicPlay();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
            pausebtn.Visibility = Visibility.Hidden;
            playbtn.Visibility = Visibility.Visible;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
            playbtn.Visibility = Visibility.Hidden;
            pausebtn.Visibility = Visibility.Visible;
        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            if(j == 0 || j == 2)
            currentsong++;
            PlayPause();
            MusicPlay();
            
        }

        private void prebtn_Click(object sender, RoutedEventArgs e)
        {
            if(j == 0 || j == 2)
            currentsong--;
            PlayPause();
            MusicPlay();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 0;
            if (ListBox.ItemsSource != null)
            {
                while (ListBox.SelectedItem.ToString() != songs[i])
                    i++;
                currentsong = i;
                PlayPause();
                MusicPlay();
            }
        }

        private void Soundbtn_Click(object sender, RoutedEventArgs e)
        {
            if (soundSlider.IsVisible)
                soundSlider.Visibility = Visibility.Hidden;
            else
                soundSlider.Visibility = Visibility;
        }
        
        private void Default()
        {
            currentsong = 0;
            songPaths.Clear();
            songs.Clear();
            files.Clear();
            ListBox.ItemsSource = null;
            playbtn.Visibility = Visibility.Hidden;
            soundSlider.Visibility = Visibility.Hidden;
            repbtn.Visibility = Visibility.Hidden;
            randombtn.Visibility = Visibility.Hidden;
        }
        private void MusicPlay()
        {
            try
            {
                if (currentsong > songs.Count - 1)
                    currentsong = 0;
                if (currentsong < 0)
                    currentsong = songs.Count - 1;
                media.Source = new Uri(songPaths[currentsong]);
                slider.Value = 0;
                media.Play();
                Thread thread = new Thread(newThreadTimeUpdate);
                thread.Start();
            }
            catch (Exception)
            {
                return;
            }
        }
        private void newThreadTimeUpdate()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    timeStart.Content = media.Position.ToString().Substring(0, 8);
                    slider.Value = media.Position.TotalSeconds;
                    if (slider.Value == slider.Maximum)
                        return;
                }));
            } 
        }
        private void PlayPause()
        {
            if (playbtn.IsVisible)
            {
                playbtn.Visibility = Visibility.Hidden;
                pausebtn.Visibility = Visibility.Visible;
            }
        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            nowPlaying.Content = songs[currentsong];
            timeEnd.Content = media.NaturalDuration.TimeSpan.ToString().Substring(0,8);
            slider.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
        }
        private void slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            media.Pause();
            media.Position = TimeSpan.FromSeconds(slider.Value);
            media.Play();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (j == 0 || j == 2)
                currentsong++;
            timeEnd.Content = string.Empty;
            nowPlaying.Content = string.Empty;
            MusicPlay();
        }

        /// <summary>
        /// Loop, random playlist, default mode playing
        /// j = 0 - default mode
        /// j = 1 - loop mode
        /// j = 2 randomized list mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repeat_Click(object sender, RoutedEventArgs e)
        {
            switch (j)
            {
                case 0:
                    j=1;
                    norepbtn.Visibility = Visibility.Hidden;
                    repbtn.Visibility = Visibility.Visible;
                    randombtn.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    j = 2;
                    songPaths.Shuffle();
                    songs.Clear();
                    foreach (string song in songPaths)
                    {
                        songs.Add(song.Substring(splittedPathStartIndex + 1));
                    }
                    ListBox.ItemsSource = null;
                    ListBox.ItemsSource = songs;
                    norepbtn.Visibility = Visibility.Hidden;
                    repbtn.Visibility = Visibility.Hidden;
                    randombtn.Visibility = Visibility.Visible;
                    break;
                case 2:
                    j = 0;
                    songPaths = oldSongPaths.ToList();
                    songs.Clear();
                    foreach (string song in songPaths)
                    {
                        songs.Add(song.Substring(splittedPathStartIndex + 1));
                    }
                    ListBox.ItemsSource = null;
                    ListBox.ItemsSource = songs;
                    norepbtn.Visibility = Visibility.Visible;
                    repbtn.Visibility = Visibility.Hidden;
                    randombtn.Visibility = Visibility.Hidden;
                    break;
            }
        }
        private void soundSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = soundSlider.Value;
        }
    }

}
