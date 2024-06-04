using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.BookingDtos
{
	//Dto klasörünün içerisinde bunlar var ama oradakiler sadece API için çalışıyor. Buradakiler ise UI için çalışacak.
	//UI içinde hepsini tektek yazılacak. Json dan gelen propertyleri eşleştirmemiz gerekiyor.
	//Json formatında gelen datayı eşlememmiz gerekiyor.
	//DTo katmanını kullanamayız. Çünkü her katman ayrı bir projeden geliyor. Biz şu an UI katmanında geşitirme yapıyoruz.
	//UI katmanın port numarasıyla Api nin port numarası aynı değil. Her bibi aslında ayrı proje.
	public class ResultBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
