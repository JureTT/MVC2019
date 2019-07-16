namespace Mono_zadatak.Models
{
    public interface IModelVozila
    {
        int Id { get; set; }
        int IdMarke { get; set; }
        string Kratica { get; set; }
        string Naziv { get; set; }
    }
}