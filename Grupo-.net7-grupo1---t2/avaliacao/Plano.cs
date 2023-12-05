namespace avaliacao;

public class Plano
{
    public string Título { get; set; }

    public double Valormensal { get; set; }

    public Plano (string titulo, double valormensal)
    {
        Título = titulo;
        Valormensal = valormensal;
    }

    

}
