//subclass Dvd
public class Dvd : Documento
{
    //properties
    public string Codice { get; set; }
    public int Durata { get; set; }

    //costructor
    public Dvd(string titolo, int anno, string settore, bool stato, int scaffale, string autore, string codice, int durata) : base(titolo, anno, settore, stato, scaffale, autore)
    {
        Codice = codice;
        Durata = durata;
    }
}
