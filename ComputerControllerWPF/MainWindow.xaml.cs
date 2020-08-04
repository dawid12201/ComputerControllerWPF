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
using System.Speech.Recognition;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;

namespace ComputerControllerWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        public static bool isLookingInGoogle = false;
        public static int amount = 5;
        public static string googleRecognizedText = "";
        public static string recognizedText = "";

        public static void PlaySong()
        {
            Dapplo.Windows.Input.Keyboard.KeyboardInputGenerator.KeyDown(Dapplo.Windows.Input.Enums.VirtualKeyCode.MediaPlayPause);
        }
        public static void NextSong()
        {
            Dapplo.Windows.Input.Keyboard.KeyboardInputGenerator.KeyDown(Dapplo.Windows.Input.Enums.VirtualKeyCode.MediaNextTrack);
        }
        public static void PreviousSong()
        {
            Dapplo.Windows.Input.Keyboard.KeyboardInputGenerator.KeyDown(Dapplo.Windows.Input.Enums.VirtualKeyCode.MediaPrevTrack);
        }

        public static void VolumeUp()
        {
            Dapplo.Windows.Input.Keyboard.KeyboardInputGenerator.KeyDown(Dapplo.Windows.Input.Enums.VirtualKeyCode.VolumeUp);
        }

        public static void VolumeDown()
        {
            Dapplo.Windows.Input.Keyboard.KeyboardInputGenerator.KeyDown(Dapplo.Windows.Input.Enums.VirtualKeyCode.VolumeDown);
        }


        private static void Chrome(string link)
        {
            string url = "";

            if (!string.IsNullOrEmpty(link)) //if empty just run the browser
            {
                if (link.Contains('.')) //check if it's an url or a google search
                {
                    url = link;
                }
                else
                {
                    url = "https://www.google.com/search?q=" + link.Replace(" ", "+");
                }
            }

            try
            {
                Process.Start("chrome.exe", url + " --incognito");
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Unable to find Google Chrome...",
                    "chrome.exe not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void ListenToCall()
        {
            while (true)
            {
                Speak speak = new Speak();
                switch (recognizedText)
                {
                    case "help me stephen":
                        speak.CalledFor();
                        recognizedText = "";
                        break;
                    case "fuck":
                        speak.DontSwear();
                        recognizedText = "";
                        break;
                    case "open spotify":
                        speak.OpenSpotify();
                        recognizedText = "";
                        break;
                    case "shutdown":
                        speak.Shutdown();
                        recognizedText = "";
                        Thread.Sleep(2000);
                        if (recognizedText == "yes")
                        {
                            speak.ShutdownApproved();
                            System.Environment.Exit(0);
                        }
                        else speak.ShutdownCancelled();
                        recognizedText = "";
                        break;
                    case "open chrome":
                        speak.OpenChrome();
                        recognizedText = "";
                        break;
                    case "open settings":
                        speak.OpenSettings();
                        recognizedText = "";
                        break;
                    case "play song":
                        PlaySong();
                        recognizedText = "";
                        break;
                    case "next song":
                        NextSong();
                        recognizedText = "";
                        break;
                    case "previous song":
                        PreviousSong();
                        recognizedText = "";
                        break;
                    case "volume down":
                        for (int i = 0; i < amount; i++)
                        {
                            VolumeDown();
                            Thread.Sleep(20);
                        }
                        recognizedText = "";
                        break;
                    case "volume up":
                        for (int i = 0; i < amount; i++)
                        {
                            VolumeUp();
                            Thread.Sleep(20);
                        }
                        recognizedText = "";
                        break;
                    case "tell me something about gimper's group":
                        speak.Hajsownicy();
                        recognizedText = "";
                        break;
                    case "thank you":
                        speak.Welcome();
                        recognizedText = "";
                        break;
                    case "hello stephen":
                        speak.hello();
                        recognizedText = "";
                        break;
                    case "what's the current time":
                        speak.currentTime();
                        recognizedText = "";
                        break;
                    case "what day is it":
                        speak.currentDate();
                        recognizedText = "";
                        break;
                    case "search google":
                        speak.SearchGoogle();
                        recognizedText = "";
                        isLookingInGoogle = true;
                        DictationGrammar dictation = new DictationGrammar();
                        recognizer.UnloadAllGrammars();
                        recognizer.LoadGrammarAsync(dictation);
                        Thread.Sleep(6000);
                        Chrome(googleRecognizedText);
                        googleRecognizedText = "";
                        Choices choices = new Choices();
                        choices.Add(new string[] { "help me stephen", "Play song", "Fuck", "Open Spotify", "Shutdown",
                        "Yes", "No", "Open Chrome", "Open Settings", "Next song", "Previous song",
                        "Volume up", "Volume down", "Thank you", "Hello stephen",
                        "what's the current time", "what day is it", "Search google", "What's the current weather"});

                        var gb = new GrammarBuilder(choices);
                        gb.Culture = recognizer.RecognizerInfo.Culture;
                        var g = new Grammar(gb);
                        recognizer.LoadGrammarAsync(g);
                        recognizer.UnloadGrammar(dictation);
                        isLookingInGoogle = false;
                        break;
                    case "what's the current weather":
                        WeatherForecast forecast = new WeatherForecast();
                        speak.currentWeather();
                        recognizedText = "";
                        break;
                    case "listen":
                        speak.ListenKurwa();
                        recognizedText = "";
                        break;
                    case "kici kici tash tash":
                        SoundPlayer player = new SoundPlayer();
                        player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\do lwa.wav";
                        player.Play();
                        recognizedText = "";
                        break;
                    case "what's the current coronavirus status":
                        CoronaVirus corona = new CoronaVirus();
                        //corona.GetCoronaStatusForPoland();
                        speak.CoronaVirusNotImplemented();
                        recognizedText = "";
                        break;
                }
            }
        }
        public void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (!isLookingInGoogle)
            {
                Konsola.AppendText("\nRecognized text :" + e.Result.Text);
                //Console.WriteLine("Recognized text: " + e.Result.Text);
                recognizedText = e.Result.Text.ToLower();
            }
            else
            {
                Konsola.AppendText("\nLooking in Google for: " + e.Result.Text);
                googleRecognizedText = e.Result.Text.ToLower();
            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Speak speak = new Speak();
            //speak.introduceMyself();

            Thread thread1 = new Thread(ListenToCall);
            thread1.Start();
            // Create an in-process speech recognizer for the en-US locale.  
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");




            Choices choices = new Choices();
            choices.Add(new string[] { "help me stephen", "Play song", "Fuck", "Open Spotify", "Shutdown",
                "Yes", "No", "Open Chrome", "Open Settings", "Next song", "Previous song",
                "Volume up", "Volume down", "Thank you", "Hello stephen", "what's the current time", "what day is it", "Search google", "what's the current weather", "listen", "kici kici tash tash",
                "what's the current CoronaVirus status"});

            var gb = new GrammarBuilder(choices);
            gb.Culture = recognizer.RecognizerInfo.Culture;
            var g = new Grammar(gb);

            // Create and load a dictation grammar.  
            //recognizer.LoadGrammar(new DictationGrammar());
            recognizer.LoadGrammar(g);
            // Add a handler for the speech recognized event.  
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Configure input to the speech recognizer.  
            recognizer.SetInputToDefaultAudioDevice();

            // Start asynchronous, continuous speech recognition.  
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

        }
    

        private void Pokaz_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            Grid grid = new Grid();
            System.Windows.Controls.TextBox textBox = new System.Windows.Controls.TextBox();
            textBox.Text = "Dostępne Komendy:\nHelp me Stephen \nHello Stephen - witamy się ze Stefanem \nPlay Song - Odtwarza / zatrzymuje obecny utwór \nVolume up - Zwieksza systemową głośność o 10 \nVolume down - Zmniejsza systemową głośność o 10 \nPrevious Song - przełącza na poprzednią piosenkę(rozpoczyna obecną od początku, żeby wrócić, trzeba powiedzieć dwa razy)\nNext Song - Przełącza na następną piosenkę\nOpen Spotify - Wyszukuje w systemie aplikację Spotify i włącza ją \n" +
                "Open Chrome - Wyszukuje w systemie przeglądarkę google Chrome i włącza ją w trybie incognito \nShutdown - Zamyka aplikację, program zapyta nas, czy jesteśmy pewni - odpowiadamy Yes / No \nOpen Settings - Uruchamia ustawienia systemowe \nThank you - no to jak wiadomo \nWhat's the current time - podaje obecną godzinę \nWhat day is it - podaje obecną datę" +
                "\nSearch Google - Włącza wyszukiwanie w google - wtedy możemy powiedzieć mu wszystko po angielsku, on to dla nas wyszuka i pokaże w defaultowej przeglądarce (system jest troszkę upośledzony i nie rozpoznaje nazw własnych, ani języka polskiego) \nWhat's the current weather - łączy się z API pogodowym i pokazuje nam obecną pogodę dla Wrocławia. \n" +
                "Kici Kici, taś taś - Easter EGG z filmu Poranek Kojota :) / Uwaga, występuje przekleństwo!!! \nWhat's the current CoronaVirus status - Do zaimplementowania, niestety występują pewne problemy z formatowaniem JSONa z API i ta funkcja obecnie nie działa";
            textBox.IsReadOnly = true;
            textBox.TextWrapping = TextWrapping.Wrap;
            window.Width = 450;
            window.Height = 700;
            grid.Children.Add(textBox);
            window.Content = grid;
            window.Show();
        }
    }
}
