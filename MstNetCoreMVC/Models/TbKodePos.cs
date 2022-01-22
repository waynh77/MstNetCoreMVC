using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MstNetCoreMVC.Models;

public partial class TbKodePos
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? NoKodePos { get; set; }
    [Required]
    public string? Kelurahan { get; set; }
    [Required]
    public string? Kecamatan { get; set; }
    [Required]
    public string? Jenis { get; set; }
    [Required]
    public string? Kabupaten { get; set; }
    [Required]
    public string? Propinsi { get; set; }

}
