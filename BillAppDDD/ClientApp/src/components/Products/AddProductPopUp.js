import React, { Component } from 'react';
import { DropdownList } from 'react-widgets';
import { NewProductPopUp } from './NewProductPopUp';

export class AddProductPopUp extends Component {
    constructor(props) {
        super(props);

        this.state = {
            products: null,
            toAdd: null,
            amount: 0,
            price: 0,
            newProduct: false
        }

        fetch('/api/products/getall')
            .then(response => response.json())
            .then(data => {
                this.setState({ products: data });
            })
    }

    handleProductChange(product) {
        this.setState({ toAdd: product, price: product.price });
    }

    handleConfirm() {
        this.props.handleConfirm(
            {
                ...this.state.toAdd,
                amount: this.state.amount,
                price: this.state.price
            }
        );

        this.props.handleHide();
    }

    handleCancel() {
        this.setState({ toAdd: null, newProduct:false });
        this.props.handleHide();
    }

    handleModeChange() {
        this.setState({ newProduct: true });
    }

    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        let newState = { ...this.state };

        if (name === 'amount')
            newState['price'].value *= value;
        
        newState[name] = value;

        this.setState({ ...newState });
    }

    render() {
        var hidden = this.props.hidden ? 'd-none' : '';

        if (!this.state.newProduct) {
            return (
                <div className={hidden + ' container fixed-top jumbotron w-50 text-center py-3 mt-5'}>
                    <h2>Existing product</h2>
                    {this.state.products != null ?
                        <DropdownList
                            textField='name'
                            data={this.state.products}
                            onChange={value => this.handleProductChange(value)}
                        /> :
                        <DropdownList
                            busy
                            disabled
                        />}

                    <div className="row mt-2">
                        <div className="col-6">
                            <div>
                                <p className="m-0">Amount:</p>
                                <input name="amount" type="numer" step="0.01" className="form-control" value={this.state.amount} onChange={this.handleChange.bind(this)} />
                            </div>
                        </div><div className="col-6">
                            <div>
                                <p className="m-0">Price:</p>
                                <input name="price" type="numer" step="0.01" className="form-control" value={this.state.price} onChange={this.handleChange.bind(this)} />
                            </div>
                        </div>
                    </div>

                    <div className="row mt-2">
                        <div className="col-4">
                            <div>
                                <button type="button" className="btn btn-success w-100" onClick={this.handleConfirm.bind(this)}>Add</button>
                            </div>
                        </div>
                        <div className="col-4">
                            <div>
                                <button type="button" className="btn btn-primary w-100" onClick={()=>this.setState({ newProduct:true })}>New</button>
                            </div>
                        </div>
                        <div className="col-4">
                            <button type="button" className="btn btn-danger w-100" onClick={this.handleCancel.bind(this)}>Cancel</button>
                        </div>
                    </div>
                </div>
            );
        }
        else {
            return (
                <NewProductPopUp
                    hidden={false}
                    handleConfirm={this.props.handleConfirm}
                    handleCancel={this.handleCancel.bind(this)}
                    handleReturn={()=>this.setState({ newProduct: false })}
                />
                )
        }
    }    
}