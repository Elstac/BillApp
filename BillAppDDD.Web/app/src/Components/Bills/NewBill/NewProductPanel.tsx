import React, { useEffect } from 'react';
import { FormControl, InputLabel, Select, MenuItem, Input, Container, Button } from "@material-ui/core";
import IProduct from '../../Products/IProduct';
import ProductCategoryService from '../../../Api/Services/ProductCategoryService';
import NewPurchasePanelProps from './NewPurchasePanelProps';
import INewPurchase from './INewPurchase';
import IProductCategory from '../../ProductCategories/IProductCategory';


const NewProductPanel:React.FC<NewPurchasePanelProps>= props =>{
    const [categories,setCategories] = React.useState<IProductCategory[]>([]);
    const [categoryId,setCategoryId] = React.useState("");
    
    useEffect(()=>{
        ProductCategoryService.getCategories().then(data=>setCategories(data));
    },[]);

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) =>{
        e.preventDefault();

        let data = new FormData(e.target as HTMLFormElement);
        let date = new Date(data.get('date') as string);
        let dateString = date.getFullYear() + '-' + date.getMonth().toString().padStart(2, '0') + '-' + date.getDate().toString().padStart(2, '0');

        let catId = categoryId !== ""?categoryId:"00000000-0000-0000-0000-000000000000";

        const purchase:INewPurchase = {
            Amount: parseInt(data.get('amount') as string,10),
            Date: "2019-11-11",
            Price: parseInt(data.get('cost') as string,10),
            Product: {
                name: data.get('name') as string,
                barcode: data.get('barcode') as string,
                categotyId: catId,
                id: "00000000-0000-0000-0000-000000000000",
                price:0
            }
        }

        props.handelPurchaseAdd(purchase);
    }

    return(
        <Container style={{maxWidth:"350px"}}>
            <form onSubmit={handleSubmit}>
                <FormControl style={{width:"300px"}}>
                    <InputLabel>Name</InputLabel>
                    <Input name="name" type="text"></Input>
                </FormControl>
                <FormControl style={{width:"300px"}}>
                    <InputLabel>Barcode</InputLabel>
                    <Input name="barcode" type="text"></Input>
                </FormControl>
                <FormControl style={{width:"300px"}}>
                    <InputLabel>Category</InputLabel>
                    <Select
                        value={categoryId}
                        onChange={e=>setCategoryId(e.target.value as string)}
                    >
                        {categories.map(v=>
                            <MenuItem value={v.id}>{v.name}</MenuItem>
                        )}
                    </Select>
                </FormControl>
                <FormControl style={{width:"100px"}}>
                    <InputLabel>Amount</InputLabel>
                    <Input name="amount" type="number"></Input>
                </FormControl>
                <FormControl style={{width:"100px"}}>
                    <InputLabel>Cost</InputLabel>
                    <Input name="cost" type="number"></Input>
                </FormControl>
                <Button type="submit">Add purchse</Button>
            </form>
        </Container>
    );
}

export default NewProductPanel;