import axios,{AxiosInstance} from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:44383/',
    timeout: 100000
}) as IApiClient;

export interface IApiClient extends AxiosInstance{
    onLogout:()=>void;
}

export default apiClient;