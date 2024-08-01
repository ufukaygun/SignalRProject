//Baðlantý Oluþturma: SignalR baðlantýsý oluþturuluyor ve SignalR hub URL'si belirtiliyor.
var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5205/SignalRHub").build();

//Gönder Butonunu Devre Dýþý Býrakma:Gönder butonu baþlangýçta devre dýþý býrakýlýyor.


document.getElementById("sendbutton").disabled = true;

//Mesaj Alma ve Listeye Ekleme:ReceiveMessage olayý tetiklendiðinde, kullanýcý adý ve mesaj içeriði ile birlikte mevcut saat ve dakika ile birlikte bir liste öðesi oluþturulup mesaj listesine ekleniyor.
//ReceiveMessage baðlan demek
connection.on("ReceiveMessage", function (user, message){
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += `:${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messagelist").appendChild(li);
});

//Baðlantýyý Baþlatma ve Butonu Etkinleþtirme:Baðlantý baþarýlý bir þekilde baþlatýlýrsa, gönder butonu etkinleþtiriliyor. Hata olursa konsola yazdýrýlýyor.
connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});


//Mesaj Gönderme:Gönder butonuna týklanýnca, kullanýcý adý ve mesaj içeriði alýnarak SendMessage metodu ile SignalR hub'ýna gönderiliyor. Hata olursa konsola yazdýrýlýyor.
document.getElementById("sendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});