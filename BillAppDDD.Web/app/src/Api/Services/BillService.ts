import IBill from "../../Components/Bills/IBill";
import apiClient from "../apiClient";
import { resolve, reject } from "q";
import INewBill from "../../Components/Bills/NewBill/INewBill";

export interface IBillService{
    getAllBills():Promise<IBill[]>;
    addBill(bill: INewBill):Promise<boolean>;
}

const StoreService:IBillService = {
    getAllBills: ()=>{
        return new Promise<IBill[]>((resolve,reject)=>{
            apiClient
                .get('api/bill/getall')
                .then(resp=> resolve(resp.data))
                .catch(error=> reject(error));
        });
    },
    addBill: (bill: INewBill)=>{
        return new Promise<boolean>((resolve,reject)=>{
            apiClient
                .post('api/bill/add',{...bill})
                .then(resp=> resolve(true))
                .catch(error=> reject(error));
        });
    }
}

export default StoreService;