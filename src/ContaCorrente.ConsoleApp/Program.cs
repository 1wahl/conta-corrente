namespace ContaCorrente.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        ContaCorrente p1 = new ContaCorrente("Pedro", "Goulart", "123.654.345-76", 500.00, 200.00, "9264", "Física");
        ContaCorrente p2 = new ContaCorrente("Pedro2", "Goulart2", "234.543.236.43", 150.00, 100.00, "6453", "Física");
        
        Console.WriteLine("-- Dados Pessoa 1 --");
        Console.WriteLine(p1);

        double valorPedroSaque = 20;

        if (p1.Sacar(valorPedroSaque))
        {
            p1.Sacar(valorPedroSaque);
            Console.WriteLine("-- Saque Pessoa 1 --");
            Console.WriteLine(p1);
        }

        Console.WriteLine("-- Dados Pessoa 2 --");
        Console.WriteLine(p2);

        double valorPedro2Saque = 500.00;

        if (p1.Sacar(valorPedro2Saque))
        {
            p1.Sacar(valorPedro2Saque);
            Console.WriteLine("-- Saque Pessoa 2");
            Console.WriteLine(p2);
        }

        double valorTransferencia = 10.00;
        p1.Transferir(valorTransferencia, p2);

        Console.WriteLine("-- Extrato de transações pessoa 1 --");
        p1.Depositar(200);

        Movimentacao[] movimentacoes = p1.Extrato();

        for (int i = 0; i < movimentacoes.Length; i++)
        {
            Movimentacao movimentacao = movimentacoes[i];

            if (movimentacao == null)
            {
                break;
            }
            
            Console.WriteLine($"{i + 1}ª Transação: {movimentacao.TipoTransferencia} R${movimentacao.Valor.ToString("F2")}");
        }

        Console.ReadKey();
    }
}
