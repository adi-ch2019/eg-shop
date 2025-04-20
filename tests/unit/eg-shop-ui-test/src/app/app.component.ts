import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { VegetableGridComponent } from './vegetable-grid/vegetable-grid.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, VegetableGridComponent], // Include VegetableGridComponent
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'eg-shop-ui-test';
}