import IStore from "../Stores/IStore";

export default interface IBill{
    id:string;
    store: IStore;
    sum:Number;
    date:string;
}