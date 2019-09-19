import React, { Component } from 'react';
import { BillDetailedWindow } from './DetailedBillWindow';
import { Link } from 'react-router-dom';

export class BillList extends Component {
    constructor(props) {
        super(props);

        this.state = {
            bills: null
        };

        fetch('/api/bill')
            .then(response => response.json())
            .then(
                data => {
                    this.setState({ bills: data });
                });
    }

    handleRemove(billId) {
        var request = {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                billId: billId
                })  
        };

        fetch('api/bill/remove', request)
            .catch(()=>alert('Unable to remove bill: ' + billId))
            .finally(() => {
                var bills = this.state.bills;

                bills = bills.filter((value, index, arr) => value.id !== billId);

                this.setState({ bills });
            });
    }

    render() {
        if (this.state.bills === null) {
            return (
                <h1>Loading...</h1>
            );
        }

        if (this.state.bills.length === 0) {
            return (
                <h1>No bills</h1>
            );
        }

        var keys = Object.keys(this.state.bills[0]).filter((value,index,arr)=>value!=='id');

        return (
            <div className="container">
                <h1>Bills</h1>
                <table className="table text-center">
                    <thead>
                        <tr>
                            {keys.map(k => <th>{k}</th>)}
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.bills.map(b =>
                            <tr>
                                <td>{b.date.substring(0, 10)}</td>
                                <td>{b.store !== null ? b.store.name : 'No store'}</td>
                                <td>{b.sum}</td>
                                <td>
                                    <Link to={'/billDetails/' + b.id}>
                                        <button type='button' className='btn btn-primary'>Details</button>
                                    </Link>
                                    <button type='button' className='btn btn-danger' onClick={()=>this.handleRemove(b.id)}>Remove</button>
                                </td>
                            </tr>)}
                    </tbody>
                </table>
            </div>
        );
    }
}
