namespace AspNetCore.ViewModels;

public class EditPaisViewModel
{
    public string NmPais { get; set; } = string.Empty;
    public string SiglaPais { get; set; } = string.Empty;
    public string DdiPais { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; }
    public DateTime DataUltAlteracao { get; set; }
}