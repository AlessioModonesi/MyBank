using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MyBank
{
    public class Program
    {
        public static string MainPath = Environment.CurrentDirectory;
        public static int row = 1, pnt = 0, ricarica, nEntrate = 3, nUscite = 2;
        public static double importo = 0;
        public static string[] readerName = new string[row];
        public static string[] readerEmail = new string[row];
        public static string[] readerPass = new string[row];
        public static string[] readerData = new string[row];
        public static string utente, email, passwd, error, IBAN, data, text, tipologia, codice, cc;
        public static bool exist = false;

        public static void Main(string[] args)
        {
            ReadFile();
            CreateHostBuilder(args).Build().Run();
        }

        public static void ReadFile() //questa funzione legge i vari file di login e di salvataggio dati
        {
            readerName = null; readerEmail = null; readerPass = null;
            readerName = File.ReadAllLines(MainPath + $"\\File\\Login\\name.txt");
            readerEmail = File.ReadAllLines(MainPath + $"\\File\\Login\\email.txt");
            readerPass = File.ReadAllLines(MainPath + $"\\File\\Login\\passwd.txt");
        }

        public static void WriteFile() //questa funzione scrive su file le credenziali dell'utente appena registrato
        {
            if (utente != null && email != null && passwd != null)
            {
                string str1 = $"\n{utente}";
                File.AppendAllText(MainPath + "\\File\\Login\\name.txt", str1);
                string str2 = $"\n{email}";
                File.AppendAllText(MainPath + "\\File\\Login\\email.txt", str2);
                string str3 = $"\n{passwd}";
                File.AppendAllText(MainPath + "\\File\\Login\\passwd.txt", str3);
                utente = null; email = null; passwd = null;
            }
        }

        public static int Search(ref string email, ref string passwd) //questa funzione ricerca tra i file di testo e comunica se una mail e una passwd compaiono tra questi
        {
            for (int i = 0; i < readerEmail.Length; i++)
            {
                if (email == readerEmail[i] && passwd == readerPass[i]) //se mail e password compaiono nei file
                {
                    exist = true;
                    return pnt = i;
                }
            }
            return -1;
        }

        public static void LeggiUtente() //questa funzione legge i dati di ogni utente, quando esso si logga
        {
            readerData = File.ReadAllLines(MainPath + $"\\File\\Data\\admin.txt");
        }

        public static void EffettuaBonifico() //questa funzione salva su file gi estremi dei bonifici
        {
            string str = $"\n{utente}, {IBAN}, {importo}, {data}, {text}";
            File.AppendAllText(MainPath + "\\File\\Data\\bonifici.txt", str);
            utente = null; IBAN = null; importo = 0; data = null; text = null;
        }

        public static void EffettuaBollettino() //questa funzione salva su file gi estremi dei bollettini
        {
            string str = $"\n{tipologia}, {codice}, {cc}, {importo}";
            File.AppendAllText(MainPath + "\\File\\Data\\bollettini.txt", str);
            tipologia = null; codice = null; cc = null; importo = 0;
        }

        public static void CambiaNome(ref string utente) //questa funzione consentirà di modificare il nome dei vari utenti nei file.txt
        {
            ReadFile();
            File.WriteAllText(MainPath + "\\File\\Login\\name.txt", utente); //sovrascrivo il vecchio nome
            ReadFile(); //rileggo il file
            //manca da modificare il nome nel file {utente}.txt
        }

        public static void CambiaPasswd(ref string passwd) //questa funzione consentirà di  modificare la password dei vari utenti nei file.txt
        {
            ReadFile();
            File.WriteAllText(MainPath + "\\File\\Login\\passwd.txt", passwd); //sovrascrivo la vecchia passwd
            ReadFile(); //rileggo il file
            //manca da modificare la passwd nel file {utente}.txt
        }

        public static void TogliSaldo() //questa funzione (ancora inutilizzata) consentirà di modificare il saldo dei vari utenti nei file.txt
        {

        }

        public static void AggiungiSaldo() //questa funzione (ancora inutilizzata) consentirà di modificare il saldo dei vari utenti nei file.txt
        {

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
