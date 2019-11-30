import IProduct from '../../Products/IProduct';

export default interface INewPurchase{
    Product: IProduct;
    Date: string;
    Amount: number;
    Price: number;
}