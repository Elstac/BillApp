import React from 'react';
import { DialogTitle,Dialog, Typography, Grid, Box, Table, TableHead, TableRow, TableCell, TableBody, Button } from '@material-ui/core';
import IBillDetails from './IBillDetails';

interface BillDetailsDialogProps{
    isOpen: boolean;
    billDtails: IBillDetails;
    handleClose: ()=>void;
}

const BillDetailsDialog : React.FC<BillDetailsDialogProps> = props=>{
    if(props.billDtails === null)
        return(<div></div>);

    return(
        <React.Fragment>
            <Dialog open={props.isOpen}>
                <DialogTitle>Bill details</DialogTitle>
                <Grid container>
                    <Grid item xs={12}>
                        <Typography>{"ID: "+props.billDtails.id}</Typography>
                    </Grid> 
                    <Grid item xs={6}>
                        <Typography>{"Date: "+props.billDtails.date}</Typography>
                    </Grid> 
                    <Grid item xs={6}>
                        <Typography>{"Store: "+props.billDtails.store.name}</Typography>
                    </Grid> 
                    <Grid item xs={12}>
                        <Typography component="h5" variant="h5">{"Products: "}</Typography>
                    </Grid> 
                    <Grid item xs={12}>
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>Amount</TableCell>
                                    <TableCell>Cost</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody  style={{textAlign:"center"}}>
                                {props.billDtails.purchases.map(v=>
                                    <TableRow>
                                        <TableCell>{v.productName}</TableCell>
                                        <TableCell>{v.amount}</TableCell>
                                        <TableCell>{v.cost}</TableCell>
                                    </TableRow>
                                )}
                            </TableBody>
                        </Table>
                    </Grid>
                    <Grid item xs ={6}>
                        <Button color="secondary" onClick={()=>props.handleClose()}>Back</Button>
                    </Grid>
                </Grid>
            </Dialog>
        </React.Fragment>
    );
}

export default BillDetailsDialog;