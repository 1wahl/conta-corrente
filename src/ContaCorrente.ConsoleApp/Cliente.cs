namespace ContaCorrente.ConsoleApp;

internal class Cliente
{
    public string NomeCliente;
    public string SobrenomeCliente;
    public string Cpf;

    public Cliente(string nomeCliente, string sobrenomeCliente, string cpf)
    {
        NomeCliente = nomeCliente;
        SobrenomeCliente = sobrenomeCliente;
        Cpf = cpf;
    }
}
