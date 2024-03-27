namespace Vagas.API.InputModels
{
    public class CreateVagaInputModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public decimal Salario { get; set; }
    }
}
