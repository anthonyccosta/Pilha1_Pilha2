using Pilha1_Pilha2;

internal class Program
{
   private static void Main(string[] args)
    {
        ValorPilha pilha1 = new ValorPilha();
        ValorPilha pilha2 = new ValorPilha();
        ValorPilha pilhaAux = new ValorPilha();
        ValorPilha pilha_opcao = new ValorPilha();
        int aleatorio, opcao, opcaopilha;

        aleatorio = new Random().Next(1, 10);
        for (int i = 0; i < aleatorio; i++)
        {
            //metodo push da pilha 1
            pilha1.push(geraNumero());
        }
        aleatorio = new Random().Next(1, 10);
        for (int i = 0; i < aleatorio; i++)
        {
            //metodo push da pilha 2
            pilha2.push(geraNumero());
        }
        do
        {
            Console.WriteLine("1 - Verificar tamanho das pilhas: ");
            Console.WriteLine("2 - Verificar maior, menor, e média aritmetica de uma pilha: ");
            Console.WriteLine("3 - Transferir uma pilha para outra: ");
            Console.WriteLine("4 - Imprimir Par ou Impar de uma Pilha: ");
            Console.WriteLine("0 - Encerrar Programa!");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Saindo do programa");
                    break;
                case 1:
                    compararPilhas(pilha1, pilha2);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Digite 1 para a Pilha 1, 2 para a Pilha 2 ou 3 para a Pilha 3.");
                        opcaopilha = int.Parse(Console.ReadLine());
                    } while ((opcaopilha < 1) && (opcaopilha > 3));
                    switch (opcaopilha)
                    {
                        case 1:
                            pilha_opcao = pilha1;
                            break;
                        case 2:
                            pilha_opcao = pilha2;
                            break;
                        default:
                            pilha_opcao = pilhaAux;
                            break;
                    }
                    retornarNumeros(pilha_opcao, 2);
                    valoresPilhas(pilha_opcao);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Digite:\n1 - para transferir da Pilha 1");
                        Console.WriteLine("2 - para transferir da Pilha 2");
                        opcaopilha = int.Parse(Console.ReadLine());
                    } while ((opcaopilha < 1) && (opcaopilha > 2));
                    switch (opcaopilha)
                    {
                        case 1:
                            pilhaAux = transferirPilha(pilha1);
                            break;
                        default:
                            pilhaAux = transferirPilha(pilha2);
                            break;
                    }
                    Console.WriteLine($"Todos os Números da Pilha {opcaopilha} transferida:");
                    retornarNumeros(pilhaAux, 2);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 4:
                    do
                    {
                        Console.WriteLine("Digite 1 para a Pilha 1, 2 para a Pilha 2 ou 3 para a Pilha Auxiliar");
                        opcaopilha = int.Parse(Console.ReadLine());
                    } while ((opcaopilha < 1) && (opcaopilha > 2));
                    switch (opcaopilha)
                    {
                        case 1:
                            pilha_opcao = pilha1;
                            break;
                        case 2:
                            pilha_opcao = pilha2;
                            break;
                        default:
                            pilha_opcao = pilhaAux;
                            break;
                    }
                    retornarNumeros(pilha_opcao, 0);
                    retornarNumeros(pilha_opcao, 1);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        } while (opcao != 0);
    }
    static void compararPilhas(ValorPilha p1, ValorPilha p2)
    {
        int p1s, p2s;
        p1s = p1.getContador();
        p2s = p2.getContador();

        if (p1s == p2s)
        {
            Console.WriteLine($"As pilhas são de tamanhos iguais: {p1s}.");
        }
        else if (p1s > p2s)
        {
            Console.WriteLine($"A Pilha 1 ({p1s}) é maior que a Pilha 2 ({p2s})");
        }
        else
        {
            Console.WriteLine($"A Pilha 2 ({p2s}) é maior que a Pilha 1 ({p1s})");
        }
    }
    static void valoresPilhas(ValorPilha pilha)
    {
        float resultado = 0;
        resultado = pilha.getValor(0);
        Console.WriteLine($"O menor valor da pilha é: {resultado}");
        resultado = pilha.getValor(1);
        Console.WriteLine($"O maior valor da pilha é: {resultado}");
        resultado = pilha.getValor(2);
        Console.WriteLine($"A média aritmética da pilha é: {resultado}");
    }
    static Numero geraNumero()
    {
        Numero numerotemp = new Numero(new Random().Next(1, 100));
        return numerotemp;
    }
    static void retornarNumeros(ValorPilha pilha, int tipo)
    {
        switch (tipo)
        {
            case 0:
                Console.WriteLine("Números pares: " + pilha.print(0));
                break;
            case 1:
                Console.WriteLine("Números ímpares: " + pilha.print(1));
                break;
            case 2:
                Console.WriteLine(pilha.print(2));
                break;
        }
    }
    static ValorPilha transferirPilha(ValorPilha pilha)
    {
        int tamanhoPilha = 0;

        Numero aux, auxFinal;
        ValorPilha tempAux = new ValorPilha();
        ValorPilha tempFinal = new ValorPilha();

        Console.WriteLine("Todos os Números da pilha original:");
        retornarNumeros(pilha, 2);
        tamanhoPilha = pilha.getContador();  
        for (int i = 0; i < tamanhoPilha; i++)
        {
            aux = new Numero(pilha.pop()); 
            tempAux.push(aux);
        }
        for (int i = 0; i < tamanhoPilha; i++)
        {
            auxFinal = new Numero(tempAux.pop()); 
            tempFinal.push(auxFinal);
        }
        return tempFinal; 
    }
}