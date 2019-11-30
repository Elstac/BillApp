import IAddStoreRequest from "../../Interfaces/IAddStoreRequest";
import apiClient from "../apiClient";
import { resolve, reject } from "q";
import IStore from "../../Components/Stores/IStore";

export interface IStoreService{
    addStore(request:IAddStoreRequest):Promise<boolean>;
    getStores():Promise<IStore[]>;
}

const StoreService:IStoreService = {
    addStore: (request)=>{

        return new Promise<boolean>((resolve,reject)=>{
            apiClient
                .post('api/stores/add',{name:request.name})
                .then(resp=> resolve(true))
                .catch(error=> reject(error));
        });
    },
    getStores:()=>{
        return new Promise<IStore[]>((resolve,reject)=>{
            apiClient
                .get('api/stores/getall')
                .then(resp=> resolve(resp.data))
                .catch(error=> reject(error));
        });
    }
}

export default StoreService;