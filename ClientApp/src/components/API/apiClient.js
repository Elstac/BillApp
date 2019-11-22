import axios from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:44383/',
    timeout: 100000
});

apiClient.baseURL = 'https://localhost:44383/';

export default apiClient;