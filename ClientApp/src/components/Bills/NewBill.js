import React, { Component } from 'react';
import { DropdownList } from 'react-widgets';
import { ProductList } from '../Products/ProductsList';
import { FormInput } from '../Shared/FormInput';

export class NewBill extends Component {
    static displayName = NewBill.name;

    constructor(props) {
        super(props);
        var date = new Date();

        var dateF = date.getFullYear() + '-' + date.getMonth().toString().padStart(2, 0) + '-' + date.getDate().toString().padStart(2, 0);
        this.state = {
            date: dateF,
            storeId: null,
            promotions: null,
            products:[]
        };

        fetch('/api/stores/getall')
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

    handleStoreChange(storeId) {
        this.setState({ storeId });
    }

    handleDateChange(event) {
        this.setState({ date: event.target.value });
    }

    handleSubmit() {
        var request = {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Date: this.state.date,
                StoreId: this.state.storeId,
                Purchases: this.state.products.map(p => {
                    return {
                        Product: {
                            Name: p.name,
                            Barcode: p.barcode,
                            Id: p.id,
                            Price: 0,
                            CategoryId: p.categoryId
                        },
                        Date: this.state.date,
                        Amount: p.amount,
                        Price: p.price
                    }
                })
                
            })
        };

        fetch('/api/bill/add', request)
        .catch((error) => alert('Error during operation. ' + error))
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
                            <input name="date" className="form-control" type="date" value={this.state.date} onChange={this.handleDateChange.bind(this)} />
                        </div>
                        <div className="col-6">
                            <p>Store:</p>
                            {this.state.stores != null ?
                                <DropdownList
                                    textField='name'
                                    data={this.state.stores}
                                    onChange={value=>this.handleStoreChange(value.id)}
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
                        <input className="btn btn-success w-75" type="submit" value="Add bill" />
                    </div>
                </form>
            </div>
        );
    }
}