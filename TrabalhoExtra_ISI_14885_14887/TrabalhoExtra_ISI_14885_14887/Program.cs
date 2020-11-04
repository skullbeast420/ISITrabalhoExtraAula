using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Ex_3_
{
    class Program
    {
        static Dictionary<int, string> listaLocais = new Dictionary<int, string>();

        static void CarregaLocais()
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

        static PrevisaoIPMA LerFicheiroPrevisao(int globalIdLocal)
        {
            string jsonString = null;
            using (StreamReader reader = new StreamReader("data/" + globalIdLocal + ".json"))
                jsonString = reader.ReadToEnd();

            PrevisaoIPMA obj = JsonConvert.DeserializeObject<PrevisaoIPMA>(jsonString);
            obj.Local = listaLocais[obj.GlobalIdLocal];
            return obj;
        }

        static void Main(string[] args)
        {

            string currentPathFileJson = null;
            string currentPathFileXML = null;
            string toBePathJson = null;
            string toBePathXML = null;

            // Variáveis
            PrevisaoIPMA previsao;
            int idGlobal;
            string json;

            // Carregar locais
            CarregaLocais();

            foreach (string file in Directory.GetFiles("data/"))
            {
                if (!int.TryParse(Path.GetFileNameWithoutExtension(file), out idGlobal)) continue;

                toBePathJson = $"./output/{idGlobal}-detalhe.json";
                toBePathXML = $"./output/{idGlobal}-detalhe.xml";
                currentPathFileJson = @"./" + idGlobal + "-detalhe.json";
                currentPathFileXML = @"./" + idGlobal + "-detalhe.xml";

                previsao = LerFicheiroPrevisao(idGlobal);
                json = JsonConvert.SerializeObject(previsao);

                if (!File.Exists(toBePathJson))
                {

                    File.WriteAllText(idGlobal + "-detalhe.json", json);
                    File.Move(currentPathFileJson, toBePathJson);

                }

                if (!File.Exists(toBePathXML))
                {

                    XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "main");
                    doc.Save(idGlobal + "-detalhe.xml");
                    File.Move(currentPathFileXML, toBePathXML);

                }

            }
        }
    }
}
