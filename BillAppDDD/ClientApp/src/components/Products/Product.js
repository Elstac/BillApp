import React, { Component } from 'react';

export class Product extends Component {
    render() {
        return (
            <tr>
                <td>{this.props.product.name}</td>
                <td>{this.props.product.amount}</td>
                <td>{this.props.product.barcode}</td>
                <td>{this.props.product.expirationDate}</td>
                <td>{this.props.product.price}</td>
            </tr>
        );
    }
}