import React, { Component } from 'react';
import { TimeSpan } from '../../Shared/TimeSpan';

export class Spendings extends Component {

    render() {
        
        var bills = this.props.bills;
        var from = this.props.span.from;
        var to = this.props.span.to;

        if (bills === null)
            return (
                <div className="container jumbotron py-1">
                    <h2>Spendings</h2>
                    <p>Loading...</p>
                </div>
            );

        if (from !== null)
            bills = bills.filter((value,index,arr) => value.date.substring(10,0) >= from);

        if (to !== null)
            bills = bills.filter((value, index, arr) => value.date<= to);

        var sum = bills.length === 0 ?
                0 :
                bills.length === 1 ?
                    bills[0].sum :
                bills.reduce((a, b2) => a + (b2['sum'] || 0),0);

        return (
            <div className="container jumbotron py-1">
                <h2>Spendings</h2>
                <div className="text-center mt-3">
                    <h3>Total spendings: {sum}</h3>
                </div>
            </div>
        );
    }
}