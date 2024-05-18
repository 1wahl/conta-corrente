namespace ContaCorrente.ConsoleApp;

public class Movimentacao
{
    public double Valor;
    // public ContaCorrente ContaDestinataria;
    public string TipoTransferencia;

    public Movimentacao(double valor, string tipoTransferencia)
    {
        Valor = valor;
        TipoTransferencia = tipoTransferencia;
    }
}
