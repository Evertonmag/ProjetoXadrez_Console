using tabuleiro;
using xadrez;

namespace ProjetoXadrez_Console;
internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            int contBranca = 0, contPreta = 0;
            char resp = 'S';
            while (resp == 'S')
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (partida.terminada is false)
                {
                    try
                    {
                        Console.Clear();

                        Console.WriteLine("Placar: ");
                        Console.Write("Branco [");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(contBranca);
                        Console.ResetColor();
                        Console.Write("] X [");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(contPreta);
                        Console.ResetColor();
                        Console.Write("] Preta \n\n");

                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] possicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, possicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.valaidarposicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);

                if (partida.jogadorAtual == Cor.Branca)
                    contBranca++;
                else
                    contPreta++;

                Console.Write("\nGostaria de jogar de novo: ");
                resp = char.Parse(Console.ReadLine().ToUpper());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}