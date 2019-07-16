namespace Mono_zadatak.Models
{
    public interface IMarkaVozila
    {
        int Id { get; set; }
        string Kratica { get; set; }
        string Naziv { get; set; }
    }
}