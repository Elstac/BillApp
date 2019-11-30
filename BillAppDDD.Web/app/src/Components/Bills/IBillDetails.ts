import IStore from "../Stores/IStore";

export default interface IBillDetails{
    id:string;
    store: IStore;
    sum:Number;
    date:string;
    purchases:IPurchase[];
}

export interface IPurchase{
    amount: number;
    cost: number;
    productName: string;
}