//Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario può verificare
//
//i dati dei clienti registrati:
//cognome,
//nome,
//email,
//recapito telefonico,

//Il bibliotecario può effettuare dei prestiti ai suoi clienti registrati, attraverso il sistema, sui documenti che sono di vario tipo (libri, DVD).
//
//I documenti sono caratterizzati da:
//un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
//titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).
//
//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
//Il bibliotecario deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
//Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un cliente.
//Mi raccomando, prima di buttarvi sul codice fate qualche schema per capire le entità principali e le loro relazioni / eredità.

//create Biblioteca
//class Biblioteca
public class Biblioteca
{
    //properties
    public List<Utente> Utenti { get; }
    public List<Libro> Libri { get; }
    public List<Dvd> Dvd { get; }
    public List<Prestito> Prestiti { get; }


    //costructor
    public Biblioteca()
    {
        Utenti = new List<Utente>();
        Utenti.Add(new Utente("Rossi", "Mario", "mariorossi@gmail.com", 334303045));
        Utenti.Add(new Utente("Rossi", "Maria", "maria2rossi@gmail.com", 334303045));
        Utenti.Add(new Utente("DaNorcia", "Brancaleone", "brancabranca@gmail.com", 334364045));
        Utenti.Add(new Utente("Scacchi", "Andrea", "andreascacchi@gmail.com", 331324045));

        Libri = new List<Libro>();
        Libri.Add(new Libro("Le 13 vite e mezzo del capitano Orso Blu", 1999, "Romanzo", false, new Random().Next(0, 101), "Walter Moers", "9788804577027", 304));
        Libri.Add(new Libro("Cronache del Mondo Emerso", 2006, "Fantasy", false, new Random().Next(0, 101), "Licia Troisi", "9788868366216", 536));
        Libri.Add(new Libro("1984", 1949, "Distopico", true, new Random().Next(0, 101), "George Orwell", "9788804333746", 328));

        Dvd = new List<Dvd>();
        Dvd.Add(new Dvd("Avatar", 2008, "Fantascienza", true, new Random().Next(0, 101), "David Cameron", "9788804577027", 304));
        Dvd.Add(new Dvd("Natale in India", 2013, "Commedia", false, new Random().Next(0, 101), "Qualcuno", "9788868366216", 436));
        Dvd.Add(new Dvd("Il miglio verde", 1988, "Thriller psicologico", true, new Random().Next(0, 101), "Thomas Harris", "9788804333746", 388));

        Prestiti = new List<Prestito>();
        Prestiti.Add(new Prestito("Le 13 vite e mezzo del capitano Orso Blu", "Andrea Scacchi", "05/11/22", "07/11/22"));
        Prestiti.Add(new Prestito("Avatar", "Andrea Scacchi", "05/11/22", "07/11/22"));
        Prestiti.Add(new Prestito("Cronache del Mondo Emerso", "Brancaleone DaNorcia", "05/11/22", "07/11/22"));
        Prestiti.Add(new Prestito("Natale in India", "Mario Rossi", "05/11/22", "07/11/22"));
    }


    public void Prestito()
    {
        Console.WriteLine("Vuoi cercare un libro o un dvd? [libro/dvd] ");
        string userInput = Console.ReadLine();

        if (userInput == "libro")
        {
            Console.WriteLine("Scrivi il codice o il titolo del libro da cercare: ");
            string userInputLibro = Console.ReadLine();

            foreach (Libro libro in Libri)
            {
                if (userInputLibro == libro.Titolo || userInputLibro == libro.Isbn)
                {
                    if (libro.Stato == true)
                    {
                        Console.WriteLine("il libro ricercato è disponibile");
                        EffettuaPrestito(userInputLibro);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("il libro non è disponibile");
                    }
                }
            }

        }
        else if (userInput == "dvd")
        {
            Console.WriteLine("Scrivi il codice o il titolo del dvd da cercare: ");
            string userInputDvd = Console.ReadLine();

            foreach (Dvd dvd in Dvd)
            {
                if (userInputDvd == dvd.Titolo || userInputDvd == dvd.Codice)
                {
                    if (dvd.Stato == true)
                    {
                        Console.WriteLine("il dvd ricercato è disponibile");
                        EffettuaPrestito(userInputDvd);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("il dvd ricercato non è disponibile");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("inserisci un valore corretto");
            Prestito();
        }
    }

    public void EffettuaPrestito(string userInputDoc)
    {
        Console.WriteLine("Vuoi prenderlo in prestito? [si/no]");
        string userDocPrestito = Console.ReadLine();
        if (userDocPrestito == "si")
        {
            Console.WriteLine("Inserisci il tuo nome e cognome");
            string nomeUser = Console.ReadLine();
            Console.WriteLine("Inserisci la data di inizio prestito");
            string inizioPrestito = Console.ReadLine();
            Console.WriteLine("Inserisci la data di fine prestito");
            string finePrestito = Console.ReadLine();
            Prestito prestito = new Prestito(userInputDoc, nomeUser, inizioPrestito, finePrestito);
            Console.WriteLine("L'utente " + prestito.NomeUtente + " ha effettuato il prestito di: " + prestito.Nome + " dal: " + prestito.InizioPrestito + " al: " + prestito.FinePrestito);
            Prestiti.Add(prestito);
        }
        else
        {
            Prestito();
        }
    }

    public void RicercaPrestiti()
    {
        Console.WriteLine("Stai cercando i prestiti associati a quale utente? Inserire nome e cognome");
        string inputPrestito = Console.ReadLine();
        bool presente = false;
        foreach (Prestito prestito in Prestiti)
        {
            if (inputPrestito == prestito.NomeUtente)
            {
                presente = true;
            }

        }
        if (presente == true)
        {
            Console.WriteLine("I prestiti associati all'utente selezionato sono:");
            foreach (Prestito prestito in Prestiti)
            {
                if (inputPrestito == prestito.NomeUtente)
                {
                    Console.WriteLine(prestito.Nome + ", in prestito dal: " + prestito.InizioPrestito + " al: " + prestito.FinePrestito);
                }
            }
        }
        else
        {
            Console.WriteLine("Non sono presenti prestiti associati all'utente richiesto");
        }
    }
}