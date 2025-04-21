import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';

interface Vegetable {
  name: string;
  quantity: number;
}

@Component({
  selector: 'app-vegetable-grid',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './vegetable-grid.component.html',
  styleUrls: ['./vegetable-grid.component.css']
})
export class VegetableGridComponent {
  displayedColumns: string[] = ['name', 'quantity', 'actions'];
  vegetables: Vegetable[] = [
    { name: 'Carrot', quantity: 0 },
    { name: 'Broccoli', quantity: 0 },
    { name: 'Spinach', quantity: 0 }
  ];

  increaseQuantity(name: string) {
    const item = this.vegetables.find(v => v.name === name);
    if (item) item.quantity++;
  }

  decreaseQuantity(name: string) {
    const item = this.vegetables.find(v => v.name === name);
    if (item && item.quantity > 0) item.quantity--;
  }
}