import { Component } from '@angular/core';
import { AgGridModule } from 'ag-grid-angular';
import { ColDef } from 'ag-grid-community';
import { ClientSideRowModelModule } from 'ag-grid-community';

interface Vegetable {
  name: string;
  quantity: number;
}

@Component({
  selector: 'app-vegetable-grid',
  standalone: true,
  imports: [AgGridModule], // Remove incorrect usage of ClientSideRowModelModule here
  templateUrl: './vegetable-grid.component.html',
  styleUrls: ['./vegetable-grid.component.css']
})
export class VegetableGridComponent {
  columnDefs: ColDef<Vegetable>[] = [
    { field: 'name', headerName: 'Vegetable', sortable: true, filter: true },
    { field: 'quantity', headerName: 'Quantity' },
    {
      headerName: 'Actions',
      cellRenderer: () => {
        return `<button class="cart-btn" onclick="addToCart()">🛒 Add to Cart</button>`;
      }
    }
  ];

  rowData: Vegetable[] = [
    { name: 'Carrot', quantity: 0 },
    { name: 'Broccoli', quantity: 0 },
    { name: 'Spinach', quantity: 0 }
  ];

  modules = [ClientSideRowModelModule]; // This is the correct way to register the row model
}