// Conexión con el Hub de C#
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/ChatMessage")
    .build();

// Inicialización de la conexión
connection.start()
    .then(() => {
        console.log("Conexión establecida")
    })
    .catch(() => {
        console.error("Conexión fallida")
    });