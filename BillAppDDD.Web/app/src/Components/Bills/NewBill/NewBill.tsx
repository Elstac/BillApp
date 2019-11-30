import React, { useEffect } from 'react'
import { Container, Typography, Grid, Input, InputLabel, FormControl, Select, MenuItem, Table, TableBody, TableHead, TableRow, TableCell, Button } from "@material-ui/core";
import avatar from './avatar.png'
import IStore from '../../Stores/IStore';
import StoreService from '../../../Api/Services/StoreService';
import BillService from '../../../Api/Services/BillService';
import INewPurchase from './INewPurchase';
import NewPurchaseDialog from './NewPurchaseDialog';
import { GetDateStringFromInput } from "../../../Utils/DateHelper";
import INewBill from './INewBill';

const NewBill: React.FC = ()=>{
    const [stores,setStores] = React.useState<IStore[]>([]);
    const [storeId,setStoreId] = React.useState<string>("");
    const [purchases,setPurchases] = React.useState<INewPurchase[]>([]);
    const [isDialogOpen,setDialogOpen] = React.useState(false);

    const addPurchase =(purchase: INewPurchase)=>{
        let newPurchases = purchases;

        newPurchases.push(purchase);

        setPurchases(newPurchases);
        setDialogOpen(false);
    }

    const handleSubmit = (e:React.FormEvent<HTMLFormElement>)=>{
        e.preventDefault();
        let data = new FormData(e.target as HTMLFormElement);

        let date = GetDateStringFromInput(data.get('date') as string);

        const bill: INewBill ={
            StoreId:storeId,
            Date: date,
            Purchases:purchases
        }

        const testBill: INewBill={
            StoreId: "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
            Date: "2019-09-11",
            Purchases:[
                {Amount:1,Date:"2019-09-11",Price:1,Product:{
                    barcode:"asdasd",
                    categotyId:"aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
                    id:"aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
                    name:"name",
                    price:0
                }}
            ]
        }
        console.log(testBill);
        console.log(bill);
        BillService.addBill(bill);
    }
    
    useEffect(()=>{
        StoreService
        .getStores()
        .then(data=>setStores(data))
        .catch(e=>alert(e));
    },[]);

    return(
        <Container style={{width:"100%"}}>
            <Grid container>
                <form onSubmit={handleSubmit}>
                <Grid xs={12} item>
                    <FormControl>
                        <InputLabel>Date</InputLabel>
                        <Input name="date" type="date"></Input>
                    </FormControl>
                </Grid>
                <Grid xs={6} item>
                    <FormControl>
                        <InputLabel>Store</InputLabel>
                        <Select
                        style={{width:"300px"}}
                            value={storeId}
                            onChange={e=>setStoreId(e.target.value as string)}>
                            {stores.map(v=>
                                <MenuItem value={v.id}>{v.name}</MenuItem>
                            )}
                        </Select>
                    </FormControl>
                </Grid>
                <Grid xs={6} item>
                    <FormControl disabled>
                        <InputLabel>Promotion</InputLabel>
                        <Select
                            style={{width:"300px"}}>
                            
                        </Select>
                    </FormControl>
                </Grid>
                <Grid xs={12} item>
                    <h3>Products</h3>
                    <Table>
                        <TableHead>
                            <TableCell>Name</TableCell>
                            <TableCell>Amount</TableCell>
                            <TableCell>Barcode</TableCell>
                            <TableCell>Expiration date</TableCell>
                            <TableCell>Price</TableCell>
                        </TableHead>
                        <TableBody>
                            {purchases.map((v)=>
                            <TableRow>
                                <TableCell>{v.Product.name}</TableCell>
                                <TableCell>{v.Amount}</TableCell>
                                <TableCell>{v.Product.barcode}</TableCell>
                                <TableCell>{v.Date}</TableCell>
                                <TableCell>{v.Price}$</TableCell>
                            </TableRow>
                            )}
                        </TableBody>
                    </Table>
                </Grid>
                <Grid xs={12} item>
                    <Button onClick={()=>setDialogOpen(true)}>Add Purchase</Button>
                </Grid>
                <Grid xs={12} item>
                    <Button color="primary" type="submit">Confirm</Button>
                </Grid>
                </form>
            </Grid>
            <NewPurchaseDialog isOpen={isDialogOpen} handlePurchaseAdd={p=>addPurchase(p)}/>
        </Container>
    );
}

export default NewBill;