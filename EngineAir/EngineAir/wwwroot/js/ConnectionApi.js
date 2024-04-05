class ConnectionApi {

    url = 'https://localhost:7109';
    static timeSpam = 2000;
    static host = 'https://localhost:7109/';

    async redirectToAction(endPoint) {
        setTimeout(() => {
            window.location.href = `${ConnectionApi.host}${endPoint}`;
        }, ConnectionApi.timeSpam);
    }

    async SendPost(endpoint, data) {
        const response = await fetch(`${ConnectionApi.host}${endpoint}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });

        // Verifica si el código de estado es 200-299
        if (!response.ok)
            throw new Error(`HTTP error! status: ${response.status}`);

        // Lee el cuerpo de la respuesta como JSON
        return await response.json();
    }
};

// Objeto general del sistema para hacer peticiones 
const api = new ConnectionApi();

