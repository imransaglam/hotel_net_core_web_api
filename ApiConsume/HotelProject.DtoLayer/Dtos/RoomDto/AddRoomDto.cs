using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class AddRoomDto
    {
        [Required(ErrorMessage ="Lütfen Oda Numarası bilgisini Giriniz")]
        public string RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen Fiyat bilgisini Giriniz")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Başlığı bilgisini Giriniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Yatak Sayısı bilgisini Giriniz")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen Banyo Sayısı bilgisini Giriniz")]
        public string BathCount { get; set; }
        public string? Wifi { get; set; }
        public string? Description { get; set; }
    }
}
