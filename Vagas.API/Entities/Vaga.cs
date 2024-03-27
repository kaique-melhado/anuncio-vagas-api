using Vagas.API.InputModels;

namespace Vagas.API.Entities;

public class Vaga
{
    public Vaga()
    {
        DataCriacao = DateTime.Now;
    }

    public int IdVaga { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Local { get; set; }
    public decimal Salario { get; set; }
    public DateTime DataCriacao { get; set; }

    public void Create(CreateVagaInputModel input)
    {
        Titulo = input.Titulo;
        Descricao = input.Descricao;
        Local = input.Local;
        Salario = input.Salario;
    }

    public void Update(UpdateVagaInputModel input)
    {
        Titulo = input.Titulo;
        Descricao = input.Descricao;
        Local = input.Local;
        Salario = input.Salario;
    }
}
