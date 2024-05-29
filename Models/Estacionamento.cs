using System.Net;
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

            //Solicitando ao usuario a placa do veiculo
            Console.WriteLine("Digite a placa do veículo para estacionar:\nSeguir o formato AAA1234 ");
            string placa = Console.ReadLine();

            if (ValidarPlaca(placa))
            {
                Console.WriteLine("Placa validada com sucesso!");
                //Adicionar a placa a lista de veiculosS
                veiculos.Add(placa);
            }
            else
            {
                Console.WriteLine("A Placa informada é invalida");
            }


        }

        //Validando se realmente o formato digitado é uma placa     
        static bool ValidarPlaca(string placa)
        {
            //Expressão aceitavesis AAA-1234 
            string pattern = @"^[A-Z]{3}-?\d{4}$";

            return Regex.IsMatch(placa, pattern);

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                decimal horas = decimal.Parse(Console.ReadLine());

                //Calcula o Valor Total
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // TODO: Remover a placa digitada da lista de veículo
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                // Exibia  lista dos veiculos estacionados
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine("- " + veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

        }
    }
}//Fim