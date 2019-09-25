import React, { Component } from 'react';

export class NewCategoryPopUp extends Component {
    emptyCategory = {
        name: ''
    }

    constructor(props) {
        super(props);

        this.state = {
            newCategory: this.emptyCategory
        }

    }

    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        let newCategory = { ...this.state.newCategory };

        newCategory[name] = value;

        this.setState({ newCategory });
    }

    handleConfirm() {
        this.props.handleConfirm(this.state.newCategory);

        this.hide();
    }

    handleCancel() {
        this.hide();
    }

    hide() {
        this.setState({ newCategory: this.emptyCategory });

        this.props.handleCancel();
    }

    render() {
        var hidden = this.props.hidden ? 'd-none' : '';
        var item = this.state.newCategory

        return (
            <div className={hidden + ' container fixed-top jumbotron w-50 text-center py-3 mt-5'}>
                <h2>New category</h2>
                <div className="row">
                    <div className="col-12">
                        <p className="m-0 mt-2">Name</p>
                        <input name="name" className="form-control" type="text" value={item.name} onChange={this.handleChange.bind(this)} />
                    </div>
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