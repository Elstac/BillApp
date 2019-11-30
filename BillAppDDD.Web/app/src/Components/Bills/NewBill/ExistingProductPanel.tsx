import React, { useEffect } from 'react';
import { FormControl, InputLabel, Select, MenuItem, Input, Container, Button } from "@material-ui/core";
import IProduct from '../../Products/IProduct';
import ProductService from '../../../Api/Services/ProductService';
import NewPurchasePanelProps from './NewPurchasePanelProps';
import INewPurchase from './INewPurchase';


const ExistingProductPanel:React.FC<NewPurchasePanelProps>= props =>{
    const [products,setProducts] = React.useState<IProduct[]>([]);
    const [productId,setProductId] = React.useState("");
    
    useEffect(()=>{
        ProductService.getProducts().then(data=>setProducts(data));
    },[]);

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) =>{
        e.preventDefault();

        let data = new FormData(e.target as HTMLFormElement);
        let date = new Date(data.get('date') as string);
        let dateString = date.getFullYear() + '-' + date.getMonth().toString().padStart(2, '0') + '-' + date.getDate().toString().padStart(2, '0');

        const purchase:INewPurchase = {
            Amount: parseInt(data.get('amount') as string,10),
            Date: "2019-11-11",
            Price: parseInt(data.get('cost') as string,10),
            Product: products.find(p=>p.id === productId) as IProduct
        }

        console.log(purchase);
        props.handelPurchaseAdd(purchase);
   }

    return(
        <Container style={{maxWidth:"350px"}}>
            <form onSubmit={handleSubmit}>
                <FormControl style={{width:"300px"}}>
                    <InputLabel>Product</InputLabel>
                    <Select
                        value={productId}
                        onChange={e=>setProductId(e.target.value as string)}
                    >
                        {products.map(v=>
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

export default ExistingProductPanel;