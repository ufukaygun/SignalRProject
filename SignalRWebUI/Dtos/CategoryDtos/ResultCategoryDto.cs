namespace SignalRWebUI.Dtos.CategoryDtos
{
	//Dto klasörünün içerisinde bunlar var ama oradakiler sadece API için çalışıyor. Buradakiler ise UI için çalışacak.
	//UI içinde hepsini tektek yazılacak. Json dan gelen propertyleri eşleştirmemiz gerekiyor.
	//Json formatında gelen datayı eşlememmiz gerekiyor.
	//DTo katmanını kullanamayız. Çünkü her katman ayrı bir projeden geliyor. Biz şu an UI katmanında geşitirme yapıyoruz.
	//UI katmanın port numarasıyla Api nin port numarası aynı değil. Her bibi aslında ayrı proje.
	public class ResultCategoryDto
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public bool Status { get; set; }
	}
}
