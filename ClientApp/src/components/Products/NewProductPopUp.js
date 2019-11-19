import React, { Component } from 'react';
import { DropdownList } from 'react-widgets';
import apiClient from '../API/apiClient';

export class NewProductPopUp extends Component {
    emptyProduct = {
        name: '',
        barcode: '',
        amount: 0,
        expirationDate: undefined,
        price: 0,
        categoryId: ''
    }

    constructor(props) {
        super(props);

        this.state = {
            newProduct: this.emptyProduct,
            categories: null
        }

        apiClient.get('/api/products/categories/getall')
            .then(data => {
                this.setState({ categories: data });
            });
    }

    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        let newProduct = { ...this.state.newProduct };

        newProduct[name] = value;

        this.setState({ newProduct });
    }

    handleCategoryChange(categoryId) {
        alert(categoryId);
        let prod = this.state.newProduct;
        prod.categoryId = categoryId;
        this.setState({ newProduct:prod })
    }

    handleConfirm() {
        alert(...this.state.newProduct);
        this.props.handleConfirm(this.state.newProduct);

        this.hide();
    }

    handleCancel() {
        this.hide();
    }

    hide() {
        this.setState({ newProduct: this.emptyProduct });

        this.props.handleCancel();
    }

    render() {
        var hidden = this.props.hidden ? 'd-none' : '';
        var item = this.state.newProduct

        return (
            <div className={hidden + ' container fixed-top jumbotron w-50 text-center py-3 mt-5'}>
                <h2>New product</h2>
                <div className="row">
                    <div className="col-6">
                        <p className="m-0 mt-2">Name</p>
                    <input name="name" className="form-control" type="text" value={item.name} onChange={this.handleChange.bind(this)} />
                </div>
                <div className="col-6">
                        <p className="m-0 mt-2">Barcode</p>
                    <input name="barcode" className="form-control" type="text" value={item.barcode} onChange={this.handleChange.bind(this)} />
                </div>
                <div className="col-6">
                        <p className="m-0 mt-2">Amount</p>
                    <input name="amount" className="form-control" type="number" value={item.amount} onChange={this.handleChange.bind(this)}/>
                </div>
                <div className="col-6">
                        <p className="m-0 mt-2">Price</p>
                    <input name="price" className="form-control" type="number" step="0.01" value={item.price} onChange={this.handleChange.bind(this)} />
                </div>
                <div className="col-6">
                        <p className="m-0 mt-2">Expiration date</p>
                    <input name="expirationDate" className="form-control" type="date" value={item.expirationDate} onChange={this.handleChange.bind(this)}/>
                </div>
                 <div className="col-6">
                        <p className="m-0 mt-2">Category</p>
                    {this.state.categories != null ?
                        <DropdownList
                            textField='name'
                            data={this.state.categories}
                            onChange={value => this.handleCategoryChange(value.id)}
                        /> :
                        <DropdownList
                            busy
                            disabled
                        />}
                    </div>
                </div>
                <div className="row mt-2">
                    <div className="col-4">
                        <button type="button" className="btn btn-success w-100" onClick={this.handleConfirm.bind(this)}>Add</button>
                    </div>
                    <div className="col-4">
                        <button type="button" className="btn btn-primary w-100" onClick={this.props.handleReturn}>Return</button>
                    </div>
                    <div className="col-4">
                        <button type="button" className="btn btn-danger w-100" onClick={this.handleCancel.bind(this)}>Cancel</button>
                    </div>
                </div>
            </div>
        );
    }
}