import React, { Component } from 'react';
import apiClient from '../API/apiClient';

export class BillDetailedWindow extends Component {
    constructor(props) {
        super(props);

        this.state = {
            bill: null
        };

        apiClient.get('api/bill/details/' + this.props.match.params.id)
            .then(
                data => {
                    this.setState({ bill: data.data });
                })
            .catch(() => alert('Unable to load bill: ' + this.props.match.params.id));
    }

    render() {
        let bill = this.state.bill;
        if (bill === null)
            return (
                <h1>Loading...</h1>
            );
            
        console.log(JSON.stringify(bill.purchases));
        return (
            <div className={'container jumbotron text-center py-3 mt-5'}>
                <h1>Bill details</h1>
                <div className="row mt-2">
                    <div className="col-4">
                        <div>
                            <h2 className="m-0">Date:</h2>
                            <p>{bill.date}</p>
                        </div>
                    </div>
                    <div className="col-4">
                        <div>
                            <h2 className="m-0">Store:</h2>
                            <p>{bill.store.name}</p>
                        </div>
                    </div>
                    <div className="col-4">
                        <div>
                            <h2 className="m-0">Sum:</h2>
                            <p>{bill.sum} PLN</p>
                        </div>
                    </div>
                </div>
                <table className="table text-center">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Amount</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {bill.purchases.map(
                            p =>
                            <tr>
                                    <td>{p.productName}</td>
                                    <td>{p.amount}</td>
                                    <td>{p.cost}</td>
                            </tr>)}
                    </tbody>
                </table>
            </div>
        );
    }
}