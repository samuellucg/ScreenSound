// Projeto Screen Sound

string mensagemDeBoasVindas = "\nBem vindo ao Screen Sound!"; // Mensagem simples para boas-vindas ao iniciar o programa

// Definição de um dicionário para armazenar bandas e suas respectivas notas, facilita o acesso rápido e a organização das informações
Dictionary<string, List<int>> dcBandas = new Dictionary<string, List<int>>();

// Inicializando o dicionário com algumas bandas e suas avaliações já registradas. A lista de notas permite múltiplas avaliações por banda.
dcBandas.Add("The Beatles", new List<int> { 10, 9, 10 }); // Banda "The Beatles" já com algumas notas.
dcBandas.Add("Linkin Park", new List<int>()); // Banda "Linkin Park" sem avaliações inicialmente.

// Função para imprimir o logo da aplicação - uma forma interessante de interagir com o usuário logo no início.
void Logo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
}

// Função simples para exibir a mensagem de boas-vindas, junto com o logo
void exibirMensagemDeBoasVindas()
{
    Logo(); // Apenas chama a função do logo para iniciar o programa com uma boa impressão
    Console.WriteLine(mensagemDeBoasVindas); // Exibe a mensagem de boas-vindas
}

// Função que exibe o menu com as opções do usuário. Aqui, o uso de `switch` torna o código mais modular e fácil de entender.
void showMenu()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para listar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para encerrar o programa");

    Console.Write("\nDigite a sua opção: "); // Solicitação direta ao usuário
    string input = Console.ReadLine()!; // Leitura da entrada do usuário
    int user_option;
    if (int.TryParse(input, out user_option)) // Verifica se a entrada é um número inteiro
    {
        switch (user_option) // Desvia para a opção selecionada
        {
            case 1:
                {
                    Console.Clear(); // Limpa a tela para mostrar o processo da opção 1
                    Console.WriteLine($"Você escolheu a opção {user_option}");
                    RegistrarBanda(); // Chama a função de registrar banda
                    break;
                }
            case 2:
                {
                    Console.Clear();
                    Console.WriteLine($"Você escolheu a opção {user_option}");
                    ListarBandas(); // Chama a função para listar as bandas
                    break;
                }
            case 3:
                {
                    Console.Clear();
                    Console.WriteLine($"Você escolheu a opção {user_option}");
                    AvaliarBanda(); // Chama a função para avaliar a banda
                    break;
                }
            case 4:
                {
                    Console.Clear();
                    Console.WriteLine($"Você escolheu a opção {user_option}");
                    BandAverage(); // Chama a função para calcular a média de avaliações de uma banda
                    break;
                }
            case -1:
                {
                    Console.Clear();
                    Console.WriteLine("Até mais!"); // Mensagem final ao encerrar o programa
                    break;
                }
            default:
                {
                    Console.Clear(); // Limpa a tela para a opção inválida
                    Console.WriteLine("Opção inválida, Tente novamente!\n"); // Informa que a entrada foi inválida
                    Logo();
                    showMenu(); // Rechama o menu caso a opção seja inválida
                    break;
                }
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Opção inválida, encerrando a aplicação!"); // Caso o usuário não digite um número válido
    }
}

// Função que registra uma nova banda no dicionário se ela ainda não existir
void RegistrarBanda()
{
    Console.WriteLine("\nRegistro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string user_banda = Console.ReadLine()!; // Lê a entrada do nome da banda do usuário

    if (string.IsNullOrEmpty(user_banda)) // Se o nome estiver vazio, chama o check para tratar o erro
    {
        check(user_banda);
    }
    else if (dcBandas.ContainsKey(user_banda)) // Verifica se a banda já foi registrada
    {
        Console.WriteLine($"A lista já possui a banda {user_banda}"); // Informa que a banda já existe
        Console.WriteLine("\nPressione qualquer tecla para voltar para o Menu");
        Console.ReadKey();
        Console.Clear();
        Logo();
        showMenu(); // Retorna ao menu principal
    }
    else
    {
        dcBandas.Add(user_banda, new List<int>()); // Adiciona a banda com uma lista de avaliações vazia
        Console.WriteLine($"\nA banda {user_banda} foi registrada com sucesso!"); // Confirma o registro
        Console.WriteLine("Loading...");
        Console.Beep(); // Emite um som para indicar que o processo foi bem-sucedido
        Thread.Sleep(1500); // Simula um tempo de espera antes de retornar ao menu
        Console.Clear();
        Logo();
        showMenu(); // Retorna ao menu
    }
}

// Função que lista todas as bandas registradas
void ListarBandas()
{
    if (dcBandas.Count == 0) // Verifica se o dicionário está vazio
    {
        Console.WriteLine("Você não possui nenhuma banda para exibir."); // Informa caso não haja bandas
    }
    Console.WriteLine("\nListando suas bandas:\n");
    foreach (string banda in dcBandas.Keys) // Percorre todas as chaves (nomes das bandas) do dicionário
    {
        Console.WriteLine(banda); // Exibe o nome da banda
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar para o Menu");
    Console.ReadKey(); // Espera o usuário pressionar uma tecla antes de voltar ao menu
    Console.Clear();
    Logo();
    showMenu(); // Chama o menu novamente
}

// Função que permite o usuário avaliar uma banda existente
void AvaliarBanda()
{
    Console.Write("\nDigite a banda que você deseja avaliar: ");
    string user_banda = Console.ReadLine()!; // Lê a entrada do nome da banda que será avaliada

    if (string.IsNullOrEmpty(user_banda)) // Se o nome da banda estiver vazio, chama a função de validação
    {
        check(user_banda);
    }
    if (dcBandas.ContainsKey(user_banda) == false) // Verifica se a banda não existe no dicionário
    {
        Console.WriteLine($"\nA banda {user_banda} não existe no dicionário, primeiro adicione-a para depois avaliá-la!");
        Console.WriteLine("Pressione qualquer tecla para prosseguir");
        Console.ReadKey();
        Console.Clear();
        Logo();
        showMenu();
    }
    else
    {
        Console.Write($"Agora dê uma nota para a banda {user_banda}: ");
        string input = Console.ReadLine()!;
        int nota;
        if (int.TryParse(input, out nota)) // Valida a nota inserida
        {
            dcBandas[user_banda].Add(nota); // Adiciona a nota na lista de avaliações da banda
            Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {user_banda}!");
            Console.WriteLine("Loading...");
            Console.Beep();
            Thread.Sleep(1500);
            Console.Clear();
            Logo();
            showMenu(); // Retorna ao menu
        }
        else
        {
            Console.WriteLine("Você não digitou uma nota válida."); // Caso a nota não seja válida
        }
    }
}

// Função que calcula a média das avaliações de uma banda
void BandAverage()
{
    Console.Write("\nDigite o nome da banda para exibir a média dela: ");
    string user_banda = Console.ReadLine()!;

    if (string.IsNullOrEmpty(user_banda)) // Se o nome estiver vazio, chama o check
    {
        check(user_banda);
    }
    else if (dcBandas.ContainsKey(user_banda) == false) // Se a banda não existe no dicionário
    {
        Console.WriteLine($"\nA banda {user_banda} não existe no dicionário, o que torna impossível exibir a média. Primeiro adicione-a.");
        Console.WriteLine("Pressione qualquer tecla para prosseguir");
        Console.ReadKey();
        Console.Clear();
        Logo();
        showMenu();
    }
    else
    {
        int BandLength = dcBandas[user_banda].Count(); // Conta o número de avaliações da banda
        if (BandLength == 0) // Se não houver avaliações
        {
            Console.WriteLine($"A banda {user_banda} não possui avaliações!");
            Console.Write("\nPressione qualquer tecla para prosseguir: ");
            Console.ReadKey();
            Console.Clear();
            Logo();
            showMenu();
        }
        else
        {
            int Total = dcBandas[user_banda].Sum(); // Soma as notas da banda
            Console.WriteLine($"A média de avaliações da banda {user_banda} é {(double)Total / BandLength:0.00}"); // Calcula e exibe a média
            Console.Write("Pressione qualquer tecla para prosseguir: ");
            Console.ReadKey();
            Console.Clear();
            Logo();
            showMenu(); // Retorna ao menu
        }
    }
}

// Função simples de validação para entradas vazias
void check(string ToCheck)
{
    Console.WriteLine("\nVocê não digitou nada!");
    Console.WriteLine("Pressione qualquer tecla para prosseguir");
    Console.ReadKey();
    Console.Clear();
    Logo();
    showMenu();
}

// Inicializa o programa
exibirMensagemDeBoasVindas();
showMenu();
