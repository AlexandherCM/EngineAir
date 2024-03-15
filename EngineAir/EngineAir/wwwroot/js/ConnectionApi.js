class ConnectionApi {
    static host = 'https://localhost:7109/';
    
    async SendPost(endpoint, data) {
        const response = await fetch(`${ConnectionApi.host}${endpoint}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });

        // Verifica si el código de estado es 200-299
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return true;
    }
};

// Objeto general del sistema para hacer peticiones 
const api = new ConnectionApi();

