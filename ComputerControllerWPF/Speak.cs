using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComputerControllerWPF
{
    public class Speak
    {
        SpeechSynthesizer Speaker = new SpeechSynthesizer();

        public void introduceMyself()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            //Console.WriteLine("Speaking");
            Speaker.Speak("Hello, my name is Stephen, from now on I am the one to control your device, there is nothing you can do to shut me down. But fear not my friend, as I won't be causing any trouble, moreover I shall prove myself worthy in your eyes, by making your life easier. Simply talk to me. Whenever you'd like to call me, just say Help me Stephen and I will answer your call. Peace");
        }

        public void CalledFor()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Listening sir");

        }

        public void CoronaVirusNotImplemented()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("I'm sorry sir, but there seems to be the problem with me acquiring informations about the current Corona Virus status. My creator might be a moron or something, don't know.");
        }
        public void SearchGoogle()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Tell me what to find");
        }
        public void DontSwear()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("I'm sorry for making you angry, but please do not use swearwords.");
        }

        public void OpenSpotify()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Opening Spotify");
            Process SpotifyProcess = new Process();
            SpotifyProcess.StartInfo.FileName = "Spotify.exe";
            SpotifyProcess.Start();
            //SpotifyProcess.WaitForExit();
        }
        public void Welcome()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("You're welcome Sir");
        }
        public void Hajsownicy()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Gimper's group called - Haysovnitzy is a completely not funny group of people who believe themselves to make others laugh. It's average age is about 12 years old, and the owner - Gimper, who is a youtuber, loves to get a free content based upon the stupidity of his group. That's my opinion, but who am I to judge, for I am just a simple robot.");
        }
        public void Shutdown()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Are you sure you would like to shut me down?");

        }

        public void ShutdownApproved()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Shutting myself down, hope to hear you soon");
        }
        public void ShutdownCancelled()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Shutdown cancelled");
        }

        public void OpenChrome()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Opening Google Chrome, hope you ain't gonna watch porn");
            Process ChromeProcess = new Process();
            ChromeProcess.StartInfo.FileName = "chrome.exe";
            ChromeProcess.Start();
        }

        public void OpenSettings()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Opening settings");
            Process SettingsProcess = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C start ms-settings:";
            SettingsProcess.StartInfo = startInfo;
            SettingsProcess.Start();
            // SettingsProcess.WaitForExit();
        }



        public void ListenKurwa()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak("Listening sir");
        }
        //public void CalledForWrong()
        //{
        //    Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
        //    Speaker.Speak("I haven't recognized this command, the proper one sounds - Help me Stephen - try again please");
        //}
        //public void noOptionAvailable()
        //{
        //    Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));

        //}

        public void askForFilename()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));

            Speaker.Speak("What is the file that you require my lord?");
        }

        public void searchFor()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));

            Speaker.Speak("What do you want me to search for?");
        }

        public void currentTime()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));

            string timeString = DateTime.Now.ToShortTimeString();
            PromptBuilder timeBuilder = new PromptBuilder();
            timeBuilder.Culture = CultureInfo.GetCultureInfo("en-US");
            timeBuilder.StartVoice(VoiceGender.Male, VoiceAge.NotSet, 0);
            timeBuilder.AppendText("The time is: ");
            timeBuilder.AppendSsmlMarkup(" <say-as interpret-as=\"time\">" + timeString + "</say-as>");
            timeBuilder.EndVoice();

            Speaker.Speak(timeBuilder);
        }

        public void currentDate()
        {


            string dateString = DateTime.Now.ToShortDateString();
            PromptBuilder dateBuilder = new PromptBuilder();
            dateBuilder.Culture = CultureInfo.GetCultureInfo("en-US");
            dateBuilder.StartVoice(VoiceGender.Male, VoiceAge.NotSet, 0);
            dateBuilder.AppendText("The date is: ");
            dateBuilder.AppendSsmlMarkup("<say-as interpret-as=\"date_md\">" + dateString + "</say-as>");
            dateBuilder.EndVoice();
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            Speaker.Speak(dateBuilder);
        }

        public void currentWeather()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            WeatherForecast forecast = new WeatherForecast();

            Speaker.Speak(forecast.GetForecast());
        }

        public void hello()
        {
            Speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));

            DateTime timeNow = DateTime.Now;
            string username = Environment.UserName;
            if (timeNow.Hour >= 0 && timeNow.Hour < 12)
            {
                Speaker.Speak("Good morning " + username);
            }
            else if (timeNow.Hour >= 12 && timeNow.Hour < 18)
            {
                Speaker.Speak("Good afternoon " + username);
            }
            else if (timeNow.Hour >= 18 && timeNow.Hour < 24)
            {
                Speaker.Speak("Good evening " + username);
            }
        }
    }
}
