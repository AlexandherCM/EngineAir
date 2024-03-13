class ConnectionApi {
    static host = 'https://localhost:7109/';

    // Utiliza este metodo para mandar parametros a un controlador y recibir un JSON 
    //async get(endpoint) {
    //    const response = await fetch(`${ConnectionApi.host}${endpoint}`);

    //    // (código de estado 200)
    //    if (!response.ok) {
    //        throw new Error(`Error al obtener datos. Código de estado: ${response.status}`);
    //    }
    //    return response;
    //}

    //async SendGet(endpoint) {
    //    const response = await fetch(`${ConnectionApi.host}${endpoint}`);
    //    return await response.json();
    //}

    //Utiliza este metodo solo para pasar objetos a un controlador
    //async SetPost(endpoint, data) {
    //    const response = await fetch(`${ConnectionApi.host}${endpoint}`, {
    //        method: 'POST',
    //        headers: {
    //            'Content-Type': 'application/json',
    //        },
    //        body: JSON.stringify(data),
    //    });
    //}

    //Utiliza este metodo para pasar objetos a un controlador y recibir un JSON
    async SendPost(endpoint, data) {
        const response = await fetch(`${ConnectionApi.host}${endpoint}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return await response.json();
    }
}

// Objeto general del sistema para hacer peticiones 
const api = new ConnectionApi();

