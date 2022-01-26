using tabuleiro;
using xadrez;

namespace ProjetoXadrez_Console;
internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();


            while (partida.terminada is false)
            {
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tab);

                Console.WriteLine();
                Console.Write("Origem: ");
                Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                Console.Write("Destino: ");
                Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                partida.ExecutaMovimento(origem, destino);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}