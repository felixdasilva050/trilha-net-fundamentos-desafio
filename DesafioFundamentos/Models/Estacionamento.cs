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
            string response =  Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                veiculos.Add(response.ToUpper());
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");                
                string response= Console.ReadLine();
                int horas;
                while (!(int.TryParse(response, out horas)))
                {
                    Console.WriteLine($"Valor informado {response} está incorreto! Digite um número inteiro para continuar");
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    response= Console.ReadLine();
                }

                decimal valorTotal = this.precoInicial + (this.precoPorHora * horas);
                if (!string.IsNullOrWhiteSpace(placa))
                {
                    veiculos.Remove(placa.ToUpper());
                }
                
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(x => Console.WriteLine($"{x}"));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
