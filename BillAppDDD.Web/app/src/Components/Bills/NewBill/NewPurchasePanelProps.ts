import INewPurchase from './INewPurchase';

export default interface NewPurchsePanelProps{
    handelPurchaseAdd(purchase:INewPurchase):void;
}