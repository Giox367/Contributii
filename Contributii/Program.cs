using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Contributii
{
    internal class Program
    {
        static void Main(string[] args)
        {
          


           
           
            Inserimentodati1();
            void Inserimentodati1() // Qui utilizzo il costruttore con parametri
            {
                Console.WriteLine("inserisci il nome del contribuente");
                string Noome = Console.ReadLine();
                Console.WriteLine("inserisci il cognome del contribuente");
                string Coognome = Console.ReadLine();
                Console.WriteLine("inserisci la data di nascita");
                DateTime DataaDiNascita = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("inerisci il codice fiscale");
                string CodiceeFiscale = Console.ReadLine();
                Console.WriteLine("inserisci il sesso");
                string Seesso = Console.ReadLine();
                Console.WriteLine("inserisci il comune di residenza");
                string ComuneeDiResidenza = Console.ReadLine();
                Console.WriteLine("inserisci il reddito annuale");
                double Reddiito = double.Parse(Console.ReadLine());
                Contribuente t = new Contribuente(Noome, Coognome, DataaDiNascita, CodiceeFiscale, ComuneeDiResidenza, Seesso, Reddiito);
                t.ContributoDaVersare(Reddiito);
                t.ScriviDati();
                Contribuenti.Inseriscinlista(t);
                Contribuenti.leggilista();
                Console.ReadLine();
            }

            void inserimentodati2() // Qui utilizzo il costruttore con firma (), non richiamo il metodo nel main per evitare ridondanza
            {
                Contribuente c = new Contribuente();
                Console.WriteLine("Inserisci il nome del contribuente");
                c.Nome = Console.ReadLine();
                Console.WriteLine("inserisci il cognome del contribuente");
                c.Cognome = Console.ReadLine();
                Console.WriteLine("inserisci la data di nascita");
                c.DataDiNascita = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("inerisci il codice fiscale");
                c.CodiceFiscale = Console.ReadLine();
                Console.WriteLine("inserisci il sesso");
                c.Sesso = Console.ReadLine();
                Console.WriteLine("inserisci il comune di residenza");
                c.ComuneDiResidenza = Console.ReadLine();
                Console.WriteLine("inserisci il reddito annuale");
                c.RedditoAnnuale = double.Parse(Console.ReadLine());
                c.ContributoDaVersare(c.RedditoAnnuale);
                c.ScriviDati();
                Contribuenti.Inseriscinlista(c);
                Contribuenti.leggilista();
                Console.ReadLine();
            }
        }

        }
        public static class Contribuenti {
            public static List<Contribuente> listacontribuenti = new List<Contribuente>();
            public static List<Contribuente> Inseriscinlista(Contribuente c)
            {
                listacontribuenti.Add(c);
                return listacontribuenti;
            }
            public static void leggilista(){
                foreach (Contribuente b in listacontribuenti)
                {
                    Console.WriteLine(b.Nome);
                    Console.WriteLine(b.Cognome);
                    Console.WriteLine(b.CodiceFiscale);
                    Console.WriteLine(b.DataDiNascita);
                    Console.WriteLine(b.Sesso);
                    Console.WriteLine(b.ComuneDiResidenza);
                    Console.WriteLine(b.RedditoAnnuale);
                }
            }
            

        }
        public class Contribuente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataDiNascita { get; set; }
            public  string CodiceFiscale { get; set; }
            public string Sesso { get; set; }
            public string ComuneDiResidenza { get; set; }

            public double RedditoAnnuale { get; set; }

            public Contribuente() { }
            public Contribuente(string nome, string cognome, DateTime dataDiNascita, string codiceFiscale, string sesso, string comuneDiResidenza, double redditoAnnuale)
            {
                Nome = nome;
                Cognome = cognome;
                DataDiNascita = dataDiNascita;
                CodiceFiscale = codiceFiscale;
                Sesso = sesso;
                ComuneDiResidenza = comuneDiResidenza;
                RedditoAnnuale = redditoAnnuale;
            }   
            public double ContributoDaVersare(double RedditoAnnuale)
            {
                double contributo;
                if (RedditoAnnuale <= 15.000)
                {
                    contributo = (RedditoAnnuale * 23) / 100;
                return contributo;
                }else if(RedditoAnnuale > 15001 && RedditoAnnuale < 28000)
                {
                    contributo = 3450 + (((RedditoAnnuale-15000) * 27) / 100);
                    return contributo;
                }else if(RedditoAnnuale >= 28001 && RedditoAnnuale < 55000)
                {
                    contributo = 6960 + (((RedditoAnnuale - 28000) * 38) / 100);
                    return contributo;
                }else if (RedditoAnnuale > 55001 && RedditoAnnuale < 75000)
                {
                    contributo = 17220 + (((RedditoAnnuale - 28000) * 41) / 100);
                    return contributo;
                }else 
                
                    contributo = 25420 + (((RedditoAnnuale - 28000) * 43) / 100);
                    return contributo;
                    

                  
            }
            public void ScriviDati()
            {
                Console.WriteLine("");
                Console.WriteLine("=============================");

                Console.WriteLine("Calcolo dell'imposta da versare");
                Console.WriteLine($"Contribuente: {Nome}");
                Console.WriteLine($"Nato il {DataDiNascita}{Sesso}");
                Console.WriteLine($"Residente in {ComuneDiResidenza}");
                Console.WriteLine($"Codice Fiscale: {CodiceFiscale}");
                Console.WriteLine("");
                Console.WriteLine($"Reddito Dichiarato {RedditoAnnuale}");
                Console.WriteLine("");
                Console.WriteLine($"IMPOSTA DA VERSARE {ContributoDaVersare(RedditoAnnuale)}");
                Console.ReadLine();
            }
         
            }
    
}
