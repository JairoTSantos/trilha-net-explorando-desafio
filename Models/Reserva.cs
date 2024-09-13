namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade da suíte é suficiente para a quantidade de hóspedes
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança uma exceção caso a capacidade seja menor que o número de hóspedes
                throw new Exception("A quantidade de hóspedes é maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total da diária
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Aplica um desconto de 10% caso os dias reservados sejam maior ou igual a 10
            if (DiasReservados >= 10)
            {
                valorTotal -= valorTotal * 0.10m; // Aplica o desconto
            }

            return valorTotal;
        }
    }
}
