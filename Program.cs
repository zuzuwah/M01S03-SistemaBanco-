using M01S03;

List<Carro> ListaDeCarros = new List<Carro>();
string opcao;

do
{
    Console.WriteLine("Bem vindo ao Estacionamento Pare Aqui, escolha uma opção:");
    Console.WriteLine("1 - Cadastrar Carro ");
    Console.WriteLine("2 - Marcar Entrada");
    Console.WriteLine("3 - Marcar Saída");
    Console.WriteLine("4 - Consultar Histórico");
    Console.WriteLine("5 - Sair");
    Console.WriteLine("");
    opcao = Console.ReadLine();

    if (opcao == "1")
    {
        CadastrarCarro();
    }
    else if (opcao == "2")
    {
        MarcarEntrada();
    }
    else if (opcao == "3")
    {
        MarcarSaida();
    }
    else if (opcao == "4")
    {
        ConsultarHistorico();
    }
    Console.WriteLine("Tecle Enter para continuar");
    Console.ReadLine();
} while (opcao != "5");


void CadastrarCarro()
{
    Carro carro = new Carro();
    Console.WriteLine("Digite a placa do carro: ");
    carro.Placa = Console.ReadLine();
    Console.WriteLine("Digite o modelo do carro: ");
    carro.Modelo = Console.ReadLine();
    Console.WriteLine("Digite a cor do carro: ");
    carro.Cor = Console.ReadLine();
    Console.WriteLine("Digite a marca do carro: ");
    carro.Marca = Console.ReadLine();
    ListaDeCarros.Add(carro);
}


void MarcarEntrada()
{
    Carro carro = ObterCarro();
    if (carro == null)
    {
        Console.WriteLine("Placa não encontrada, favor rever cadastro.");
        return;
    }
    else
    {
        if (carro.extratoTickets.Count == 0)
        {
            Ticket novoTicket = new Ticket();
            novoTicket.Entrada = DateTime.Now;
            novoTicket.Ativo = true;
            Console.WriteLine($"Placa: {carro.Placa} || Entrada: {novoTicket.Entrada}.");
            carro.extratoTickets.Add(novoTicket);
        }
        else
        {
            for (int index = 0; index < carro.extratoTickets.Count(); index++)
            {
                if (carro.extratoTickets[index].Ativo == false)
                {
                    Ticket novoTicket = new Ticket();
                    novoTicket.Entrada = DateTime.Now;
                    novoTicket.Ativo = true;
                    Console.WriteLine($"Placa: {carro.Placa} || Entrada: {novoTicket.Entrada}.");
                    carro.extratoTickets.Add(novoTicket);
                }
                else
                {
                    Console.WriteLine("Ticket está ativo.");
                }
            }
        }
    }
}
void MarcarSaida()
{ 
    Carro carro = ObterCarro();
    if (carro.extratoTickets.Count == 0)
    {
        Console.WriteLine("Veículo não encontrado.");
    }
    for (int index = 0; index < carro.extratoTickets.Count(); index++)
    {
        if (carro.extratoTickets[index].Ativo == true)
        {
            carro.extratoTickets[index].Saida = DateTime.Now;
            carro.extratoTickets[index].Ativo = false;
            Console.WriteLine($"Placa: {carro.Placa} || Saída: {carro.extratoTickets[index].Saida} || Valor a pagar: {carro.extratoTickets[index].CalcularValor()}.");
        }
    }
}

void ConsultarHistorico()
{
    Carro carro = ObterCarro();
    if (carro.extratoTickets.Count == 0)
    {
        Console.WriteLine("Veículo não encontrado.");
    }
    for (int index = 0; index < carro.extratoTickets.Count(); index++)
    {
        if (carro.extratoTickets[index].Ativo == true)
        {
            Console.WriteLine($"Entrada veículo {carro.Placa} registrada.");
        }
        else
        {
            Console.WriteLine($"Placa: {carro.Placa} || Entrada: {carro.extratoTickets[index].Entrada} || Saída: {carro.extratoTickets[index].Saida} || Pagamento: {carro.extratoTickets[index].CalcularValor()}.");
        }
    }
}

Carro ObterCarro()
{
    Console.WriteLine("Digite a placa do carro: ");
    string buscarPlaca = Console.ReadLine();


    for (int index = 0; index < ListaDeCarros.Count(); index++)
    {
        if (buscarPlaca == ListaDeCarros[index].Placa)
        {
            return ListaDeCarros[index];
        }
    }
    return null;
}
