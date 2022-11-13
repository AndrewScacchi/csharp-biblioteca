//class Utente

public class Utente
{
    //properties
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Telefono { get; set; }

    //costructor
    public Utente(string cognome, string nome, string email, int telefono)
    {
        Cognome = cognome;
        Nome = nome;
        Email = email;
        Telefono = telefono;
    }
}
