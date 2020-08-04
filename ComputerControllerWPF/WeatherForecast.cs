using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Windows.Controls;
using ComputerControllerWPF;

namespace ComputerControllerWPF
{
    public class WeatherForecast
    {
        string city, temp, tempMin, tempMax, humidity, pressure, feels_like, unit, windSpeed, windDirection, windName, windDirName, cloudsValue, cloudsName, precipitation, lastupdate, ludate, lutime;
        public string toDisplay;
        private const string API_KEY = "8ba9dcfae07826572e1e3536bc9cbf51";
        private const string url = "http://api.openweathermap.org/data/2.5/weather?q=Wroc%C5%82aw&mode=xml&units=metric&APPID=8ba9dcfae07826572e1e3536bc9cbf51";

        public string GetForecast()
        {
            using (WebClient client = new WebClient())
            {
                string XMLString = client.DownloadString(url);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(XMLString);

                XmlNode locationNode = xmlDocument.SelectSingleNode("current");
                XmlNode cityNode = locationNode.SelectSingleNode("city");
                city = cityNode.Attributes["name"].Value;
                city = city.Replace('ł', 'l');
                XmlNode tempNode = locationNode.SelectSingleNode("temperature");
                temp = tempNode.Attributes["value"].Value;
                tempMin = tempNode.Attributes["min"].Value;
                tempMax = tempNode.Attributes["max"].Value;
                unit = tempNode.Attributes["unit"].Value; //C
                feels_like = locationNode.SelectSingleNode("feels_like").Attributes["value"].Value; //C
                humidity = locationNode.SelectSingleNode("humidity").Attributes["value"].Value; //%
                pressure = locationNode.SelectSingleNode("pressure").Attributes["value"].Value; //hPa
                XmlNode windNode = locationNode.SelectSingleNode("wind");
                windSpeed = windNode.SelectSingleNode("speed").Attributes["value"].Value; //m/s
                windName = windNode.SelectSingleNode("speed").Attributes["name"].Value;
                windDirection = windNode.SelectSingleNode("direction").Attributes["value"].Value; // 0-360.
                windDirName = windNode.SelectSingleNode("direction").Attributes["name"].Value; // north, south, south-southwest etc
                cloudsName = locationNode.SelectSingleNode("clouds").Attributes["name"].Value; //few clouds etc.
                cloudsValue = locationNode.SelectSingleNode("clouds").Attributes["value"].Value; // 0-100
                precipitation = locationNode.SelectSingleNode("precipitation").Attributes["mode"].Value; //yes / no
                lastupdate = locationNode.SelectSingleNode("lastupdate").Attributes["value"].Value;
                string[] updates = new string[2];
                updates = lastupdate.Split('T');
                ludate = updates[0];
                lutime = updates[1];
                toDisplay = String.Format("The current weather for Wroclaw is:" +
                    " Temperature: {0} degrees Celsius, The minimum temperature today was: {1} degrees Celsius, the maximum temperature today was: {2} degrees Celsius." +
                    " The temperature feels like it was: {3} degrees Celsius." +
                    " Current humidity is: {4} percent." +
                    " Current pressure is: {5} hectoPascals." +
                    " Wind is a {6} that blows from {7} with the speed of {8} meters per second. " +
                    " When it comes to clouds, it's {9}," +
                    " Last update took place at {10}", temp, tempMin, tempMax, feels_like, humidity, pressure, windName, windDirName, windSpeed, cloudsName, lutime);

                return toDisplay;
            }
        }
    }
}
