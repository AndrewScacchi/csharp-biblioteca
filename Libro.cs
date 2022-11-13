//subclass Libro
public class Libro : Documento
{
    //properties
    public string Isbn { get; set; }
    public int Pagine { get; set; }

    //costructor
    public Libro(string titolo, int anno, string settore, bool stato, int scaffale, string autore, string isbn, int pagine) : base(titolo, anno, settore, stato, scaffale, autore)
    {
        Isbn = isbn;
        Pagine = pagine;
    }
}
