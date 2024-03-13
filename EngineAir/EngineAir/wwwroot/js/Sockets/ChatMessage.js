let btnEnviar = document.getElementById("btnEnviar");
let txtMessage = document.getElementById("txtMessage");

btnEnviar.addEventListener("click", () => {
    api.get(`api/RealTime/Send?data=${txtMessage.value}`);
});

let content = document.getElementById("MyContent");

connection.on("sendMessage", (data) => {
    content.innerHTML += `<p><b>Nuevo mensaje:</b> ${data}</p>`
});

