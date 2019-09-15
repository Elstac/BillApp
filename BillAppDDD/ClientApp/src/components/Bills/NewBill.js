import React, { Component } from 'react';
import { DropdownList } from 'react-widgets';
import { ProductList } from '../Products/ProductsList';

export class NewBill extends Component {
    static displayName = NewBill.name;

    constructor(props) {
        super(props);

        this.state = {
            bill: {
                date: new Date(),
                storeId: null,
                promotions: null
            },
            products:[]
        };

        fetch('/api/stores')
            .then(response => response.json())
            .then(data => {
                this.setState({ stores: data });
            })
    }

    handleNewProduct(product) {
        var prods = this.state.products;

        prods.push(product);

        this.setState({ products: prods });
    }

    handleSubmit() {
        var request = {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                newBill: {
                    date: this.state.bill.date,
                    storeId: 'ss',
                    purchases: this.state.products.map(p => {
                        return {
                            product: {
                                name: p.name,
                                barcode: p.barcode,
                                id: '',
                                barcode: '',
                                price: 0
                            },
                            date: this.state.bill.date,
                            amount: p.amount,
                            price: p.price
                        }
                    })
                } 
            })
        };

        fetch('/api/bill', request)
        .catch((error) => alert('Error during operation.'))
        .finally(() => window.location.href = '/')
    }

    render() {
        return (
            <div className="container">
                <form onSubmit={this.handleSubmit.bind(this)}>
                    <h1>New bill</h1>
                    <div className="row">
                        <div className="col-12">
                            <p>Date:</p>
                            <input className="form-control" type="date"/>
                        </div>
                        <div className="col-6">
                            <p>Store:</p>
                            {this.state.stores != null ?
                                <DropdownList
                                data={this.state.stores.map(store => store.name)}
                                /> :
                                <DropdownList
                                    busy
                                    disabled
                                />}
                        </div>
                        <div className="col-6">
                            <p>Promotion:</p>
                            {this.state.promotions != null ?
                                <DropdownList
                                    data={this.state.promotions.map(prom => prom.name)}
                                /> :
                                <DropdownList
                                    busy
                                    disabled
                                />}
                        </div>
                        <div className="col-12">
                            <h2>Products</h2>
                            <ProductList
                                products={this.state.products}
                                handleNewProduct={this.handleNewProduct.bind(this)}
                            />
                        </div>
                    </div>
                    <div className="text-center mt-3">
                        <input className="btn btn-success w-100" type="submit" value="Add bill" />
                    </div>
                </form>
            </div>
        );
    }
}