using tabuleiro;
using xadrez;

namespace ProjetoXadrez_Console;
internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos);

            Console.WriteLine(pos.toPosicao());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}