import React, { Component } from 'react';

export class FormInput extends Component {
    render() {
        alert(this.props.value);

        return (
            <input type={this.props.type} className={this.props.className} value={this.props.object[this.props.propertyName]} />
        );
    }
}