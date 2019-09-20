import React, { Component } from 'react';

export class TimeSpan extends Component {
    constructor(props) {
        super(props);

        this.state = {
            span: {
                from: null,
                to: null
            }
        }
    }

    handleSpanChange(event) {
        var span = this.state.span;
        span[event.target.name] = event.target.value;

        this.setState({ span });

        this.props.handleSpanChange(span);
    }

    render() {
        return (
            <div className="row">
                <div className="col-6">
                    <p className="my-1">From</p>
                    <input name="from" type="date" className="form-control" onChange={this.handleSpanChange.bind(this)}/>
                </div>
                <div className="col-6">
                    <p className="my-1">To</p>
                    <input name="to" type="date" className="form-control" onChange={this.handleSpanChange.bind(this)} />
                </div>
            </div>
        );
    }
}