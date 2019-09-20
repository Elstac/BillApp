import React, { Component } from 'react';
import { TimeSpan } from '../../Shared/TimeSpan';

export class Spendings extends Component {

    constructor(props) {
        super(props);

        this.state = {
            span: { from: null, to: null }
        };
    }

    render() {
        
        var bills = this.props.bills;
        var from = this.state.span.from;
        var to = this.state.span.to;

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
                    bills.reduce((b1, b2) => b1.sum + b2.sum);

        return (
            <div className="container jumbotron py-1">
                <h2>Spendings</h2>
                <TimeSpan
                    handleSpanChange={(span) => this.setState({ span })}
                />
                <div className="text-center mt-3">
                    <h3>Total spendings: {sum}</h3>
                </div>
            </div>
        );
    }
}