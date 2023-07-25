

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Micro.Aplicacao.DTOs;

public class ProgramaDTO
{
   // [JsonIgnore]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o Nome")]
    [MinLength(2)]
    [MaxLength(100)]
    [DisplayName("Nome")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Informe a Descrição")]
    [MinLength(1)]
    [MaxLength(200)]
    [DisplayName("Alimento")]
    public string? Alimento { get; set; }

    [Required(ErrorMessage = "Informe o Tempo")]
    [Range(1, 180, ErrorMessage = "Informe o tempo entre 1 a 180s")]
    [DisplayName("Tempo")]
    public int Tempo { get; set; }

    [Required(ErrorMessage = "Informe a Potência")]
    [Range(1, 10, ErrorMessage = "Informe o tempo entre 1 a 10")]
    [DisplayName("Potencia")]
    public int Potencia { get; set; }

    [MaxLength(250)]
    [DisplayName("Instrucoes")]
    public string? Instrucoes { get; set; }

    [Required(ErrorMessage = "Informe o Simbolo")]
    [MaxLength(1)]
    [DisplayName("Aquece")]
    public string? Aquece { get;  set; }

}
