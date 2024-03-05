
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/ChatMessage")
    .build();

connection.start()
    .then(() => {
        console.log("Conexión establecida")
    })
    .catch(() => {
        console.error("Conexión fallida")
    })

let btnEnviar = document.getElementById("btnEnviar");
btnEnviar.addEventListener("click", () => {
    fetch(`https://localhost:7109/api/RealTime/Send?message=${txtMessage.value}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    }).then(data => {
        console.log(data);
    }).catch(error => {
        console.error('There was a problem with your fetch operation:', error);
    });
});


let content = document.getElementById("MyContent");

connection.on("sendMessage", (message) => {
    content.innerHTML += `<p><b>Nuevo mensaje:</b> ${message}</p>`
});

