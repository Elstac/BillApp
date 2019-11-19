import React, { Component } from 'react';
import { CRUDContainer } from '../Shared/CRUDContainer';
import { CRUDTile } from '../Shared/CRUDTile';

export class ProductContainer extends CRUDContainer {
    constructor(props) {
        super(props, '/api/products/getall');
    }

    render() {
        if (this.state.data === null)
            return (
                <div>
                    {super.render(null)}
                </div>
            );

        var content = this.state.data.map((v, i, a) =>
            <div className="col-12 border-bottom mt-2">
                <CRUDTile
                    key={i}
                    data={v}
                    detailsLink={'/productDetails/'+v.id}
                />
            </div>
        );

        return (
            <div>
                {super.render(content)}
            </div>
        );
    }
}