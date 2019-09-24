import React, { Component } from 'react';
import Chart from 'react-apexcharts';

export class StoreSpendingChart extends Component {
     render() {

         if (this.props.stores === null)
             return (
                 <div className="container jumbotron py-1">
                     <h2>Spendings per product category</h2>
                     <h3>Loading...</h3>
                 </div>
             );

         var stores = this.props.stores.filter((v, i, a) => v.totalSpent !== 0);

         var labels = stores.map((v, i, a) => v.name);

         var series = stores.map((v, i, a) => v.totalSpent);

         return (
             <div className="container jumbotron py-1">
                 <h2>Spendings per store</h2>
                 <Chart
                     options={{ labels: labels }}
                     series={series}
                     type="donut"
                     width="380"
                 />
             </div>
         );
     }
 }
