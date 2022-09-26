using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine();
            if (PlacaValida(placa)){
                if (veiculos.Contains(placa)){
                    Console.WriteLine($"Veículo {placa} já está estacionado.");
                    Console.WriteLine();
                }
                else {
                    veiculos.Add(placa);
                }
            }
            else {
                Console.WriteLine("Placa digitada inválida!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (PlacaValida(placa)){
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    int horas = int.Parse(Console.ReadLine());
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else {
                Console.WriteLine("Placa digitada inválida!");
            }
        }

        public void ListarVeiculos()
        {

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach(string veiculo in veiculos){
                    System.Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool PlacaValida(string placa){
            Regex padraoPlacaAntigo = new Regex("^[A-Za-z]{3}-[0-9]{4}$");
            Regex padraoDePlacaNovo = new Regex("^[A-Za-z]{3}[0-9][A-Za-z][0-9]{2}$");

            if (padraoPlacaAntigo.IsMatch(placa) || padraoDePlacaNovo.IsMatch(placa)){
                return true;
            }
            else {
                return false;
            }
            
        }
    }
}
