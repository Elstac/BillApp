import React, { Component, useState, useEffect } from 'react';
import apiClient from '../../Api/apiClient';
import BillService from '../../Api/Services/BillService';
import IBill from './IBill';
import IBillDetails from './IBillDetails';
import { AxiosRequestConfig } from 'axios';
import { Table, TableHead, TableRow, TableCell, TableBody, Container, Button } from '@material-ui/core';
import BillDetailsDialog from "./BillDetailsDialog";

const BillContainer : React.FC = props=>{
    const [bills,setBills] = useState<IBill[]>([]);
    const [billDetails,setBillDetails] = useState<IBillDetails>({date:"",id:"",purchases:[],store:{id:"",name:""},sum:0});
    const [isDialogOpen,setDialogOpen] = useState(false);

    useEffect(()=>{
        BillService
            .getAllBills()
            .then(data=>setBills(data))
            .catch(error=>alert(error));
    },[]);

    const handleRemove = (billId:string) => {
        apiClient.delete('api/bill/remove',{billId} as AxiosRequestConfig)
        .catch(resp=>{
            alert('Unable to remove bill: ' + billId);
            console.log(resp);
        })
        .finally(() => {
            let newBills = bills.filter((value, index, arr) => value.id !== billId);
            setBills(newBills);
        });
    }

    const openDetailsDialog = (billId:string) =>{
        apiClient.get('/api/Bill/Details/'+billId)
        .then(data=>{
            setBillDetails(data.data);
        });
        setDialogOpen(true);
    }

    if (bills.length === 0) {
        return (
            <h1>No bills</h1>
        );
    }

    var keys = Object.keys(bills[0]).filter((value,index,arr)=>value!=='id');
    return (
        <Container>
            <h1>Bills</h1>
            <Table>
                <TableHead>
                    <TableRow>
                        {keys.map(k => <TableCell>{k}</TableCell>)}
                        <TableCell/>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {bills.map(b =>
                            <TableRow>
                                <TableCell>{b.date.substring(0, 10)}</TableCell>
                                <TableCell>{b.store !== null ? b.store.name : 'No store'}</TableCell>
                                <TableCell>{b.sum}</TableCell>
                                <TableCell>
                                    <Button onClick={()=>handleRemove(b.id)} color="secondary">Delete</Button>
                                    <Button onClick={()=>openDetailsDialog(b.id)} color="primary">Details</Button>
                                </TableCell>
                            </TableRow>)}
                </TableBody>
            </Table>
            <BillDetailsDialog isOpen={isDialogOpen} billDtails={billDetails} handleClose={()=>{setDialogOpen(false);}}/>
        </Container>
    );
}

export default BillContainer;
