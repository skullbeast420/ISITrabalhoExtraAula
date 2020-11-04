using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

namespace Ex_3_
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Metodos.GetWeatherType();
            Metodos.GetLocais();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }

    public class Metodos
    {

        static PrevisaoIPMA obj = new PrevisaoIPMA();

        static Dictionary<int, string> listaLocais = new Dictionary<int, string>();

        static Dictionary<int, string> listaTiposWeather = new Dictionary<int, string>();

        //Desserializa o ficheiro "weatherTypes.json" para uma var "obj" que será retornado
        static WeatherType LerFicheiroPrevisao()
        {
            string jsonString = null;
            using (StreamReader reader = new StreamReader("weatherTypes.json"))
                jsonString = reader.ReadToEnd();

            WeatherType obj = JsonConvert.DeserializeObject<WeatherType>(jsonString);
            return obj;
        }

        public static void GetLocais()
        {

            // Variáveis auxiliares
            string line;

            //Abre o ficheiro "locais.csv" em modo leitura
            using (StreamReader t = new StreamReader("locais.csv"))
            {

                //Ciclo para percorrer todas as linhas do ficheiro
                while ((line = t.ReadLine()) != null)
                {

                    bool foundmatch;
                    //Função executada para ignorar a primeira linha do ficheiro
                    foundmatch = Regex.IsMatch(line, "^[0-9]+,[0-9],[0-9]+,[0-9]+,[A-Z]{3},[A-Z][a-z]+$");

                    if (!foundmatch) continue;

                    //Cria os matches com a expressão fornecida
                    MatchCollection matches = Regex.Matches(line, "^[0-9]+,[0-9],[0-9]+,[0-9]+,[A-Z]{3},[A-Z][a-z]+$", RegexOptions.Multiline);

                    //Separa a string em sub-strings com o carater de separação sendo ","
                    Regex teste = new Regex(",");
                    string[] splits = teste.Split(line);

                    listaLocais.Add(Int32.Parse(splits[0]), splits[5]);
                }
            }

        }

        //Usa um objeto com a informação dos tipos de tempo e adiciona-os ao Dictionary listaTiposWeather
        public static void GetWeatherType()
        {

            var obj = LerFicheiroPrevisao();
            int count = 0;

            TiposTempo varTeste = new TiposTempo();

            foreach (TiposTempo teste in obj.Data)
            {

                //listaTiposWeather.Add(obj.Data[Int32.Parse(teste.ToString())].idWeatherType, obj.Data[Int32.Parse(teste.ToString())].descIdWeatherTypePT);
                listaTiposWeather.Add(obj.Data[count].idWeatherType, obj.Data[count].descIdWeatherTypePT);
                count++;

            }

        }

        public static void AddLocaisListbox(ListBox locais)
        {

            foreach (KeyValuePair<int, string> entry in listaLocais)
            {

                locais.Items.Add(entry.Value);

            }

        }

        public static void SelectLocal(string selectedItem)
        {

            foreach (KeyValuePair<int, string> entry in listaLocais)
            {

                if (selectedItem == entry.Value)
                {

                    string jsonString = null;
                    using (StreamReader reader = new StreamReader("data/" + entry.Key + ".json"))
                        jsonString = reader.ReadToEnd();

                    obj = JsonConvert.DeserializeObject<PrevisaoIPMA>(jsonString);

                    obj.Local = entry.Value;

                    break;

                }

            }

        }

        public static void GiveNameLocal(Label teste) { teste.Text = obj.Local; }

        public static void GiveNameDate(Label teste, int index) { teste.Text = obj.Data[index].forecastDate; }

        public static void GiveNameWeatherType(Label teste, int index)
        {

            foreach (KeyValuePair<int, string> entry in listaTiposWeather)
            {

                if (obj.Data[index].idWeatherType == entry.Key)
                {

                    teste.Text = entry.Value;
                    break;

                }

            }

        }

        public static void GiveNameTmin(Label teste, int index) { teste.Text = obj.Data[index].tMin; }

        public static void GiveNameTmax(Label teste, int index) { teste.Text = obj.Data[index].tMax; }

        public static void GiveNameWind(Label teste, int index) { teste.Text = obj.Data[index].predWindDir; }

        public static void GiveNamePrec(Label teste, int index) { teste.Text = obj.Data[index].classPrecInt.ToString(); }

    }
}
