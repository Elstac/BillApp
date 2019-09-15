import React, { Component } from 'react';
import { Product } from './Product';
import { NewProductPopUp } from './NewProductPopUp';

export class ProductList extends Component {

    constructor(props) {
        super(props);

        this.state = {
            newProduct: false
        };
    }

    newProductClickHandle() {
        this.setState({ newProduct: true });
    }

    handleCancel() {
        this.setState({ newProduct: false });
    }

    render() {
        return (
            <div>
                <table className="table text-center">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Amount</th>
                            <th>Barcode</th>
                            <th>Expiration date</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.products.map(prod => <Product product={prod} />)}
                    </tbody>
                </table>
                <div className="container text-center">
                    <button type="button" className="btn btn-primary w-50" onClick={this.newProductClickHandle.bind(this)}>Add product</button>
                </div>
                <NewProductPopUp
                    hidden={!this.state.newProduct}
                    handleConfirm={this.props.handleNewProduct}
                    handleCancel={this.handleCancel.bind(this)}
                />
            </div>
        );
    }
}