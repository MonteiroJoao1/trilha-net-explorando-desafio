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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("Atenção: A quantidade de hóspedes é maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Verifica se Hospedes não é nulo antes de chamar Count
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            else
            {
                // Se Hospedes for nulo, retorna 0
                return 0;
            }
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte não foi cadastrada.");
            }

            // Calcula o valor da diária apenas se Suite não for nulo
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                decimal desconto = 0.1M;
                valor = valor - (valor * desconto);
            }

            return valor;
        }
    }
}
