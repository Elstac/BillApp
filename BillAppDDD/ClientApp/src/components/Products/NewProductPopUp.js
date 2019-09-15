import React, { Component } from 'react';

export class NewProductPopUp extends Component {
    emptyProduct = {
        name: '',
        barcode: '',
        amount: 0,
        expirationDate: undefined,
        price: 0
    }

    constructor(props) {
        super(props);

        this.state = {
            newProduct: this.emptyProduct
        }
    }

    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        var nameParts = name.split('.');
        let newProduct = { ...this.state.newProduct };

        newProduct[name] = value;

        this.setState({ newProduct });
    }

    handleConfirm() {
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
            <div className={hidden + ' container fixed-top jumbotron w-25 text-center py-3 mt-5'}>
                <h2>New product</h2>
                <div>
                    <p>Name</p>
                    <input name="name" className="form-control" type="text" value={item.name} onChange={this.handleChange.bind(this)} />
                </div>
                <div>
                    <p>Amount</p>
                    <input name="amount" className="form-control" type="number" value={item.amount} onChange={this.handleChange.bind(this)}/>
                </div>
                <div>
                    <p>Barcode</p>
                    <input name="barcode" className="form-control" type="text" value={item.barcode} onChange={this.handleChange.bind(this)}/>
                </div>
                <div>
                    <p>Expiration date</p>
                    <input name="expirationDate" className="form-control" type="date" value={item.expirationDate} onChange={this.handleChange.bind(this)}/>
                </div>
                <div>
                    <p>Price</p>
                    <input name="price" className="form-control" type="number" step="0.01" value={item.price} onChange={this.handleChange.bind(this)}/>
                </div>
                <div className="row mt-2">
                    <div className="col-6">
                        <button type="button" className="btn btn-success w-100" onClick={this.handleConfirm.bind(this)}>Add</button>
                    </div>
                    <div className="col-6">
                        <button type="button" className="btn btn-danger w-100" onClick={this.handleCancel.bind(this)}>Cancel</button>
                    </div>
                </div>
            </div>
        );
    }
}