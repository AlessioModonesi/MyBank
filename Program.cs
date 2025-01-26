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
        public static string utente, email, passwd, error, IBAN, data, text, tipologia, codice, cc, problema;
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

        public static void CreateFile(ref string utente, ref string email, ref string passwd) //questa funzione crea il file dell'utente appena registrato
        {
            string data = $"Nome: {utente} \nEmail: {email} \nPassword: {passwd} \nNumero: * \nPIN: * \nCVV: * \nIBAN: * \nSaldo: * � \nEntrate: * � \nUscite: * �";
            using (StreamWriter a = File.CreateText($"{MainPath}\\File\\Data\\Utenti\\{utente}.txt")) { }
            File.AppendAllText(MainPath + $"\\File\\Data\\Utenti\\{utente}.txt", data);
        }

        public static int Search(ref string email, ref string passwd) //questa funzione ricerca tra i file di testo e comunica se una mail e una passwd compaiono tra questi
        {
            exist = false;
            for (int i = 0; i < readerEmail.Length; i++)
            {
                if (email == readerEmail[i] && passwd == readerPass[i]) //se mail e password compaiono nei file
                {
                    exist = true;
                    return pnt = i;
                }
            }
            return 0;
        }

        public static void LeggiUtente(ref string utente) //questa funzione legge i dati di ogni utente, quando esso si logga
        {
            readerData = File.ReadAllLines(MainPath + $"\\File\\Data\\Utenti\\{utente}.txt");
        }

        public static void SalvaProblema() //questa funzione salva su file gi estremi dei bonifici
        {
            string str = $"\n{email}: {problema}";
            File.AppendAllText(MainPath + "\\File\\Data\\Record\\aiuto.txt", str);
            email = null; problema = null;
        }

        public static void EffettuaBonifico() //questa funzione salva su file gi estremi dei bonifici
        {
            string str = $"\n{utente}, {IBAN}, {importo}, {data}, {text}";
            File.AppendAllText(MainPath + "\\File\\Data\\Record\\bonifici.txt", str);
            utente = null; IBAN = null; importo = 0; data = null; text = null;
        }

        public static void EffettuaBollettino() //questa funzione salva su file gi estremi dei bollettini
        {
            string str = $"\n{tipologia}, {codice}, {cc}, {importo}";
            File.AppendAllText(MainPath + "\\File\\Data\\Record\\bollettini.txt", str);
            tipologia = null; codice = null; cc = null; importo = 0;
        }

        public static void CambiaNome(ref string utente) //questa funzione consentir� di modificare il nome dei vari utenti nei file.txt
        {
            ReadFile();
            readerName[pnt] = utente;
            File.WriteAllText(MainPath + "\\File\\Login\\name.txt", null);
            for (int i = 0; i < readerName.Length; i++)
            {
                File.AppendAllText(MainPath + "\\File\\Login\\name.txt", readerName[i]);
                File.AppendAllText(MainPath + "\\File\\Login\\name.txt", "\n");
            }
            ReadFile(); //rileggo il file
        }

        public static void CambiaPasswd(ref string passwd) //questa funzione consentir� di  modificare la password dei vari utenti nei file.txt
        {
            ReadFile();
            readerPass[pnt] = passwd;
            File.WriteAllText(MainPath + "\\File\\Login\\passwd.txt", null);
            for (int i = 0; i < readerPass.Length; i++)
            {
                File.AppendAllText(MainPath + "\\File\\Login\\passwd.txt", readerPass[i]);
                File.AppendAllText(MainPath + "\\File\\Login\\passwd.txt", "\n");
            }
            ReadFile(); //rileggo il file
        }

        public static void TogliSaldo() //questa funzione (ancora inutilizzata) consentir� di modificare il saldo dei vari utenti nei file.txt
        {

        }

        public static void AggiungiSaldo() //questa funzione (ancora inutilizzata) consentir� di modificare il saldo dei vari utenti nei file.txt
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
