import INewPurchase from './INewPurchase';

export default interface INewBill{
    Date:string;
    StoreId: string;
    Purchases: INewPurchase[];
}