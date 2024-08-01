//Ba�lant� Olu�turma: SignalR ba�lant�s� olu�turuluyor ve SignalR hub URL'si belirtiliyor.
var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5205/SignalRHub").build();

//G�nder Butonunu Devre D��� B�rakma:G�nder butonu ba�lang��ta devre d��� b�rak�l�yor.


document.getElementById("sendbutton").disabled = true;

//Mesaj Alma ve Listeye Ekleme:ReceiveMessage olay� tetiklendi�inde, kullan�c� ad� ve mesaj i�eri�i ile birlikte mevcut saat ve dakika ile birlikte bir liste ��esi olu�turulup mesaj listesine ekleniyor.
//ReceiveMessage ba�lan demek
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

//Ba�lant�y� Ba�latma ve Butonu Etkinle�tirme:Ba�lant� ba�ar�l� bir �ekilde ba�lat�l�rsa, g�nder butonu etkinle�tiriliyor. Hata olursa konsola yazd�r�l�yor.
connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});


//Mesaj G�nderme:G�nder butonuna t�klan�nca, kullan�c� ad� ve mesaj i�eri�i al�narak SendMessage metodu ile SignalR hub'�na g�nderiliyor. Hata olursa konsola yazd�r�l�yor.
document.getElementById("sendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});