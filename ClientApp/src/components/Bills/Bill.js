import React, { Component } from 'react';

export class Bill extends Component {


    render() {
        return (
            <tr>
                <td>{this.props.bill.date.substring(0,10)}</td>
                <td>{this.props.bill.store !== null ? this.props.bill.store.name :'No store' }</td>
                <td>{this.props.bill.sum}</td>
            </tr>
        );
    }
}